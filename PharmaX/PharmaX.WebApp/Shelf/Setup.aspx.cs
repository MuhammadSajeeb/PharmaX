using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Shelf
{
    public partial class Setup : System.Web.UI.Page
    {
        ShelfRepository _ShelfRepository = new ShelfRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadShelfs();
            }
        }
        public void LoadShelfs()
        {
            ShelfGridView.DataSource = _ShelfRepository.GetAll();
            ShelfGridView.DataBind();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    if(txtStoreOfQty.Text!="")
                    {
                        Shelfs _Shelfs = new Shelfs();

                        _Shelfs.Name = txtName.Text;
                        _Shelfs.StoreQty = Convert.ToInt32(txtStoreOfQty.Text);

                        decimal AlreadyExistShelfs = _ShelfRepository.AlreadyExistName(_Shelfs);
                        if (AlreadyExistShelfs >= 1)
                        {
                            lblmsg.Text = "This Shelfs Already Here!!....";
                            lblmsg.ForeColor = Color.Red;
                            txtName.Focus();
                        }
                        else
                        {
                            int Savesuccess = _ShelfRepository.Add(_Shelfs);
                            if (Savesuccess > 0)
                            {

                                lblmsg.Text = "This Shelfs Save Successefully!!....";
                                lblmsg.ForeColor = Color.Green;
                                LoadShelfs();
                                txtStoreOfQty.Text="";
                                txtName.Text = "";

                                //Response.Redirect(Request.Url.AbsoluteUri);


                            }
                            else
                            {
                                lblmsg.Text = "This Shelfs Saving Failed!!....";
                                lblmsg.ForeColor = Color.Red;
                            }

                        }
                    }
                    else
                    {
                        txtStoreOfQty.Focus();
                        lblmsg.Text = "Please Type Shelfs Store Qty";
                        lblmsg.ForeColor = Color.Red;
                    }

                }
                else
                {
                    txtName.Focus();
                    lblmsg.Text = "Please Type Shelfs Name";
                    lblmsg.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.ForeColor = Color.Red;
            }
        }
        protected void ShelfGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Shelfs _Shelfs = new Shelfs();

                _Shelfs.Name = ShelfGridView.DataKeys[e.RowIndex].Value.ToString();
                 

                int deletesuccess = _ShelfRepository.Delete(_Shelfs);
                if (deletesuccess > 0)
                {
                    LoadShelfs();
                    lblmsg.Text = "Successefully Delete Shelfs!!....";
                    lblmsg.ForeColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.ForeColor = Color.Red;
            }
        }

    }
}