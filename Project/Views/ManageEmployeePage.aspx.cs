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
    public partial class ManageEmployeePage : System.Web.UI.Page
    {
        MsEmployeeController MsEmployeeController = new MsEmployeeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Result result = MsEmployeeController.ReadAll();
                    GridViewEmployee.DataSource = (List<MsEmployee>)result.Data;
                    GridViewEmployee.DataBind();
                }
                catch
                {
                    Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void GridViewEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridViewEmployee.Rows[index];
            Guid ID = Guid.Parse(row.Cells[2].Text.ToString());

            switch (e.CommandName)
            {
                case "Update":
                    HttpContext.Current.Response.Redirect("/Views/ManageEmployeeUpdatePage.aspx?ID=" + ID);
                    break;
                case "Delete":
                    try
                    {
                        Result result = MsEmployeeController.DeleteOneByID(ID);
                        HttpContext.Current.Response.Redirect("/Views/ManageEmployeePage.aspx");
                    }
                    catch
                    {
                        // HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                    }
                    break;
                default:
                    Response.Redirect("/Views/ErrorPage.aspx");
                    break;
            }
        }
    }
}