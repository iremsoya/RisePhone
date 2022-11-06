using Contact.Infrastructure.CQRS.Common;
using Contact.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace Contact.Infrastructure.CQRS.Commands.Request
{
    public class UpdateContactCommandRequest : IRequest<EmptyResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
