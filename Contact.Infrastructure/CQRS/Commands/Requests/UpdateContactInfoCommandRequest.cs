using Contact.Infrastructure.CQRS.Common;
using MediatR;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class UpdateContactInfoCommandRequest : IRequest<EmptyResponse>
    {
        public string Id { get; set; }
        public string ContactId { get; set; }
        public string InfoType { get; set; }
        public string InfoDescription { get; set; }
    }
}
