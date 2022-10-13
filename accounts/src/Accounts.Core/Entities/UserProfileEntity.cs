namespace Accounts.Core.Entities
{
    public class UserProfileEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}