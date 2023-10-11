using Common.Domain.Exceptions;
using Common.Domain.Utilities;

namespace Common.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || Value.IsText() || value.Length != 11)
                throw new InvalidDomainDataException("Phonenumber is not valid");
            Value = value;
        }
    }
}
