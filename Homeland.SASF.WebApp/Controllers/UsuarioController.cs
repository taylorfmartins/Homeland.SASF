using Homeland.SASF.Persistencia;
using Homeland.SASF.Security;
using Homeland.SASF.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly AuthDbContext _context;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, AuthDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(String.Empty, "Erro na autenticação");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Login };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Detalhes(string id)
        {
            var model = RecuperarUsuario(id).ToRegisterViewModel();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public Usuario RecuperarUsuario(string id)
        {
            return _context.Users.Find(id);
        }

        private IEnumerable<Usuario> Carregar()
        {
            return _context.Users
                .ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new UsuarioViewModel
            {
                Usuarios = Carregar()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario { 
                    Id = model.Id,
                    UserName = model.Login, 
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    
                };
                var result = await _userManager.UpdateAsync(user);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Usuario");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario {
                    UserName = model.Login,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Usuario");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Remover(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.DeleteAsync(_context.Users.Find(id));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Usuario");
                }
            }
            return RedirectToAction("Index", "Usuario");
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }
    }
}
