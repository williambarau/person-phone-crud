using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindPersonPhoneNumberByNumberAsync(string phoneNumber);

        Task<List<PersonPhone>> FindAllAsync();

        Task<PersonPhone> AddAsync(PersonPhone personPhone);

        Task<PersonPhone> UpdateAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone);

        Task DeleteAsync(PersonPhone personPhone);
    }
}
