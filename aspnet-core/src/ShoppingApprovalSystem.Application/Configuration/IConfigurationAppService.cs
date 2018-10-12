using System.Threading.Tasks;
using ShoppingApprovalSystem.Configuration.Dto;

namespace ShoppingApprovalSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
