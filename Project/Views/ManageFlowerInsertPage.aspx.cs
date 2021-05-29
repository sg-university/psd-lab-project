using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Factory;
using Project.Models;

namespace Project.Views
{
    public partial class ManageFlowerInsertPage : System.Web.UI.Page
    {
        readonly MsFlowerController MsFlowerController = new MsFlowerController();
        readonly MsFlowerTypeController MsFlowerTypeController = new MsFlowerTypeController();
        readonly MsFlowerFactory MsFlowerFactory = new MsFlowerFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Result resultAllFlowerType = MsFlowerTypeController.ReadAll();
                    List<MsFlowerType> type = (List<MsFlowerType>)resultAllFlowerType.Data;
                    DropDownListType.DataSource = type;
                    DropDownListType.DataTextField = "FlowerTypeName";
                    DropDownListType.DataValueField = "FlowerTypeID";
                    DropDownListType.DataBind();
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            String name = TextBoxName.Text.ToString();
            Guid typeID = Guid.Empty;
            Guid.TryParse(DropDownListType.SelectedValue.ToString(), out typeID);
            String description = TextBoxDescription.Text.ToString();
            Decimal price = 0;
            Decimal.TryParse(TextBoxPrice.Text.ToString(), out price);
            String imageFile = FileUploadImage.FileName;
            String imageFileName = Guid.NewGuid().ToString();
            String imageFileExtention = System.IO.Path.GetExtension(imageFile);

            String toSaveImage = "~/Assets/Images/" + imageFileName + imageFileExtention;

            MsFlower toCreateMsFlower = MsFlowerFactory.Create(name, typeID, description, price, toSaveImage);

            if (String.IsNullOrEmpty(FileUploadImage.FileName))
            {
                LabelMessageStatus.Text = "Image must be filled";
                return;
            }

            Result result = MsFlowerController.CreateOne(toCreateMsFlower);

            if (result.SuccessCode != null)
            {
                LabelMessageStatus.Text = result.SucessMessage.ToString();
            }
            if (result.ErrorCode != null)
            {
                LabelMessageStatus.Text = result.ErrorMessage.ToString();
                return;
            }

            FileUploadImage.SaveAs(Server.MapPath(toSaveImage));
        }
    }
}