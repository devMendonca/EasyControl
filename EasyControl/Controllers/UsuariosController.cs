using EasyControl.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EasyControl.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [HttpGet]
        public ActionResult CriarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CriarUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {//Tabela de usuários gerenciada pelo Identity
                var usuarioStore = new UserStore<IdentityUser>();
                //Objeto para manipular os usuários
                var usuarioManager = new
                UserManager<IdentityUser>(usuarioStore);
                //Cria uma identidade
                var usuarioInfo = new IdentityUser()
                {
                    UserName = usuario.Nome
                };
                //Cria o usuário
                IdentityResult resultado = usuarioManager.Create(
                usuarioInfo, usuario.Senha);
                if (resultado.Succeeded)
                {
                    //Autentica e volta para a página inicial
                    var autManager = System.Web.HttpContext
                     .Current.GetOwinContext().Authentication;
                    var identidadeUsuario = usuarioManager
                    .CreateIdentity(usuarioInfo,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    autManager.SignIn(new AuthenticationProperties() { },
                    identidadeUsuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception(resultado
                    .Errors.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel usuario, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var usuarioStore = new UserStore<IdentityUser>();
                var usuarioManager = new UserManager<IdentityUser>(usuarioStore);
                var usuarioInfo = usuarioManager
                .Find(usuario.Nome, usuario.Senha);
                if (usuarioInfo != null)
                {
                    var autManager = System.Web.HttpContext
                    .Current.GetOwinContext().Authentication;
                    var identidadeUsuario = usuarioManager
                    .CreateIdentity(usuarioInfo,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    autManager.SignIn(new AuthenticationProperties()
                    { IsPersistent = false }, identidadeUsuario);
                    return returnUrl == null ? Redirect("/Home/Index") :
                    Redirect(returnUrl);
                }
                else
                {
                    throw new Exception("Usuário ou senha inválidos");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }
        
       
        [HttpGet]
        public ActionResult Logout()
        {
            var autManager = System.Web.HttpContext
            .Current.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}