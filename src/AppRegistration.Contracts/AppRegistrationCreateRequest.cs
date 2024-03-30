namespace AppRegistration.Contracts;

public record AppRegistrationCreateRequest(Workload Workload);

public record Workload(
    NonEmptyString Description,
    NonEmptyString Name,
    NonEmptyString Environment,
    Permission Permission,
    NonEmptyString Requester,
    NonEmptyString TicketNumber,
    NonEmptyString ItsmEndpoint,
    NonEmptyString TechnicalOwner
    );

public record Permission
{
    public List<string> Delegated { get; init; } = [];
}

public record NonEmptyString (string Value)
{
    public string Value { get; init; } = 
        !string.IsNullOrWhiteSpace(Value) ? Value
        : throw new ArgumentException("Value must not be empty", nameof(Value));
}
