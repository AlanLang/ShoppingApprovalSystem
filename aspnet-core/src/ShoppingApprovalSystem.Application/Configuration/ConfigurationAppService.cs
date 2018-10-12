﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ShoppingApprovalSystem.Configuration.Dto;

namespace ShoppingApprovalSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ShoppingApprovalSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
