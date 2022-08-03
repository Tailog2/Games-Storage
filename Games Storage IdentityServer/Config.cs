using IdentityServer4.Models;

namespace Games_Storage_IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients = new[]
        {
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "GamesStorage Api",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("LamePassword".Sha256())},
                AllowedScopes = { "GamesStorageApi.read", "GamesStorageApi.write" }
            },
            new Client
            {
                ClientId = "interactive",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("LamePassword".Sha256())},
                AllowedScopes = { "GamesStorageApi.read", "GamesStorageApi.write" }
            }
        };

        public static
    }
}
