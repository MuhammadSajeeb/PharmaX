using P.Core.Models;
using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Category
{
    public partial class Setup : System.Web.UI.Page
    {
        CategoriesRepository _CategoriesRepository = new CategoriesRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoCodeGenerate();
                LoadCategories();
            }
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _CategoriesRepository.AlreadyExistData();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _CategoriesRepository.GetLastCode();
                if (GetLastCode != null)
                {
                    code = Convert.ToInt32(GetLastCode.Code);
                    code++;
                }
                txtCategoryCode.Text = code.ToString("000");
            }
            else
            {
                txtCategoryCode.Text = "001";
            }
        }
        public void LoadCategories()
        {
            CategoriesGridView.DataSource = _CategoriesRepository.GetAll();
            CategoriesGridView.DataBind();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCategoryName.Text!="")
                {
                    Categories _Categories = new Categories();
                    _Categories.Code = txtCategoryCode.Text;
                    _Categories.Name = txtCategoryName.Text;

                    decimal AlreadyExistCaegory = _CategoriesRepository.AlreadyExistName(_Categories);
                    if (AlreadyExistCaegory >= 1)
                    {
                        lblmsg.Text = "This Category Already Here!!....";
                        lblmsg.ForeColor = Color.Red;
                        txtCategoryName.Focus();
                    }
                    else
                    {
                        int Savesuccess = _CategoriesRepository.Add(_Categories);
                        if (Savesuccess > 0)
                        {

                            lblmsg.Text = "This Category Save Successefully!!....";
                            lblmsg.ForeColor = Color.Green;
                            LoadCategories();
                            AutoCodeGenerate();
                            txtCategoryName.Text = "";

                            //Response.Redirect(Request.Url.AbsoluteUri);


                        }
                        else
                        {
                            lblmsg.Text = "This Category Saving Failed!!....";
                            lblmsg.ForeColor = Color.Red;
                        }

                    }
                }
                else
                {
                    txtCategoryName.Focus();
                    lblmsg.Text = "Please Type Category Name";
                    lblmsg.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.ForeColor = Color.Red;
            }
        }
        protected void CategoriesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Categories _Categories = new Categories();
                _Categories.Code = CategoriesGridView.DataKeys[e.RowIndex].Value.ToString();

                int deletesuccess = _CategoriesRepository.Delete(_Categories);
                if (deletesuccess > 0)
                {
                    LoadCategories();
                    AutoCodeGenerate();
                    lblmsg.Text = "Successefully Delete Category!!....";
                    lblmsg.ForeColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.ForeColor = Color.Red;
            }
        }
        protected void CategoriesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}