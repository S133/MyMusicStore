﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Messaging;

namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new Person()
                {
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.FullName,
                    CredentialsCode = "",
                    Birthday = DateTime.Now,
                    Sex = true,
                    MobileNumber = "13785642563",
                    Email = model.Email,
                    TelephoneNumber = "13785642563",
                    Description = "",
                    CreateDateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    InquiryPassword = "未设置",
                };
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    ChineseFullName = model.FullName,
                    MobileNumber = "13785642563",
                    Email = model.Email,
                    Person = person,
                };
                var idManager = new IdentityManager();
                idManager.CreateUser(user, model.PassWord);
                idManager.AddUserToRole(user.Id, "RegisterUser");

                return Content("<script>alert('恭喜注册成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
            }
            return View();
        }
        public ActionResult Login(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误",
                };
                var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.UserName, model.PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context = new EntityDbContext();
                    foreach(var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }
                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登录成功！用户的角色:" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";

                    Session["loginStatus"] = loginStatus;

                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };
                    //把登录成功信息保存
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    var identity = userManage.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    return Redirect(returnUrl);
                }
                else
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        ViewBag.ReturnUrl = Url.Action("index", "home");
                    else
                        ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginUserStatus = loginStatus;
                    return View();
                }
            }
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult LoginOut()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home");
        }
        public ActionResult ChangePassWord()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login");

            return View();
        }
        [HttpPost]
        public ActionResult ChangePassWord(ChangePassWordViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePwdSuccessed;
                    try
                {
                    var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                    var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    var user = userManage.Find(userName, model.PassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "原密码不正确");
                        return View();
                    }
                    else
                    {
                        changePwdSuccessed = userManage.ChangePassword(user.Id, model.PassWord, model.NewPassWord).Succeeded;
                        if(changePwdSuccessed)
                            return Content("<script>alert('密码修改成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
                        else
                        {
                            ModelState.AddModelError("", "修改密码失败，请重试");
                        }
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "修改密码失败,请重试");
                }
            }
            return View(model);
        }
    }
}