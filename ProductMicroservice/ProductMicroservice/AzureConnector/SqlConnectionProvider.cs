using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ProductMicroservice.AzureConnector
{
    public class SqlConnectionProvider
    {
        private readonly string _vaultUrl = "https://testkeyvaultmsk.vault.azure.net/";
        private readonly string _secretName = "DbConnectionString";

        public async Task<string> GetConnectionStringAsync()
        {
            var client = new SecretClient(new Uri(_vaultUrl), new DefaultAzureCredential());
            KeyVaultSecret secret = await client.GetSecretAsync(_secretName);
            return secret.Value;
        }

    }
}
