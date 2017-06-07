﻿using InterestShare.Bll;
using InterestShare.Bll.Bll;
using InterestShare.Bll.IBll;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using luofu_InterestShare.Common.Log;
using InterestShare.Model.Models;
namespace InterestShare.Management.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {


        }
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        protected IUserBll userbll
        {
            get
            {
                return BllFactory.GetBLLInstance<UserBll>();
            }
        }
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult DoLogin(string name, string password)
        {
            //"nqz", "nqz"
            FileLog.WriteLog("用户名："+name+"；密码:"+password); 
            InterestUser model = userbll.Query(name,password);
            if (model != null && !string.IsNullOrEmpty(model.Account))
            {
                SignIn(name);
                return Redirect("/Home/Index");
            }
            else
            {
                return View("Login", new { tip = "用户名或密码错误" });
            }
        }

        private void SignIn(string name)
        {
            var identity = new ClaimsIdentity(
             new[] { new Claim(ClaimTypes.Name, name+"_"+Guid.NewGuid().ToString()) },
             DefaultAuthenticationTypes.ApplicationCookie);
            Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, identity);
        }

        public ActionResult Exit()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return View("Login");
        }
    }
    }