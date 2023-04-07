using FlightManager.Data;
using FlightManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightManager.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FlightManager.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var list = _context.ApplicationUsers.ToList();

            return View(list);
        }

        // GET: Users/Details
        public async Task<IActionResult> Details(string? Id)
        {
            if (Id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Edit
        /*public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }*/

        /*[HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Address,FirstName,Lastname,Role,UCN")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }*/

        [HttpGet]
        public async Task<IActionResult> Edit(string? Id)
        {
            if (!(Id == null))
            {
                ApplicationUser user = await _context.ApplicationUsers.Where(u => u.Id == Id).FirstOrDefaultAsync();
                if (!(user == null))
                {
                    UserViewModel model = new UserViewModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UCN = user.UCN,
                        Address = user.Address,
                        Role = user.Role,
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var currentUserName = HttpContext.User.Identity.Name;
                ApplicationUser currentUser = _context.ApplicationUsers.Where(cu => cu.UserName == currentUserName).FirstOrDefault();
                string currentUserRole = currentUser.Role;
                ApplicationUser user = _context.ApplicationUsers.Where(u => u.UCN == model.UCN).FirstOrDefault();
                var userRole = _context.UserRoles.Where(ur => ur.UserId == user.Id).FirstOrDefault();
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UCN = model.UCN;
                    user.Address = model.Address;



                    //await _context.SaveChangesAsync();
                    //Current user can't edit himself
                    if (currentUser.FirstName == user.FirstName)
                    {
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else if (currentUser.FirstName != user.FirstName)
                    {
                        //Role Chnage
                        user.Role = model.Role;
                        var newUserRole = userRole;

                        _context.Remove(userRole);
                        await _context.SaveChangesAsync();

                        var admin = _context.Roles.Where(u => u.Name == "Administrator").FirstOrDefault();
                        var employee = _context.Roles.Where(u => u.Name == "Employee").FirstOrDefault();

                        if (model.Role == "Administrator")
                        {
                            newUserRole.RoleId = admin.Id;
                        }
                        else if (model.Role == "Employee")
                        {
                            newUserRole.RoleId = employee.Id;
                        }
                        _context.Add(newUserRole);

                        await _context.SaveChangesAsync();
                        return RedirectToAction("C_Saved", "Roles");
                    }

                }
            }
            return NotFound();
        }

        // GET: User/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
