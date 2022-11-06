using Contact.Infrastructure.CQRS.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.CQRS.Queries.Request
{
    public class GetContactInfoQueryRequest : IRequest<ContactInfoQueryResponse>
    {
        public string Id { get; set; }
        public string ContactId { get; set; }
    }
}
