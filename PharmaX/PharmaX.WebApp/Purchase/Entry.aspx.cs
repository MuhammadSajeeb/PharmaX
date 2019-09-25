using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Purchase
{
    public partial class Entry : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        MainRepository _MainRepository = new MainRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoGeneratePurchaseId();
                GetAllCategories();
                GetAllSuppliers();
                ItemsDropDownList.Items.Insert(0, new ListItem("None of Items", "0"));
                txtDate.Text = DateTime.Now.ToString();
                txtDiscount.Text = "00";
            }
        }
        public void AutoGeneratePurchaseId()
        {
            decimal AlreadyExistData = _PurchaseRepository.AlreadyExistData();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _PurchaseRepository.GetLastPurchaseId();
                if (GetLastCode != null)
                {
                    code = Convert.ToInt32(GetLastCode.PurchaseId);
                    code++;
                }
                txtPurchaseId.Text = code.ToString("000");
            }
            else
            {
                txtPurchaseId.Text = "1001";
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
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Batch", typeof(int));
            dataTable.Columns.Add("Qty", typeof(decimal));
            dataTable.Columns.Add("CostPrice", typeof(decimal));
            dataTable.Columns.Add("TotalPrice", typeof(decimal));
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
                        dr["TotalPrice"] = Convert.ToDecimal(dr["Qty"]) * Convert.ToDecimal(dr["CostPrice"]);
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
                        dr["TotalPrice"] = Convert.ToDecimal(dr["Qty"]) * Convert.ToDecimal(dr["CostPrice"]);
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
                dr["TotalPrice"] = Convert.ToDecimal(dr["Qty"]) * Convert.ToDecimal(dr["CostPrice"]);
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
            if(SuppliersDropDownList.SelectedIndex>0 && txtDate.Text!=null && CategoriesDropDownList.SelectedIndex>0 && ItemsDropDownList.SelectedIndex>0)
            {
                if(txtBatch.Text!=null && txtQty.Text!=null && txtCostPrice.Text!=null && txtSellingPrice.Text!=null && txtExpire.Text!=null)
                {
                    AddPurchaseItems();
                    txtAmount.Text = total.ToString("00.00");
                    txtGrandTotal.Text = total.ToString("00.00");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check All formality');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check All formality');", true);
            }
        }
        protected void PurchaseGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = (DataTable)ViewState["Details"];
            if (dataTable.Rows.Count > 0)
            {
                dataTable.Rows[e.RowIndex].Delete();

                ViewState["Details"] = dataTable;


                PurchaseGridView.DataSource = dataTable;
                PurchaseGridView.DataBind();

                txtAmount.Text = total.ToString();
                txtGrandTotal.Text = total.ToString();

            }
        }
        decimal total = 0;
        protected void PurchaseGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lblTotalPrice = e.Row.FindControl("lblTotalPrice") as Label;
                if (lblTotalPrice != null)
                {
                    total += Convert.ToDecimal(lblTotalPrice.Text);
                }
            }
        }
        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal totalamount = Convert.ToDecimal(txtAmount.Text);
            decimal discountamount = Convert.ToDecimal(txtDiscount.Text);

            decimal cal = totalamount - discountamount;

            txtGrandTotal.Text=cal.ToString();
        }
        protected void PurchaseSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaidRadioButton.Checked || DueRadioButton.Checked)
                {
                    if (PaidRadioButton.Checked)
                    {
                        SqlTransaction transaction = null;
                        var sql = _MainRepository.ConnectionString();
                        using (SqlConnection Sqlcon = new SqlConnection(sql))
                        {
                            Sqlcon.Open();
                            transaction = Sqlcon.BeginTransaction();
                            try
                            {
                                Purchases _Purchases = new Purchases();

                                _Purchases.PurchaseId = txtPurchaseId.Text;
                                _Purchases.SupplierId = Convert.ToInt32(SuppliersDropDownList.SelectedValue);
                                _Purchases.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                                _Purchases.Discount = Convert.ToDecimal(txtDiscount.Text);
                                _Purchases.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                                _Purchases.Status = "Paid";
                                _Purchases.Date = txtDate.Text;

                                SqlCommand command1 = new SqlCommand("Insert Into Purchase(PurchaseId,SupplierId,TotalAmount,Discount,GrandTotal,Status,Date) Values ('" + _Purchases.PurchaseId + "','" + _Purchases.SupplierId + "','" + _Purchases.TotalAmount + "','" + _Purchases.Discount + "','" + _Purchases.GrandTotal + "','" + _Purchases.Status + "','" + _Purchases.Date + "')", Sqlcon, transaction);
                                command1.CommandType = CommandType.Text;
                                command1.ExecuteNonQuery(); //AccountSale Save;

                                //ItemSales Start With foreach

                                DataTable dt = (DataTable)ViewState["Details"];

                                foreach (DataRow dr in dt.Rows)
                                {
                                    PurchaseDetails _PurchaseDetails = new PurchaseDetails();

                                    _PurchaseDetails.PurchaseId = txtPurchaseId.Text;
                                    _PurchaseDetails.Item = (dr["Item"].ToString());
                                    _PurchaseDetails.Batch = Convert.ToInt32(dr["Batch"].ToString());
                                    _PurchaseDetails.Qty = Convert.ToDecimal(dr["Qty"].ToString());
                                    _PurchaseDetails.CostPrice = Convert.ToDecimal(dr["CostPrice"].ToString());
                                    _PurchaseDetails.TotalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString());
                                    _PurchaseDetails.SellingPrice = Convert.ToDecimal(dr["SellingPrice"].ToString());
                                    _PurchaseDetails.Expire = (dr["Expire"].ToString());
                                    _PurchaseDetails.SupplierId = Convert.ToInt32(SuppliersDropDownList.SelectedValue);

                                    SqlCommand command = new SqlCommand("Insert Into PurchaseDetails(PurchaseId,Item,Batch,Qty,CostPrice,TotalPrice,SellingPrice,Expire,SupplierId,Date) Values ('" + _PurchaseDetails.PurchaseId + "','" + _PurchaseDetails.Item + "','" + _PurchaseDetails.Batch + "','" + _PurchaseDetails.Qty + "','" + _PurchaseDetails.CostPrice + "','" + _PurchaseDetails.TotalPrice + "','" + _PurchaseDetails.SellingPrice + "','" + _PurchaseDetails.Expire + "','" + _PurchaseDetails.SupplierId + "','" + DateTime.Now.ToShortDateString() + "')", Sqlcon, transaction);
                                    command.CommandType = CommandType.Text;
                                    command.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                Response.Redirect(Request.Url.AbsoluteUri);
                                //CreatePdf();

                            }
                            catch
                            {
                                transaction.Rollback();
                            }
                            finally
                            {
                                Sqlcon.Close();
                            }
                        }
                    }
                    else if (DueRadioButton.Checked)
                    {
                        SqlTransaction transaction = null;
                        var sql = _MainRepository.ConnectionString();
                        using (SqlConnection Sqlcon = new SqlConnection(sql))
                        {
                            Sqlcon.Open();
                            transaction = Sqlcon.BeginTransaction();
                            try
                            {
                                Purchases _Purchases = new Purchases();

                                _Purchases.PurchaseId = txtPurchaseId.Text;
                                _Purchases.SupplierId = Convert.ToInt32(SuppliersDropDownList.SelectedValue);
                                _Purchases.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                                _Purchases.Discount = Convert.ToDecimal(txtDiscount.Text);
                                _Purchases.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                                _Purchases.Status = "Due";
                                _Purchases.Date = txtDate.Text;

                                SqlCommand command1 = new SqlCommand("Insert Into Purchase(PurchaseId,SupplierId,TotalAmount,Discount,GrandTotal,Status,Date) Values ('" + _Purchases.PurchaseId + "','" + _Purchases.SupplierId + "','" + _Purchases.TotalAmount + "','" + _Purchases.Discount + "','" + _Purchases.GrandTotal + "','" + _Purchases.Status + "','" + _Purchases.Date + "')", Sqlcon, transaction);
                                command1.CommandType = CommandType.Text;
                                command1.ExecuteNonQuery(); //AccountSale Save;

                                //ItemSales Start With foreach

                                DataTable dt = (DataTable)ViewState["Details"];

                                foreach (DataRow dr in dt.Rows)
                                {
                                    PurchaseDetails _PurchaseDetails = new PurchaseDetails();

                                    _PurchaseDetails.PurchaseId = txtPurchaseId.Text;
                                    _PurchaseDetails.Item = (dr["Item"].ToString());
                                    _PurchaseDetails.Batch = Convert.ToInt32(dr["Batch"].ToString());
                                    _PurchaseDetails.Qty = Convert.ToDecimal(dr["Qty"].ToString());
                                    _PurchaseDetails.CostPrice = Convert.ToDecimal(dr["CostPrice"].ToString());
                                    _PurchaseDetails.TotalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString());
                                    _PurchaseDetails.SellingPrice = Convert.ToDecimal(dr["SellingPrice"].ToString());
                                    _PurchaseDetails.Expire = (dr["Expire"].ToString());
                                    _PurchaseDetails.SupplierId = Convert.ToInt32(SuppliersDropDownList.SelectedValue);

                                    SqlCommand command = new SqlCommand("Insert Into PurchaseDetails(PurchaseId,Item,Batch,Qty,CostPrice,TotalPrice,SellingPrice,Expire,SupplierId,Date) Values ('" + _PurchaseDetails.PurchaseId + "','" + _PurchaseDetails.Item + "','" + _PurchaseDetails.Batch + "','" + _PurchaseDetails.Qty + "','" + _PurchaseDetails.CostPrice + "','" + _PurchaseDetails.TotalPrice + "','" + _PurchaseDetails.SellingPrice + "','" + _PurchaseDetails.Expire + "','" + _PurchaseDetails.SupplierId + "','" + DateTime.Now.ToShortDateString() + "')", Sqlcon, transaction);
                                    command.CommandType = CommandType.Text;
                                    command.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                Response.Redirect(Request.Url.AbsoluteUri);
                                //CreatePdf();

                            }
                            catch
                            {
                                transaction.Rollback();
                            }
                            finally
                            {
                                Sqlcon.Close();
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select Paid Or Due');", true);
                }

            }
            catch { } 
        }
    }
}