using Contact.Infrastructure.CQRS.Common;
using MediatR;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class DeleteContactCommandRequest : IRequest<EmptyResponse>
    {
        public string Id { get; set; }
    }
}
