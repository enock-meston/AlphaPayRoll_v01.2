using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaPayRoll.FAuthentication
{
    public class ClasAuthenticationStatProv : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage osessionStorage;

        private ClaimsPrincipal oanonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public ClasAuthenticationStatProv(ProtectedSessionStorage sessionStorage)
        {
            osessionStorage = sessionStorage;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var oUserSessionStorageResult = await osessionStorage.GetAsync<UserSession>("UserSession");
                var ouserSession = oUserSessionStorageResult.Success ? oUserSessionStorageResult.Value : null;
                if (ouserSession == null)
                    return await Task.FromResult(new AuthenticationState(oanonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ouserSession.UserName),
                    new Claim(ClaimTypes.Role, ouserSession.UserRole)

                }, "CutomeAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(oanonymous));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {


            ClaimsPrincipal oclaimsPrincipal;
            if (userSession == null)
            {
                await osessionStorage.DeleteAsync("userSession");
                oclaimsPrincipal = oanonymous;
            }
            else
            {
                await osessionStorage.SetAsync("UserSession", userSession);
                oclaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.UserRole)

                }));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(oclaimsPrincipal)));

        }
    }
}
