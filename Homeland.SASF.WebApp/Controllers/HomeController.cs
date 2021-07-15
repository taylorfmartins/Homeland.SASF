using Microsoft.AspNetCore.Mvc;
using Homeland.SASF.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Homeland.SASF.Persistencia;
using Homeland.SASF.Model;
using Homeland.SASF.WebApp.HttpClients;

namespace Homeland.SASF.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<Funcionario> _repoFunc;
        private readonly NotificationApiClient _api;

        public HomeController(IRepository<Funcionario> repoFunc, NotificationApiClient api)
        {
            _repoFunc = repoFunc;
            _api = api;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Questionario()
        {
            foreach (Funcionario funcionario in _repoFunc.All)
            {
                Notification notification = new Notification();

                notification.nome = funcionario.Nome;
                notification.email = funcionario.Email;
                notification.telefone = "+55" + funcionario.Telefone.Trim();
                notification.tipo = funcionario.ToApi().TipoNotificacao;

                _api.PostNotification(notification);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
