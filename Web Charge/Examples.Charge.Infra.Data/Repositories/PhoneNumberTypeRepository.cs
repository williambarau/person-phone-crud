using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly PGCContext _context;

        public PhoneNumberTypeRepository(PGCContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllAsync() => await Task.Run(() => _context.PhoneNumberType);
    }
}
