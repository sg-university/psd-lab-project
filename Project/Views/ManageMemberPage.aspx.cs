using Project.Controllers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class ManageMemberPage : System.Web.UI.Page
    {
        MsMemberController MsMemberController = new MsMemberController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Result result = MsMemberController.ReadAll();
                    GridViewMember.DataSource = (List<MsMember>)result.Data;
                    GridViewMember.DataBind();
                }
                catch
                {
                    Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void GridViewMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridViewMember.Rows[index];
            Guid ID = Guid.Parse(row.Cells[2].Text.ToString());

            switch (e.CommandName)
            {
                case "Update":
                    HttpContext.Current.Response.Redirect("/Views/ManageMemberUpdatePage.aspx?ID=" + ID);
                    break;
                case "Remove":
                    try
                    {
                        Result result = MsMemberController.DeleteOneByID(ID);
                        HttpContext.Current.Response.Redirect("/Views/ManageMemberPage.aspx");
                    }
                    catch
                    {
                        HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                    }
                    break;
                default:
                    Response.Redirect("/Views/ErrorPage.aspx");
                    break;
            }
        }
    }
}