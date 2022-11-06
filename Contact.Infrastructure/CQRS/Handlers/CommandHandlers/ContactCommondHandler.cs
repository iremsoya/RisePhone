using AutoMapper;
using Contact.Infrastructure.CQRS.Commands.Request;
using Contact.Infrastructure.CQRS.Commands.Response;
using Contact.Infrastructure.CQRS.Common;
using Contact.Infrastructure.Models;
using MediatR;
using MongoDB.Driver;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Infrastructure.CQRS.Handlers.CommandHandlers
{
    public class ContactCommandHandler :
    IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse?>,
    IRequestHandler<DeleteContactCommandRequest, EmptyResponse?>,
    IRequestHandler<UpdateContactCommandRequest, EmptyResponse?>
    {
        private readonly MongoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRedisClient _redisCache;

        public ContactCommandHandler(MongoDbContext context, IMapper mapper, IRedisClient redisCache)
        {
            _context = context;
            _mapper = mapper;
            _redisCache = redisCache;
        }

        public async Task<CreateContactCommandResponse?> Handle(CreateContactCommandRequest request,
            CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact.Infrastructure.Models.Contact>(request);
            contact.CreatedDate = DateTime.Now;
            contact.UpdatedDate = DateTime.Now;
            contact.IsActive = "true";
            //var isContactExists = await _context.Contact.CountDocumentsAsync(x => x.Id == request.Title,
            //    cancellationToken: cancellationToken) > 0;

            //if (!isContactExists)
            //    return null;

            await _context.Contact.InsertOneAsync(contact, cancellationToken: cancellationToken);
            await _redisCache.Db0.RemoveAsync("contact");

            return new CreateContactCommandResponse
            {
                Id = contact.Id
            };
        }

        public async Task<EmptyResponse?> Handle(UpdateContactCommandRequest request,
           CancellationToken cancellationToken)
        {
            var filter = Builders< Contact.Infrastructure.Models.Contact>.Filter.Eq("Id", request.Id);
            var update = Builders< Contact.Infrastructure.Models.Contact>.Update
                .Set("FirstName", request.FirstName)
                .Set("LastName", request.LastName)
                .Set("Company", request.Company)
                .Set("ContactInfos", request.ContactInfos)
                .Set("UpdatedDate", DateTime.Now);

            var result = await _context.Contact.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
            await _redisCache.Db0.RemoveAllAsync(new[] { "contact", $"contact_{request.Id}" });

            return result.ModifiedCount == 0 ? null : EmptyResponse.Default;
        }
        public async Task<EmptyResponse?> Handle(DeleteContactCommandRequest request,
           CancellationToken cancellationToken)
        {
            var filter = Builders< Contact.Infrastructure.Models.Contact>.Filter.Eq("Id", request.Id);
            var result = await _context.Contact.DeleteOneAsync(filter, cancellationToken);

            await _redisCache.Db0.RemoveAllAsync(new[] { "contact", $"contact_{request.Id}" });

            return result.DeletedCount == 0 ? null : EmptyResponse.Default;
        }
    }
}
