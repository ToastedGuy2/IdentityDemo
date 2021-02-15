using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public IActionResult List()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(string roleName)
        {
           await _roleManager.CreateAsync(new IdentityRole(roleName));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id,string roleName)
        {
            var role = await _roleManager.FindByIdAsync(id);
            role.Name = roleName;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("List");
        }
    }
}
