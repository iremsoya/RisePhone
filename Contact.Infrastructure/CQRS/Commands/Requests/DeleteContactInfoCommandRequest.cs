using Contact.Infrastructure.CQRS.Common;
using MediatR;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class DeleteContactInfoCommandRequest : IRequest<EmptyResponse>
    {
        public string Id { get; set; }
        public string ContactId { get; set; }
    }
}
