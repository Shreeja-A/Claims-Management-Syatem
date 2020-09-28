using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        UserContext context = new UserContext();
        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult ApprovalList()
        {
            var users = (from user in context.Users
                                  join credential in context.UserCredentials
                                  on user.User_Id equals credential.UserId
                                  where credential.ApprovalStatus == 0
                                  select user).ToList();
            return View(users);
        }


        public ActionResult Approve(string id)
        {
            UserCredential user = context.UserCredentials.Where(c=>c.UserId == id).SingleOrDefault();
            user.ApprovalStatus = 1; //approve
            context.SaveChanges();
            return View("Approve",user);

        }
        public ActionResult Reject(string id)
        {
            UserCredential user = context.UserCredentials.Where(c => c.UserId == id).SingleOrDefault();
            user.ApprovalStatus = 2; //reject
            context.SaveChanges();
            return View("Reject", user);

        }
        public ActionResult ClaimList()
        {
            var users = (from claim in context.Claims
            join credential in context.UserCredentials
            on claim.UserId equals credential.UserId
             where claim.ClaimStatus == 0
             select claim).ToList();
             return View(users);
            
        }
        public ActionResult ApproveClaim(string id)
        {
            Claim claim = context.Claims.Where(c => c.ClaimId == id).SingleOrDefault();
            claim.ClaimStatus = 1; //approve
            context.SaveChanges();
            return View("ApproveClaim", claim);

        }
        [HttpGet]
        public ActionResult RejectClaim(string id)
        {
            Claim claim = context.Claims.Where(c => c.ClaimId == id).SingleOrDefault();
            claim.ClaimStatus = 2; // reject
            context.SaveChanges();
            return View("RejectClaim", claim);

        }

        [HttpPost]
        public ActionResult RejectClaim(Claim claim)
        {
            Claim c = context.Claims.Find(claim.ClaimId);
            c.Comments = claim.Comments;
            context.SaveChanges();
            return RedirectToAction("ClaimList");

        }
        public ActionResult ProcessedClaims()
       {
            var users = (from claim in context.Claims
                         join credential in context.UserCredentials
                         on claim.UserId equals credential.UserId
                         where claim.ClaimStatus == 1
                         select claim).ToList();
            return View(users);

        }

        public ActionResult UserDetails(string Id )
        {
            var users = context.Users.Where(t => t.User_Id == Id).FirstOrDefault();
            return View("UserDetails", users);

        }
       

    }
}
