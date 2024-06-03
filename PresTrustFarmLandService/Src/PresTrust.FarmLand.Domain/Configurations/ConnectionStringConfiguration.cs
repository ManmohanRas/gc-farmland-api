namespace PresTrust.FarmLand.Domain.Configurations;

public class ConnectionStringConfiguration
{
    public ConnectionStringConfiguration(string value) => Value = value;

    public string Value { get; set; }
}
