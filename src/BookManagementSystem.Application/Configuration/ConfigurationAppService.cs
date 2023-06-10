using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BookManagementSystem.Configuration.Dto;

namespace BookManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
