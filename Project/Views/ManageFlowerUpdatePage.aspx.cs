using Project.Controllers;
using Project.Factory;
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
    public partial class ManageFlowerUpdatePage : System.Web.UI.Page
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

                    Guid ID = Guid.Parse(Request["ID"].ToString());
                    Result result = MsFlowerController.ReadOneByID(ID);
                    MsFlower currentMsFlower = (MsFlower)result.Data;
                    TextBoxName.Text = currentMsFlower.FlowerName.ToString();
                    DropDownListType.SelectedValue = currentMsFlower.FlowerTypeID.ToString();
                    TextBoxDescription.Text = currentMsFlower.FlowerDescription.ToString();
                    TextBoxPrice.Text = currentMsFlower.FlowerPrice.ToString();
                    //FileUploadImage.FileName = currentMsFlower.FlowerImage.ToString()
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Guid ID = Guid.Empty;
            Guid.TryParse(HttpContext.Current.Request["ID"].ToString(), out ID);

            Result resultCurrent = MsFlowerController.ReadOneByID(ID);
            MsFlower currentMsFlower = (MsFlower)resultCurrent.Data;

            String name = TextBoxName.Text.ToString();
            Guid typeID = Guid.Empty;
            Guid.TryParse(DropDownListType.SelectedValue.ToString(), out typeID);
            String description = TextBoxDescription.Text.ToString();
            Decimal price = 0;
            Decimal.TryParse(TextBoxPrice.Text.ToString(), out price);
            String imageFile = currentMsFlower.FlowerImage;
            String imageFileName = Path.GetFileNameWithoutExtension(imageFile);
            String imageFileExtention = Path.GetExtension(imageFile);

            if (File.Exists(imageFile))
            {
                File.Delete(imageFile);
            }

            String toSaveImage = "~/Assets/Images/" + imageFileName + imageFileExtention;

            MsFlower toUpdateMsFlower = MsFlowerFactory.Create(name, typeID, description, price, toSaveImage);

            Result result = MsFlowerController.UpdateOneByID(ID, toUpdateMsFlower.FlowerName, toUpdateMsFlower.FlowerTypeID.GetValueOrDefault(), toUpdateMsFlower.FlowerImage, toUpdateMsFlower.FlowerDescription, toUpdateMsFlower.FlowerPrice.GetValueOrDefault());

            if (result.SuccessCode != null)
            {
                LabelMessageStatus.Text = result.SucessMessage.ToString();
            }
            if (result.ErrorCode != null)
            {
                LabelMessageStatus.Text = result.ErrorMessage.ToString();
                return;
            }
            if (String.IsNullOrEmpty(FileUploadImage.FileName))
            {
                LabelMessageStatus.Text = "Image must be filled";
                return;
            }

            FileUploadImage.SaveAs(Server.MapPath(toSaveImage));
        }
    }
}
