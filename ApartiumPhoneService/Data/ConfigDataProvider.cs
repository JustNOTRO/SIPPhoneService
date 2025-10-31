using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ApartiumPhoneService;

/// <summary>
/// Provides our registered account and other related data
/// </summary>
public class ConfigDataProvider
{
    private readonly string _path;

    private readonly IDeserializer _deserializer;

    public ConfigDataProvider(string path)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        _path = path;
        _deserializer = deserializer;
    }

    public virtual HashSet<SIPRegisteredAccount> GetRegisteredAccounts()
    {
        var yamlContent = File.ReadAllText(_path);
        var accounts = _deserializer.Deserialize<AccountsProvider>(yamlContent);
        
        return [..accounts.Accounts];
    }
}

public class AccountsProvider
{
    public virtual List<SIPRegisteredAccount> Accounts { get; }
}