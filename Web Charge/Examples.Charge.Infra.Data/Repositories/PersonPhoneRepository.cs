using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly PGCContext _context;

        public PersonPhoneRepository(PGCContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindPersonPhoneNumberByNumberAsync(string phoneNumber)
        {
            return await Task.Run(() => _context.PersonPhone.
            Where(p => p.PhoneNumber.CompareTo(phoneNumber) == 0).ToList());
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone)
        {
            await _context.PersonPhone.AddAsync(personPhone);
            await _context.SaveChangesAsync();
            return personPhone;
        }

        public async Task<PersonPhone> UpdateAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone)
        {
            if (_context.Remove(oldPersonPhone).State == EntityState.Deleted)
            {
                await _context.PersonPhone.AddAsync(newPersonPhone);
                await _context.SaveChangesAsync();
                return newPersonPhone;
            }
            return oldPersonPhone;
        }

        public async Task DeleteAsync(PersonPhone personPhone)
        {
            await Task.Run(()=>
            {
                _context.Remove(personPhone);
                _context.SaveChanges();
            });
        }
    }
}
