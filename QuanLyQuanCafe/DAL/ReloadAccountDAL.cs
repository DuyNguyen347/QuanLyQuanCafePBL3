using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    public class ReloadAccountDAL
    {
        private static ReloadAccountDAL _Instance;

        public static ReloadAccountDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReloadAccountDAL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public bool Reload(string email)
        {
            string q = "select * from dbo.NhanVien where Email = N'" + email + "'";
            DataTable dt = DataProvider.Instance.GetRecords(q);
            return dt.Rows.Count > 0;
        }
        private static readonly string _from = "duynguyen347.study@gmail.com"; // Email của Sender (của bạn)
        private static readonly string _pass = "16112002study"; // Mật khẩu Email của Sender (của bạn)
        public bool Send(string sendto, string subject, string content)
        {
            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin l�-i
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(_from);
                mail.To.Add(sendto);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = content;

                mail.Priority = MailPriority.High;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public string sendcode(string gmail, int i)
        {
            string a;
            if (i == 0) a = "Mã Code lấy tài khoản";
            else a = "Mật khẩu của bạn là: ";
            Random generator = new Random();
            string str = generator.Next(0, 100000).ToString("D6");
            if (ReloadAccountDAL.Instance.Send(gmail, a, str))
            {
                MessageBox.Show("Mã Code vừa được gửi đến Mail vừa nhập!");
            }
            else MessageBox.Show("Có lỗi trong quá trình gửi mã CODE !");
            return str;
        }
    }
}
