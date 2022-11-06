using Contact.Infrastructure.CQRS.Commands.Request;
using Contact.Infrastructure.CQRS.Commands.Response;
using Contact.Infrastructure.CQRS.Common;
using Contact.Infrastructure.CQRS.Queries.Request;
using Contact.Infrastructure.CQRS.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Manager.Abstract
{
    public interface IContactManager
    {
        Task<IEnumerable<ListContactQueryResponse>> GetAllContactAsync(ListContactQueryRequest requestModel);
        Task<ContactQueryResponse> GetContactAsync(GetContactQueryRequest requestModel);
        Task<CreateContactCommandResponse> CreateContactAsync(CreateContactCommandRequest requestModel);
        Task<EmptyResponse?> UpdateContactAsync(UpdateContactCommandRequest requestModel);
        Task<EmptyResponse?> DeleteContactAsync(DeleteContactCommandRequest requestModel);
    }
}
