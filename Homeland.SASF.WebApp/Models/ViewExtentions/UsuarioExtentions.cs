using Homeland.SASF.Model;
using Homeland.SASF.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homeland.SASF.Security
{
    public static class UsuarioExtentions
    {
        public static RegisterViewModel ToRegisterViewModel(this Usuario usuario)
        {
            return new RegisterViewModel
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Login = usuario.UserName,
                PhoneNumber = usuario.PhoneNumber,
                Password = "",
                ConfirmPassword = ""
            };
        }
    }
}
