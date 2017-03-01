﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.Areas.Authorization;
using Frapid.Areas.CSRF;
using Frapid.Authorization.Models;
using Frapid.Authorization.ViewModels;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;

namespace Frapid.Authorization.Controllers
{
    [AntiForgery]
    public class MenuAccessPolicyController : DashboardController
    {
        [Route("dashboard/authorization/menu-access/user-policy")]
        [MenuPolicy]
        public async Task<ActionResult> UserPolicyAsync()
        {
            var model = await MenuAccessPolicyModel.GetAsync(this.AppUser).ConfigureAwait(true);
            return this.FrapidView(this.GetRazorView<AreaRegistration>("MenuPolicy/Policy.cshtml", this.Tenant), model);
        }

        [Route("dashboard/authorization/menu-access/user-policy/{officeId}/{userId}")]
        public async Task<ActionResult> GetPolicyAsync(int officeId, int userId)
        {
            var model = await MenuAccessPolicyModel.GetAsync(this.AppUser, officeId, userId).ConfigureAwait(true);
            return this.Ok(model);
        }


        [HttpPut]
        [Route("dashboard/authorization/menu-access/user-policy")]
        public async Task<ActionResult> SavePolicyAsync(UserMenuPolicyInfo model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            await MenuAccessPolicyModel.SaveAsync(this.Tenant, model).ConfigureAwait(true);
            return this.Ok("OK");
        }
    }
}