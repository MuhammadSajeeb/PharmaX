using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Purchase
{
    public partial class Details : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        string Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PurchaseDetails();
                GetAllPurchaseDetails();
            }
        }
        public void GetAllPurchaseDetails()
        {
            Id = Request.QueryString["Id"].ToString();
            PurchaseDetailsGridView.DataSource = _PurchaseRepository.GetAllPurchaseDetails(Id);
            PurchaseDetailsGridView.DataBind();
        }
        public void PurchaseDetails()
        {
            Id = Request.QueryString["Id"].ToString();

            var PurchaseData = _PurchaseRepository.PurchaseData(Id);
            if (PurchaseData != null)
            {
                lblPurchaseId.Text = PurchaseData.PurchaseId.ToString();
                lblDate.Text = PurchaseData.Date.ToString();
                lblDescription.Text = "All"+" "+PurchaseData.Status.ToString();

            }

        }
    }
}