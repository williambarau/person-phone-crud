using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Nito.AsyncEx;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private IPersonPhoneRepository _phoneService;
        public PersonPhoneService(IPersonPhoneRepository phoneService)
        {
            _phoneService = phoneService;
        }

        public async Task<List<PersonPhone>> FindPersonPhoneNumberByNumberAsync(string phoneNumber) =>
            (await _phoneService.FindPersonPhoneNumberByNumberAsync(phoneNumber)).ToList();

        public async Task<List<PersonPhone>> FindAllAsync() =>
            (await _phoneService.FindAllAsync()).ToList();

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone) =>
            await _phoneService.AddAsync(personPhone);
        
        public async Task<PersonPhone> UpdateAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone) =>
            await _phoneService.UpdateAsync(oldPersonPhone, newPersonPhone);

        public async Task DeleteAsync(PersonPhone personPhone) =>
            await _phoneService.DeleteAsync(personPhone);
    }
}
