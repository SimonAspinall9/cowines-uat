namespace Website.CoWines.Models
{
    using DAL;
    using Enums;
    using System;
    using System.Linq;
    using System.Net.Mail;

    public class ContactFormDetails
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        private string _toAddress;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddres { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToAddress
        {
            get
            {
                if (_toAddress != null) return _toAddress;

                _toAddress = (from e in _dbContext.EmailAddresses
                              where e.Name.Equals(EmailTypes.ToAddress.ToString()) && e.IsActive
                              select e.Email).FirstOrDefault();
                return _toAddress;
            }
        }

        public ContactFormDetails(string firstName, string lastName, string emailAddress, string subject, string body)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddres = emailAddress;
            Subject = subject;
            Body = body;
        }

        public void SendContactForm()
        {
            try
            {
                var mailMessage = new MailMessage(EmailAddres, ToAddress)
                {
                    Subject = Subject,
                    Body = GenerateEmailBody(),
                };

                var smtpClient = new SmtpClient
                {
                    Host = "",
                    Port = 25,
                };

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send mail message. See inner exception for more details.", new Exception(ex.Message));
            }
        }

        private string GenerateEmailBody()
        {
            var emailBody = string.Format("Hello,\n{0}\n\nThank,\n{1} {2}", Body, FirstName, LastName);

            return emailBody;
        }
    }
}
