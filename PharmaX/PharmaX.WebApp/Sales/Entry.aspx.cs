using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Sale
{
    public partial class Entry : System.Web.UI.Page
    {
        SalesRepository _SalesRepository = new SalesRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoGenerateSalesId();
                GetAllCategories();
                ItemsDropDownList.Items.Insert(0, new ListItem("None of Items", "0"));
            }
        }
        public void AutoGenerateSalesId()
        {
            decimal AlreadyExistData = _SalesRepository.AlreadyExistData();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _SalesRepository.GetLastPurchaseId();
                if (GetLastCode != null)
                {
                    code = Convert.ToInt32(GetLastCode.SalesId);
                    code++;
                }
                txtSalesId.Text = code.ToString("0000");
            }
            else
            {
                txtSalesId.Text = "0001";
            }
        }
        public void GetAllCategories()
        {
            CategoriesDropDownList.DataSource = _SalesRepository.GetAllCategories();
            CategoriesDropDownList.DataTextField = "Name";
            CategoriesDropDownList.DataValueField = "Id";
            CategoriesDropDownList.DataBind();

            CategoriesDropDownList.Items.Insert(0, new ListItem("Chose Category", "0"));
        }
        protected void CategoriesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(CategoriesDropDownList.SelectedValue);

                ItemsDropDownList.DataSource = _SalesRepository.GetAllItemsByCategories(id);
                ItemsDropDownList.DataTextField = "Name";
                ItemsDropDownList.DataValueField = "Code";
                ItemsDropDownList.DataBind();

                ItemsDropDownList.Items.Insert(0, new ListItem("Chose Items", "0"));
            }
            catch
            {

            }
        }
        public void GetPriceAndStock()
        {
            lblStock.Text = "";

            string name = ItemsDropDownList.SelectedItem.ToString();
            decimal totalpurchaseqty = _SalesRepository.TotalQtyPurchaseByItems(name);
            decimal totalsalesqty = _SalesRepository.TotalQtySalesByItems(name);

            decimal stock = totalpurchaseqty - totalsalesqty;

            lblStock.Text = stock.ToString();
        }
        public void GetSellingPrice()
        {
            lblSellingPrice.Text = "";
            string name = ItemsDropDownList.SelectedItem.ToString();

            var SellingPrice = _SalesRepository.GetSellingPrice(name);
            if (SellingPrice != null)
            {
                lblSellingPrice.Text = SellingPrice.SellingPrice.ToString();

            }
        }
        protected void ItemsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSellingPrice();
            GetPriceAndStock();
        }
        public void LoadSalesOrder()
        {
            string Id = txtSalesId.Text;
            SalesGridView.DataSource = _SalesRepository.GetSalesOrderById(Id);
            SalesGridView.DataBind();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(CategoriesDropDownList.SelectedIndex>0 && ItemsDropDownList.SelectedIndex>0 && txtQty.Text!=null)
                {
                    if(Convert.ToDecimal(lblStock.Text) >= Convert.ToDecimal(txtQty.Text))
                    {
                        SaleDetails _SaleDetails = new SaleDetails();
                        _SaleDetails.CustomerContact = txtCustomerContact.Text;
                        _SaleDetails.Item = ItemsDropDownList.SelectedItem.ToString();
                        _SaleDetails.Unit = Convert.ToDecimal(lblSellingPrice.Text);
                        _SaleDetails.Qty = Convert.ToDecimal(txtQty.Text);
                        _SaleDetails.Total = Convert.ToDecimal(lblSellingPrice.Text) * Convert.ToDecimal(txtQty.Text);
                        _SaleDetails.SalesId = txtSalesId.Text;

                        int success = _SalesRepository.Add(_SaleDetails);
                        if(success>0)
                        {
                            LoadSalesOrder();
                            
                            ItemsDropDownList.ClearSelection();
                            lblSellingPrice.Text = "";
                            lblStock.Text = "";
                            txtQty.Text = "";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Added');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Check Your Stock');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Check All formality');", true);
                }
            }
            catch { }
        }
        protected void SalesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                 
                int Id = Convert.ToInt32(SalesGridView.DataKeys[e.RowIndex].Value.ToString());

                int deletesuccess = _SalesRepository.Delete(Id);
                if (deletesuccess > 0)
                {
                    LoadSalesOrder();
                }

            }
            catch
            {
 
            }
        }
    }
}