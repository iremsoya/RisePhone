using Contact.Infrastructure.CQRS.Commands.Response;
using Contact.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
