using Market.Domain.Entities;
using Market.Domain.Interfaces.Repositories;
using Market.Infra.Contexts;

namespace Market.Infra.Repositories
{
    public class StreetFairRepository
        : EntityBaseRepository<StreetFair>, IStreetFairRepository
    {
        public StreetFairRepository(EntityContext context)
            : base(context)
        {
        }
    }
}