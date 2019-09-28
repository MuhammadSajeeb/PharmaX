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
            string query = ("(select t1.Item,t1.Batch,((t1.TotalPurchaseQty)-(t2.TotalSellingQty)) as StockQty,t1.CostPrice,t1.SellingPrice from (select Item,Batch,Sum(Qty) as TotalPurchaseQty,CostPrice,SellingPrice from PurchaseDetails group by Item,Batch,CostPrice,SellingPrice) t1  inner join (Select Item, sum(Qty) as TotalSellingQty from SaleDetails group by Item) t2 on t1.Item = t2.Item )");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Stocks = new Stocks();
                    _Stocks.Item = reader["Item"].ToString();
                    _Stocks.Batch = Convert.ToInt32(reader["Batch"].ToString());
                    _Stocks.StockQty = Convert.ToDecimal(reader["StockQty"].ToString());
                    _Stocks.CostPrice = Convert.ToDecimal(reader["CostPrice"].ToString());
                    _Stocks.SellingPrice = Convert.ToDecimal(reader["SellingPrice"].ToString());

                    _StocksList.Add(_Stocks);
                }
            }
            reader.Close();

            return _StocksList;
        }
        public List<Stocks> GetAllLowStocks()
        {
            var _StocksList = new List<Stocks>();
            string query = ("(select t3.Item,t3.Batch,t3.StockQty,t3.CostPrice,t3.SellingPrice from((select t1.Item,t1.Batch,((t1.TotalPurchaseQty)-(t2.TotalSellingQty)) as StockQty,t1.CostPrice,t1.SellingPrice from (select Item,Batch,Sum(Qty) as TotalPurchaseQty,CostPrice,SellingPrice from PurchaseDetails group by Item,Batch,CostPrice,SellingPrice) t1 inner join (Select Item, sum(Qty) as TotalSellingQty from SaleDetails group by Item) t2 on t1.Item = t2.Item ) t3 inner join (select Name, ReorderLevel from Items)t4 on t3.Item = t4.Name) where t3.StockQty < t4.ReorderLevel)");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Stocks = new Stocks();
                    _Stocks.Item = reader["Item"].ToString();
                    _Stocks.Batch = Convert.ToInt32(reader["Batch"].ToString());
                    _Stocks.StockQty = Convert.ToDecimal(reader["StockQty"].ToString());
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
