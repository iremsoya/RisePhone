using Contact.Infrastructure.CQRS.Commands.Response;
using MediatR;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class CreateContactInfoCommandRequest : IRequest<CreateContactInfoCommandResponse>
    {
        public string ContactId { get; set; }
        public string InfoType { get; set; }
        public string InfoDescription { get; set; }
    }
}
