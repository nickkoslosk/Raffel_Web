using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.ScopeAndRev.Revisions
{
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public Email Message { get; set; }
        public Projects Project { get; set; }
        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string LEAD_NUMBER)

        {
            LEAD = LEAD_NUMBER;
            return Page();
        }

        [BindProperty]
        public Revision Revision { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Project = await _context.Projects.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD));
            if (!ModelState.IsValid)
            {
                return Page();
            }
            using (var smtp = new SmtpClient())
            {
                //smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                // smtp.PickupDirectoryLocation = @"c:\maildump";
                string newLine = Environment.NewLine;
                var message = new MailMessage
                {

                    Body = 
                    "Project Name: " + Revision.REV_DETAILS + newLine +
                    "Original Scope: " + Revision.LEAD_NUMBER + newLine +
                    "Date of Request: " + Revision.ENTERED_BY + newLine +
                    "CONNECTIONS: " + Revision.DATE_ENTERED + newLine,
                    Subject = "new Revision for " + Revision.LEAD_NUMBER,
                    From = new MailAddress("DoNotReply@NewRev.com")
                };
                        switch (Project.EE_LEAD.ToLower())
                        {
                            case "collaer":
                                message.To.Add("ICOLLAER@RAFFEL.COM");
                                break;
                            case "rink":
                                message.To.Add("CRINK@RAFFEL.COM");
                                break;
                            case "klepps":
                                message.To.Add("DKLEPPS@RAFFEL.COM");
                                break;
                            case "li":
                                message.To.Add("PLI@RAFFEL.COM");
                                break;
                            case "nowak":
                                message.To.Add("ENOWAK@RAFFEL.COM");
                                break;
                            case "saul":
                                message.To.Add("JSAUL@RAFFEL.COM");
                                break;
                            case "kosloski":
                                message.To.Add("NKOSLOSKI@RAFFEL.COM");
                                break;
                            case "mazur":
                                message.To.Add("AMAZUR@RAFFEL.COM");
                                break;
                            case "meythaler":
                                message.To.Add("NMEYTHALER@RAFFEL.COM");
                                break;
                            case "shultz":
                                message.To.Add("CSCHULTZ@RAFFEL.COM");
                                break;
                            default:
                                message.Body = "message assigned to non-existant, or mispelled EE: " + Project.EE_LEAD;
                                message.To.Add("NKOSLOSKI@RAFFEL.COM");
                                break;
                        }
                message.To.Add("pli@raffel.com");
                message.To.Add("jsaul@raffel.com");
                message.To.Add("jmalinowski@raffel.com");
                message.To.Add("rweeden@raffel.com");
                smtp.UseDefaultCredentials = false;
               
                smtp.Host = "email.weimerbearing.com";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                
            }

            _context.Revision.Add(Revision);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ProjectView/ProjectCard/ScopeAndRev/Index", new { Revision.LEAD_NUMBER });
        }
    }
}