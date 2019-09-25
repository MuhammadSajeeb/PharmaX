using P.Persistancis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaX.WebApp.Item
{
    public partial class ViewAll : System.Web.UI.Page
    {
        ItemRepository _ItemRepository = new ItemRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadItems();
            }
        }
        public void LoadItems()
        {
            ItemsGridView.DataSource = _ItemRepository.GetAllItems();
            ItemsGridView.DataBind();

        }
    }
}