using Contact.Infrastructure.CQRS.Commands.Request;
using Contact.Infrastructure.CQRS.Commands.Response;
using Contact.Infrastructure.CQRS.Common;
using Contact.Infrastructure.CQRS.Queries.Request;
using Contact.Infrastructure.CQRS.Queries.Response;
using Contact.Manager.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Manager.Concrete
{
    public class ContactInfoManager : IContactInfoManager
    {
        private readonly IMediator _mediator;
        public ContactInfoManager(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<CreateContactInfoCommandResponse> CreateContactInfoAsync(CreateContactInfoCommandRequest requestModel)
        {
            return await _mediator.Send(requestModel);
        }

        public async Task<EmptyResponse> DeleteContactInfoAsync(DeleteContactInfoCommandRequest requestModel)
        {
            return await _mediator.Send(requestModel);
        }

        public async Task<IEnumerable<ListContactInfoQueryResponse>> GetAllContactInfoAsync(ListContactInfoQueryRequest requestModel)
        {
            return await _mediator.Send(requestModel);
        }

        public async Task<ContactInfoQueryResponse> GetContactInfoAsync(GetContactInfoQueryRequest requestModel)
        {
            return await _mediator.Send(requestModel);
        }

        public async Task<EmptyResponse> UpdateContactInfoAsync(UpdateContactInfoCommandRequest requestModel)
        {
            return await _mediator.Send(requestModel);
        }
    }
}
