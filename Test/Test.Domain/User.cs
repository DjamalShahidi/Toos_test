using Test.Domain.Common;

namespace Test.Domain
{
    public class User :BaseDomainEntity
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
