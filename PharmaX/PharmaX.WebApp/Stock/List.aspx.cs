using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Stock
{
    public partial class List : System.Web.UI.Page
    {
        StockRepository _StockRepository = new StockRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllStocks();
            }
        }
        public void GetAllStocks()
        {
            StockListGridView.DataSource = _StockRepository.GetAllStocks();
            StockListGridView.DataBind();
        }
    }
}