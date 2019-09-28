using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp
{
    
    public partial class Dashboard : System.Web.UI.Page
    {
        StockRepository _StockRepository = new StockRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllLowerStock();
            }
        }
        public void GetAllLowerStock()
        {
            StockLowerGridView.DataSource = _StockRepository.GetAllLowStocks();
            StockLowerGridView.DataBind();
        }
    }
}