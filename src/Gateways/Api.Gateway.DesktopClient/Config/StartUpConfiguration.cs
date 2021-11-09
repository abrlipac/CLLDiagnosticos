using Api.Gateway.Proxies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Gateway.DesktopClient.Config
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddAppsettingBinding(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ApiUrls>(opts => configuration.GetSection("ApiUrls").Bind(opts));
            return service;
        }

        public static IServiceCollection AddProxiesRegistration(this IServiceCollection service)
        {
            service.AddHttpContextAccessor();

            service.AddHttpClient<IClientesProxy, ClientesProxy>();
            service.AddHttpClient<IDiagnosticosProxy, DiagnosticosProxy>();
            service.AddHttpClient<IIdentityProxy, IdentityProxy>();
            service.AddHttpClient<IUsuarioProxy, UsuarioProxy>();
            service.AddHttpClient<IPersonalProxy, PersonalProxy>();

            return service;
        }
    }
}
