using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Item
{
    public partial class Setup : System.Web.UI.Page
    {
        ItemRepository _ItemRepository = new ItemRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllCategories();
                GetAllShelfs();
                AutoCodeGenerate();
            }
        }
        public void GetAllCategories()
        {
            CategoriesDropDownList.DataSource = _ItemRepository.GetAllCategories();
            CategoriesDropDownList.DataTextField = "Name";
            CategoriesDropDownList.DataValueField = "Id";
            CategoriesDropDownList.DataBind();

            CategoriesDropDownList.Items.Insert(0, new ListItem("Chose Category", "0"));
        }
        public void GetAllShelfs()
        {
            ShelfsDropDownList.DataSource = _ItemRepository.GetAllShelfs();
            ShelfsDropDownList.DataTextField = "Name";
            ShelfsDropDownList.DataValueField = "Id";
            ShelfsDropDownList.DataBind();

            ShelfsDropDownList.Items.Insert(0, new ListItem("Chose Shelfs", "0"));
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _ItemRepository.AlreadyExistData();
            int code = 101;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _ItemRepository.GetLastCode();
                if (GetLastCode != null)
                {
                    code = Convert.ToInt32(GetLastCode.Code);
                    code++;
                }
                txtCode.Text = code.ToString("000");
            }
            else
            {
                txtCode.Text = "101";
            }
        }
        decimal StoreQty;
        public void GetStoreQtyByShelfs()
        {
            try
            {
                int Id = Convert.ToInt32(ShelfsDropDownList.SelectedValue);
                var getQTY = _ItemRepository.GetQtyByShelfs(Id);
                if (getQTY != null)
                {
                    lblStoreQty.Text ="Store Of Qty : "+ Convert.ToInt32(getQTY.StoreQty).ToString();
                    StoreQty = (getQTY.StoreQty);
                }
            }
            catch
            {
            }
        }

        protected void ShelfsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStoreQtyByShelfs();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(ShelfsDropDownList.SelectedValue);

                decimal totalqtyByshelfs = _ItemRepository.GetTotalStoreByShelfs(Id);
                
                if (totalqtyByshelfs <= StoreQty)
                {
                    lblmsg.Text = "Work yes";
                }
                else
                {
                    lblmsg.Text = "Work no";
                }
            }
            catch(Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }
}