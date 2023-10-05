namespace Common.Application.Validation
{
    public static class ValidationMessages
    {
        public const string Required = "This field is required";
        public const string InvalidPhoneNumber = "Phone number is not valid";
        public const string NotFound = "Not found";
        public const string MaxLength = "The number of characters entered exceeds the limit";
        public const string MinLength = "The number of characters entered is less than the limit";

        public static string required(string field) => $"{field} is required ";
        public static string maxLength(string field, int maxLength) => $"{field} must be less than {maxLength} character(s)";
        public static string minLength(string field, int minLength) => $"{field} must be more than {minLength} character(s)";
    }
}
