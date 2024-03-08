namespace Test.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
