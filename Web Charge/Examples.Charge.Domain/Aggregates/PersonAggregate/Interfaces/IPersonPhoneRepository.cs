using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindPersonPhoneNumberByNumberAsync(string phoneNumber);

        Task<IEnumerable<PersonPhone>> FindAllAsync();

        Task<PersonPhone> AddAsync(PersonPhone personPhone);

        Task<PersonPhone> UpdateAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone);

        Task DeleteAsync(PersonPhone personPhone);
    }
}
