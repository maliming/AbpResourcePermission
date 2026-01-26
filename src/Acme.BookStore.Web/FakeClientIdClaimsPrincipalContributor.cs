using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OpenIddict.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Acme.BookStore.Web;

public class FakeClientIdClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
{
    public Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
        if (identity != null && !context.ClaimsPrincipal.HasClaim(AbpClaimTypes.ClientId))
        {
            identity.AddClaim(new Claim(AbpClaimTypes.ClientId, "BookStore_Web"));
        }

        return Task.CompletedTask;
    }
}
