using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Purchase
{
    public partial class Entry : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllCategories();
                GetAllSuppliers();
                ItemsDropDownList.Items.Insert(0, new ListItem("None of Items", "0"));
                txtPurchaseCode.Text = "001";
            }
        }
        public void GetAllSuppliers()
        {
            SuppliersDropDownList.DataSource = _PurchaseRepository.GetAllSupplliers();
            SuppliersDropDownList.DataTextField = "Name";
            SuppliersDropDownList.DataValueField = "Id";
            SuppliersDropDownList.DataBind();

            SuppliersDropDownList.Items.Insert(0, new ListItem("Chose Supplier", "0"));
        }
        public void GetAllCategories()
        {
            CategoriesDropDownList.DataSource = _PurchaseRepository.GetAllCategories();
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

                ItemsDropDownList.DataSource = _PurchaseRepository.GetAllItemsByCategories(id);
                ItemsDropDownList.DataTextField = "Name";
                ItemsDropDownList.DataValueField = "Code";
                ItemsDropDownList.DataBind();

                ItemsDropDownList.Items.Insert(0, new ListItem("Chose Items", "0"));
            }
            catch
            {

            }

        }
        public void AddPurchaseItems()
        {
            //string serial;
            //serial = txtSerial.Text;

            //ItemSalesGridView.DataSource = _ItemSalesRepository.GetAllSaleItems(serial);
            //ItemSalesGridView.DataBind();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Batch", typeof(int));
            dataTable.Columns.Add("Qty", typeof(decimal));
            dataTable.Columns.Add("CostPrice", typeof(decimal));
            dataTable.Columns.Add("SellingPrice", typeof(decimal));
            dataTable.Columns.Add("Expire", typeof(string));
            DataRow dr = null;
            var data = (DataTable)ViewState["Details"];
            if (data != null)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataTable = (DataTable)ViewState["Details"];
                    if (dataTable.Rows.Count > 0)
                    {
                        dr = dataTable.NewRow();
                        dr["Item"] = ItemsDropDownList.SelectedItem.ToString();
                        dr["Batch"] = txtBatch.Text;
                        dr["Qty"] = txtQty.Text;
                        dr["CostPrice"] = txtCostPrice.Text;
                        dr["SellingPrice"] = txtSellingPrice.Text;
                        dr["Expire"] = txtExpire.Text;

                        dataTable.Rows.Add(dr);

                        PurchaseGridView.DataSource = dataTable;
                        PurchaseGridView.DataBind();
                    }
                    else
                    {
                        dr = dataTable.NewRow();
                        dr["Item"] = ItemsDropDownList.SelectedItem.ToString();
                        dr["Batch"] = txtBatch.Text;
                        dr["Qty"] = txtQty.Text;
                        dr["CostPrice"] = txtCostPrice.Text;
                        dr["SellingPrice"] = txtSellingPrice.Text;
                        dr["Expire"] = txtExpire.Text;

                        dataTable.Rows.Add(dr);

                        PurchaseGridView.DataSource = dataTable;
                        PurchaseGridView.DataBind();

                    }
                }
            }
            else
            {
                dr = dataTable.NewRow();
                dr["Item"] = ItemsDropDownList.SelectedItem.ToString();
                dr["Batch"] = txtBatch.Text;
                dr["Qty"] = txtQty.Text;
                dr["CostPrice"] = txtCostPrice.Text;
                dr["SellingPrice"] = txtSellingPrice.Text;
                dr["Expire"] = txtExpire.Text;

                dataTable.Rows.Add(dr);

                PurchaseGridView.DataSource = dataTable;
                PurchaseGridView.DataBind();
            }
            ViewState["Details"] = dataTable;
            ItemsDropDownList.ClearSelection();
            txtBatch.Text = "";
            txtQty.Text = "";
            txtCostPrice.Text = "";
            txtSellingPrice.Text = "";
            txtExpire.Text = "";

        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            AddPurchaseItems();
        }
        protected void PurchaseGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void PurchaseGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void PurchaseGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void PurchaseGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void PurchaseGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


    }
}