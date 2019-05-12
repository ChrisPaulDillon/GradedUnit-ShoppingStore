using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Contact : Page
{
    Customer customerMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType"] != null)
        {
            customerMember = (Customer)Session["customerMember"];
        }
    }

    public void sendContactEnquiry(string subject, string email, string bodyIn)
    {
        var fromAddress = email;// Email Address
        var toAddress = "opencomputingsupplies@gmail.com";
        const string fromPassword = "ocspass1";//Password


        string body = "From: " + email;


        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        smtp.Send(fromAddress, toAddress, subject, body);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtSubject.Text == "" || txtEmail.Text == "" || txtBody.Text == "")
        {
            lblMessage.Text = "Please fill out all forms";
        }
        else if (txtBody.Text.Length < 10)
        {
            lblMessage.Text = "Body length should be at least 10 characters";
        }
        else
        {
            //Sends email using the form the user has filled out
            sendContactEnquiry(txtSubject.Text, txtEmail.Text, txtBody.Text);
        }
    }
}