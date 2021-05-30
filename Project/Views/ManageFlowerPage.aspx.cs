using Project.Controllers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class ManageFlowerPage1 : System.Web.UI.Page
    {
        MsFlowerController MsFlowerController = new MsFlowerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Result result = MsFlowerController.ReadAll();
                    GridViewFlower.DataSource = (List<MsFlower>)result.Data;
                    GridViewFlower.DataBind();
                }
                catch
                {
                    Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void GridViewFlower_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridViewFlower.Rows[index];
            Guid ID = Guid.Parse(row.Cells[2].Text.ToString());

            switch (e.CommandName)
            {
                case "Update":
                    HttpContext.Current.Response.Redirect("/Views/ManageFlowerUpdatePage.aspx?ID=" + ID);
                    break;
                case "Remove":
                    try
                    {
                        Result result = MsFlowerController.DeleteOneByID(ID);
                        MsFlower currentMsFlower = (MsFlower)result.Data;
                        if (File.Exists(currentMsFlower.FlowerImage))
                        {
                            File.Delete(currentMsFlower.FlowerImage);
                        }
                        HttpContext.Current.Response.Redirect("/Views/ManageFlowerPage.aspx");
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