using Test.Domain.Common;

namespace Test.Domain
{
    public class User :BaseDomainEntity
    {
        public int Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<UserDetail> UserDetails { get; set; }

    }
}
