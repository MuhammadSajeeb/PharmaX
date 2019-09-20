using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Supplier
{
    public partial class ViewAll : System.Web.UI.Page
    {
        SupplierRepository _SupplierRepository = new SupplierRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadSuppliers();
            }
        }
        public void LoadSuppliers()
        {
            SuppliersGridView.DataSource = _SupplierRepository.GetAllSupplliers();
            SuppliersGridView.DataBind();
        }
    }
}