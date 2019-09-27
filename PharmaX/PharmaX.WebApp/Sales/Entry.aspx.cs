using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Sales
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
                LoadSalesOrder();
                ItemsDropDownList.Items.Insert(0, new ListItem("None of Items", "0"));
                txtAmount.Text = "1000";
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
        public void GridviewRowSum()
        {
            decimal TotalAMount = 0;
            foreach (GridViewRow row in SalesGridView.Rows)
            {

                TotalAMount = TotalAMount + Convert.ToDecimal(row.Cells[5].Text); //Where Cells is the column. Just changed the index of cells
            }
            txtAmount.Text = TotalAMount.ToString();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCustomerContact.Text!=null && CategoriesDropDownList.SelectedIndex>0 && ItemsDropDownList.SelectedIndex>0 && txtQty.Text!=null)
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
                            GridviewRowSum();
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
                    GridviewRowSum();
                }

            }
            catch
            {
 
            }
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalamount = Convert.ToDecimal(txtAmount.Text);
                decimal discountamount = Convert.ToDecimal(txtDiscount.Text);

                decimal cal = totalamount - discountamount;

                txtGrandTotal.Text = cal.ToString();
            }
            catch { }

        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandtotal = Convert.ToDecimal(txtGrandTotal.Text);
                decimal Paidamount = Convert.ToDecimal(txtPaidAmount.Text);

                if (Paidamount >= grandtotal)
                {
                    decimal cal = Paidamount - grandtotal;
                    txtChanges.Text = cal.ToString();
                    txtRemainingDue.Text = "00";
                }
                else
                {
                    decimal cal = grandtotal - Paidamount;
                    txtChanges.Text = "00";
                    txtRemainingDue.Text = cal.ToString();
                }
            }
            catch { }

        }
        protected void SaleSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Sale _Sales = new Sale();
                _Sales.CustomerContact = txtCustomerContact.Text;
                _Sales.SalesId = txtSalesId.Text;
                _Sales.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                _Sales.Discount = Convert.ToDecimal(txtDiscount.Text);
                _Sales.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                _Sales.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                _Sales.Changes = Convert.ToDecimal(txtChanges.Text);
                _Sales.RemainingDue = Convert.ToDecimal(txtRemainingDue.Text);
                if(_Sales.RemainingDue > 0)
                {
                    _Sales.Status = "Due";
                }
                else
                {
                    _Sales.Status = "Paid";
                }
                _Sales.Date = txtDate.Text;

                int success = _SalesRepository.SalesSubmit(_Sales);
                if(success > 0)
                {
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Submit');", true);
                }

            }
            catch { }
        }
    }
}