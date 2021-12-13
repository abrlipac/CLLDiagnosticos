using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using WebClientNF.Models;

namespace WebClientNF.Services
{
    public interface IUsuario
    {
        [Post("identity/auth")]
        RestResponse<IdentityAccess> Login([Body] string password, [Body] string username);
    }
}
