namespace Pulse.Contacts.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty");

        if (!value.Contains('@'))
            throw new ArgumentException("Email is not valid");

        return new Email(value.Trim().ToLowerInvariant());
    }

    public override string ToString() => Value;
}
