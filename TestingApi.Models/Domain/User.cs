namespace TestingApi.Models.Domain
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
    }
}
