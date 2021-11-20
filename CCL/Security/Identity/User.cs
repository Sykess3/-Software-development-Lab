namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int Id { get; }

        protected User(int id)
        {
            Id = id;
        }
    }
}