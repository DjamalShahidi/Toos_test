namespace Test.Domain
{
    public class UserDetail
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public UserDetailValueType Type { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }

    public enum UserDetailValueType
    {
        Int = 1,
        Boolean = 10,
        String = 30,
        DateTime=40,
    }
}
