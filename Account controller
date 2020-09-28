using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    
    public class AccountController : Controller
    {
        // GET: Account
        UserContext context = new UserContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            //ViewBag.Roles = context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        
        {
            if (ModelState.IsValid)
            {
                
                var currentUser = context.UserCredentials.Where(t => t.UserId.ToLower().Equals(user.UserId.ToLower()) && t.Password==user.Password && t.user.UserRole==user.UserRole).FirstOrDefault();
 
                if (currentUser != null)
                {
                    if (currentUser.ApprovalStatus == 0)
                    {
                        ModelState.AddModelError("", "Your Account is waiting for Approval");
                        return View();
                    }
                    else if (currentUser.ApprovalStatus == 1)
                    {
                       if(user.UserRole == 1)
                        {
                            FormsAuthentication.SetAuthCookie(user.UserId, false);
                            return RedirectToAction("IndexAdmin");

                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(user.UserId, false);
                            User u = context.Users.Where(t => t.User_Id == user.UserId).FirstOrDefault();
                            return RedirectToAction("IndexUser",u);


                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "Your Account has been rejected");
                        return View();
                    }
                }
                else 
                {
                    ModelState.AddModelError("", "Invalid Member Id or Password");
                    return View();
                }

            };

            return View("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
         [HttpGet]
        public ActionResult Register()
        {
           var id = context.Users.Max(c => c.Id);
            id=id+1;
           string Id = "M"+DateTime.Now.Year+id.ToString();
            User u = new User();
           u.User_Id = Id;
            ViewBag.Roles=context.Roles.ToList();
            return View(u);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Your details are submitted successfully";
                UserCredential u = new UserCredential();
                u.UserId = user.User_Id;
                u.Password = user.Password;
                u.ApprovalStatus = 0;
                context.UserCredentials.Add(u);
                context.Users.Add(user);
                context.SaveChanges();
                return View("RegistrationSuccess");
              
            }
            ModelState.AddModelError("","Please update the Highlighted mandatory fields");
            return RedirectToAction("Register", "Account");
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexUser(User u)
        {
            return View(u);
        }
    }
    }
