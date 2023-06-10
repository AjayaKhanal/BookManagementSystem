using System.Threading.Tasks;
using BookManagementSystem.Configuration.Dto;

namespace BookManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
