using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindPersonPhoneNumberByNumberAsync(string phoneNumber);

        Task<PersonPhoneListResponse> FindAllAsync();

        Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personResponse);

        Task<PersonPhoneResponse> UpdateAsync(PersonPhoneUpdateRequest personResponse);

        Task DeleteAsync(PersonPhoneRequest personResponse);
    }
}
