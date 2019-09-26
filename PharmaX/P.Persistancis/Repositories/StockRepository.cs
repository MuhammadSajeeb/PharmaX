using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class StockRepository
    {
        MainRepository _MainRepository = new MainRepository();

        public List<Stocks> GetAllStocks()
        {
            var _StocksList = new List<Stocks>();
            string query = ("select distinct Items.Name,PurchaseDetails.Batch,sum(PurchaseDetails.Qty) as TotalQty,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice from PurchaseDetails join Items on Items.Name = PurchaseDetails.Item group by Items.Name,PurchaseDetails.Batch,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Stocks = new Stocks();
                    _Stocks.Name = reader["Name"].ToString();
                    _Stocks.Batch = Convert.ToInt32(reader["Batch"].ToString());
                    _Stocks.TotalQty = Convert.ToDecimal(reader["TotalQty"].ToString());
                    _Stocks.CostPrice = Convert.ToDecimal(reader["CostPrice"].ToString());
                    _Stocks.SellingPrice = Convert.ToDecimal(reader["SellingPrice"].ToString());

                    _StocksList.Add(_Stocks);
                }
            }
            reader.Close();

            return _StocksList;
        }
    }
}
