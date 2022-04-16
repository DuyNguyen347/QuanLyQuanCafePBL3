using EmailValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    public class CheckEmail
    {
        private static CheckEmail _Instance;

        public static CheckEmail Instance {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new CheckEmail();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public bool Check(string mail)
        {
            bool check = false;
            EmailValidator emailValidator = new EmailValidator();
            EmailValidationResult result;
            //if (!emailValidator.Validate(mail, out result))
            //{
            //    //Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
            //    MessageBox.Show("Không thể kiểm tra email");
            //}
            emailValidator.Validate(mail, out result);
            switch (result)
            {
                case EmailValidationResult.OK:
                    //MessageBox.Show("Email tồn tại");
                    check = true;
                    break;

                case EmailValidationResult.MailboxUnavailable:
                    break;

                    //case EmailValidationResult.MailboxStorageExceeded:
                    //    MessageBox.Show("Mailbox overflow");
                    //    //Console.WriteLine("Mailbox overflow");
                    //    break;

                    //case EmailValidationResult.NoMailForDomain:
                    //    MessageBox.Show("Emails are not configured for domain(no MX records)");
                    //    //Console.WriteLine("Emails are not configured for domain (no MX records)");
                    //    break;
            }
            return check;
        }
    }
}
