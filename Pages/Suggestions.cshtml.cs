using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView
{
    [Authorize]
    public class SuggestionsModel : PageModel
    {
        [BindProperty]
        public Email Message { get; set; }



        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPost()
        {
            using (var smtp = new SmtpClient())
            {
                //smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                // smtp.PickupDirectoryLocation = @"c:\maildump";
                var message = new MailMessage
                {

                    Body = Message.Body,
                    Subject = Message.Subject,
                    From = new MailAddress("DoNotReply@raffelSugg.com")
                };

                // message.To.Add(new MailAddress("nkosloski@raffel.com"));
                message.To.Add("nkosloski@raffel.com");
                smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("nkosloski", "TNtnot11", "raffel.com");
                smtp.Host = "email.weimerbearing.com";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");
            }
        }
        //return View(model);
    }
}