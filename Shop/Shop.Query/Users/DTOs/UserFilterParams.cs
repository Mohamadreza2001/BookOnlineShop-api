using Common.Query.Filter;

namespace Shop.Query.Users.DTOs
{
    public class UserFilterParams : BaseFilterParam
    {
        public long? UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
