using RestSharp.Authenticators;
using RestSharp;

namespace TsbSia.LtaDataMallApi.Utils
{
    public class AccountKeyAuthenticator : AuthenticatorBase
    {
        public AccountKeyAuthenticator(string accountKey) : base(accountKey)
        {
            if (string.IsNullOrWhiteSpace(accountKey))
            {
                throw new ArgumentNullException(nameof(accountKey));
            }
        }
        protected override ValueTask<Parameter> GetAuthenticationParameter(string accountKey)
            => new(new HeaderParameter("AccountKey", accountKey));
    }
}
