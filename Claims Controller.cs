using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ClaimsController : Controller
    {
        // GET: Claims
        UserContext context = new UserContext();
        public ActionResult ClaimRequest()
        {

            Claim u = new Claim();
            u.UserId = User.Identity.Name;
            var id = context.Claims.Max(c => c.Id);
            id = id + 1;
            string Id = "CMS" + DateTime.Now.Year + id.ToString();
            u.ClaimId = Id;
            return View(u);
        }

        [HttpPost]
        public ActionResult ClaimRequest(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimStatus = 0;
                context.Claims.Add(claim);
                context.SaveChanges();
                return View("ClaimRequestSuccess");
            }
            ModelState.AddModelError("", "Please update the Highlighted mandatory fields");
            return RedirectToAction("ClaimRequest", "Claims");

        }
        public ActionResult MyClaims()
        {
            var Id= User.Identity.Name;
            var claims = context.Claims.Where(t => t.UserId == Id).ToList();
            return View(claims);
        }
    }
}
