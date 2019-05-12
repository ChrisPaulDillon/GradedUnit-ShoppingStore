using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Manage_Users_UserManagement : System.Web.UI.Page
{
    Shop myShop;
    Staff staffMember;

     protected void Page_Load(object sender, EventArgs e)
     {
         if ((string)Session["UserType"] == "Administrator")
         {
             myShop = (Shop)Session["myShop"];
             staffMember = (Staff)Session["staffMember"];
             string username = Convert.ToString(Request.QueryString["Username"]);
             string typeOfMember = Convert.ToString(Request.QueryString["Type"]); 

             //If a customer is being requested to be deleted
             if (username != null && typeOfMember == "Customer") 
             {
                 Customer deletedCustomer = (Customer)myShop.getCustomer(username); 
                 myShop.removeCustomer(username);
                 Response.Redirect("~/Manage/Users/UserManagement.aspx");
             }
             //If a staff member is being requested to be deleted
             if (username != null && typeOfMember == "Staff") 
             {

                 Staff deletedStaffMember = (Staff)myShop.getStaff(username);
                 myShop.removeStaffMember(username);
                 Response.Redirect("~/Manage/Users/UserManagement.aspx");
             }

             //If no search input & customers is selected
             if (txtSearch.Text == "" && ddlUsers.SelectedValue == "Customers") 
             {
                 gvUsers.Columns[1].Visible = false;
                 gvUsers.Columns[7].Visible = false;
                 gvUsers.Columns[8].Visible = true;
                 gvUsers.Columns[9].Visible = false;
                 gvUsers.DataSource = myShop.ShopCustomers;
                 gvUsers.DataBind();
             }
             //If the user is searching customers
             if (txtSearch.Text != "" && ddlUsers.SelectedValue == "Customers")
             {
                 gvUsers.Columns[1].Visible = false;
                 gvUsers.Columns[7].Visible = false;
                 gvUsers.Columns[8].Visible = true;
                 gvUsers.Columns[9].Visible = false;
                 gvUsers.DataSource = myShop.searchCustomers(txtSearch.Text);
                 gvUsers.DataBind();
             }

             //If no search input & staff is selected
             if (txtSearch.Text == "" && ddlUsers.SelectedValue == "Staff") 
             {
                 gvUsers.Columns[1].Visible = true;
                 gvUsers.Columns[6].Visible = false;
                 gvUsers.Columns[7].Visible = true;
                 gvUsers.Columns[8].Visible = false;
                 gvUsers.Columns[9].Visible = true;
                 gvUsers.DataSource = myShop.ShopStaff;
                 gvUsers.DataBind();
             }

             if (txtSearch.Text != "" && ddlUsers.SelectedValue == "Staff")
             {
                 gvUsers.Columns[1].Visible = true;
                 gvUsers.Columns[6].Visible = false;
                 gvUsers.Columns[7].Visible = true;
                 gvUsers.Columns[8].Visible = false;
                 gvUsers.Columns[9].Visible = true;
                 gvUsers.DataSource = myShop.searchStaff(txtSearch.Text);
                 gvUsers.DataBind();
             }

         }
         else
         {
             Response.Redirect("~/Account/Login.aspx");
         }
     }

     protected void btnAddCustomer_Click(object sender, EventArgs e)
     {
         Response.Redirect("~/Manage/Users/AddUser.aspx?Type=Customer");
     }

     protected void btnAddStaff_Click(object sender, EventArgs e)
     {
         Response.Redirect("~/Manage/Users/AddUser.aspx?Type=Staff");
     }

     protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
     {
      
        if (ddlUsers.SelectedValue == "Customers")
        {
            gvUsers.Columns[1].Visible = false;
            gvUsers.Columns[7].Visible = false;
            gvUsers.Columns[6].Visible = true;
            gvUsers.Columns[8].Visible = true;
            gvUsers.Columns[9].Visible = false;
            gvUsers.DataSource = myShop.ShopCustomers;
            gvUsers.DataBind();
 
        }

        if (ddlUsers.SelectedValue == "Staff")
        {
            gvUsers.Columns[1].Visible = true;
            gvUsers.Columns[6].Visible = false;
            gvUsers.Columns[7].Visible = true;
            gvUsers.Columns[8].Visible = false;
            gvUsers.Columns[9].Visible = true;
            gvUsers.DataSource = myShop.ShopStaff;
            gvUsers.DataBind();
        }
    
    }
}