using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUmbraco.Models;
using System.Net.Mail;
using System.Net;


    public class ContactController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult SendMail(Contact form)
        {
            string retValue = "There was an error submitting the form, please try again later.";
            if (!ModelState.IsValid)
            {
                return Content(retValue);
            }

            if (ModelState.IsValid)
            {
            //Save to DB
            var db = ApplicationContext.DatabaseContext.Database;
            db.Save(form);
            
                //Update your SMTP server credentials
                using (var client = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true, 
                    Credentials = new NetworkCredential("account@gmail.com", "password"), 
                    DeliveryMethod = SmtpDeliveryMethod.Network})
                {
                    var mail = new MailMessage();
                    mail.To.Add("account@gmail.com"); // Update your email address
                    mail.From = new MailAddress(form.Email, form.Name);
                    mail.Subject = String.Format("Request to Contact from {0}", form.CompanyName);
                    mail.Body = form.Message;
                    mail.IsBodyHtml = false;
                    try 
                    {            
                        client.Send(mail);
                        retValue = "Your Request for Contact was submitted successfully. We will contact you shortly.";
                    }
                    catch (Exception)
                    {
        
                        throw;
                    }
                }
            }
            return Content(retValue);
        }
    }
