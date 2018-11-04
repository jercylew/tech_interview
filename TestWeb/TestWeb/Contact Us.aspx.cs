using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TestWeb
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Send the Email
            m_lblSendStatus.Text = "";

            string strFromEmail = m_txtFrom.Text;
            if (string.IsNullOrEmpty(strFromEmail) || string.IsNullOrWhiteSpace(strFromEmail))
            {
                m_lblSendStatus.ForeColor = System.Drawing.Color.Red;
                m_lblSendStatus.Text = "From address cannot be empty!";

                return;
            }

            string strContent = m_txtContent.Text;
            MailMessage mailMsg = new MailMessage();

            //Setting From , To, Sender
            mailMsg.From = new MailAddress(strFromEmail, "Jercy Liu");
            mailMsg.Subject = "Realizing Value from IT Investment";
            mailMsg.Sender = new MailAddress("web@reasonables.com");
            mailMsg.To.Add(new MailAddress("hr@reasonables.com"));
            mailMsg.Body = strContent;

            SmtpClient smtpClient = new SmtpClient("localhost", 25);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Credentials = new System.Net.NetworkCredential("admin", "password");
            //smtpClient.UseDefaultCredentials = true; //For using logged user to be authenticated
            //smtpClient.EnableSsl = true; //Use SSL to send email

            try
            {
                smtpClient.Send(mailMsg);
                m_lblSendStatus.ForeColor = System.Drawing.Color.Green;
                m_lblSendStatus.Text = "Send successfully";
            }
            catch (SmtpException smtpException)
            {
                m_lblSendStatus.ForeColor = System.Drawing.Color.Red;
                m_lblSendStatus.Text = "Send failed!";
                //MessageBox.Show("Failed to send this Email: " + smtpException.ToString());
            }
            catch (Exception exception)
            {
                m_lblSendStatus.ForeColor = System.Drawing.Color.Red;
                m_lblSendStatus.Text = "Send failed!";
                //MessageBox.Show("Unknow exception caught.");
            }
            
        }
    }
}