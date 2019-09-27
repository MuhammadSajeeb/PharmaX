using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Sales
{
    public partial class List : System.Web.UI.Page
    {
        SalesRepository _SalesRepository = new SalesRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllSaleList();
            }
        }
        public void GetAllSaleList()
        {
            SaleListGridView.DataSource = _SalesRepository.GetAllSaleList();
            SaleListGridView.DataBind();
        }
        protected void SaleListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}