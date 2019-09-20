using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Suplier
{
    public partial class Setup : System.Web.UI.Page
    {
        SupplierRepository _SupplierRepository = new SupplierRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    Suppliers _Suppliers = new Suppliers();
                    _Suppliers.Name = txtName.Text;
                    _Suppliers.Email = txtEmail.Text;
                    _Suppliers.Contact = txtContact.Text;
                    _Suppliers.Address = txtAddress.Text;

                    decimal AlreadyExistSupplier = _SupplierRepository.AlreadyExistSupplier(_Suppliers);
                    if (AlreadyExistSupplier >= 1)
                    {
                        lblmsg.Text = "This Supplier Already Here!!....";
                        lblmsg.ForeColor = Color.Red;
                        txtName.Focus();
                    }
                    else
                    {
                        int Savesuccess = _SupplierRepository.Add(_Suppliers);
                        if (Savesuccess > 0)
                        {

                            lblmsg.Text = "This Supplier Save Successefully!!....";
                            lblmsg.ForeColor = Color.Green;

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            lblmsg.Text = "This Supplier Saving Failed!!....";
                            lblmsg.ForeColor = Color.Red;
                        }

                    }
                }
                else
                {
                    txtName.Focus();
                    lblmsg.Text = "Please Type Supplier Name";
                    lblmsg.ForeColor = Color.Red;
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