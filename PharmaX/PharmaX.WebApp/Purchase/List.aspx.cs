using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Purchase
{
    public partial class List : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllPurchase();
            }
        }
        public void GetAllPurchase()
        {
            PurchaseListGridView.DataSource = _PurchaseRepository.GetAllPurchase();
            PurchaseListGridView.DataBind();
        }

        protected void PurchaseListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = (PurchaseListGridView.SelectedRow.Cells[2].Text);
            Response.Redirect("Details.aspx?id=" + Id);
        }
    }
}