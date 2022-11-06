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
   public interface IContactInfoManager
    {
        Task<IEnumerable<ListContactInfoQueryResponse>> GetAllContactInfoAsync(ListContactInfoQueryRequest requestModel);
        Task<ContactInfoQueryResponse> GetContactInfoAsync(GetContactInfoQueryRequest requestModel);
        Task<CreateContactInfoCommandResponse> CreateContactInfoAsync(CreateContactInfoCommandRequest requestModel);
        Task<EmptyResponse?> UpdateContactInfoAsync(UpdateContactInfoCommandRequest requestModel);
        Task<EmptyResponse?> DeleteContactInfoAsync(DeleteContactInfoCommandRequest requestModel);
    }
}
