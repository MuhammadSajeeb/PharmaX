using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class SalesRepository
    {
        MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistData()
        {
            string query = "Select Count(*)from Sales ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Sale GetLastPurchaseId()
        {
            Sale _Sales = null;

            string query = "Select top 1 SalesId from Sales order by SalesId desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Sales = new Sale();
                _Sales.SalesId = (reader["SalesId"].ToString());
            }
            reader.Close();

            return _Sales;
        }

        public List<Categories> GetAllCategories()
        {
            var _CategoryList = new List<Categories>();
            string query = ("Select *From Categories");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Category = new Categories();
                    _Category.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Category.Name = reader["Name"].ToString();

                    _CategoryList.Add(_Category);
                }
            }
            reader.Close();

            return _CategoryList;
        }
        public List<Items> GetAllItemsByCategories(int Id)
        {
            var _ItemsList = new List<Items>();
            string query = ("Select *From Items Where CategoriesId='" + Id + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Items = new Items();
                    _Items.Code = reader["Code"].ToString();
                    _Items.Name = reader["Name"].ToString();

                    _ItemsList.Add(_Items);
                }
            }
            reader.Close();

            return _ItemsList;
        }

        public decimal TotalQtyPurchaseByItems(string name)
        {
            string query = "select SUM(Qty) from PurchaseDetails where Item='"+name+"'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal TotalQtySalesByItems(string name)
        {
            string query = "select SUM(Qty) from SaleDetails where Item='" + name + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public PurchaseDetails GetSellingPrice(string name)
        {
            PurchaseDetails _PurchaseDetails = null;

            string query = "Select top 1 SellingPrice from PurchaseDetails where Item='"+name+"' order by SellingPrice desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _PurchaseDetails = new PurchaseDetails();
                _PurchaseDetails.SellingPrice = Convert.ToDecimal(reader["SellingPrice"].ToString());
            }
            reader.Close();

            return _PurchaseDetails;
        }
        public int Add(SaleDetails _SaleDetails)
        {
            string query = "Insert Into SaleDetails(CustomerContact,Item,Unit,Qty,Total,SalesId,Date) Values ('" + _SaleDetails.CustomerContact + "','" + _SaleDetails.Item + "','" + _SaleDetails.Unit + "','" + _SaleDetails.Qty + "','" + _SaleDetails.Total + "','" + _SaleDetails.SalesId + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Delete(int Id)
        {
            string query = ("Delete From SaleDetails Where Id='" + Id + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<SaleDetails> GetSalesOrderById(string Id)
        {
            var _SaleDetailsList = new List<SaleDetails>();
            string query = ("Select *From SaleDetails Where SalesId='"+Id+"'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _SaleDetails = new SaleDetails();
                    _SaleDetails.Id = Convert.ToInt32(reader["Id"].ToString());
                    _SaleDetails.Item = reader["Item"].ToString();
                    _SaleDetails.Unit = Convert.ToDecimal(reader["Unit"].ToString());
                    _SaleDetails.Qty = Convert.ToDecimal(reader["Qty"].ToString());
                    _SaleDetails.Total = Convert.ToDecimal(reader["Total"].ToString());

                    _SaleDetailsList.Add(_SaleDetails);
                }
            }
            reader.Close();

            return _SaleDetailsList;
        }
        public int SalesSubmit(Sale _Sales)
        {
            string query = "Insert Into Sales(CustomerContact,SalesId,TotalAmount,Discount,GrandTotal,PaidAmount,Changes,RemainingDue,Status,Date) Values ('" + _Sales.CustomerContact + "','" + _Sales.SalesId + "','" + _Sales.TotalAmount + "','" + _Sales.Discount + "','" + _Sales.GrandTotal + "','" + _Sales.PaidAmount + "','" + _Sales.Changes + "','" + _Sales.RemainingDue + "','" + _Sales.Status + "','" + _Sales.Date + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Sale> GetAllSaleList()
        {
            var _SalesList = new List<Sale>();
            string query = ("select *from Sales");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Sales = new Sale();
                    _Sales.CustomerContact= reader["CustomerContact"].ToString();
                    _Sales.SalesId = reader["SalesId"].ToString();
                    _Sales.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                    _Sales.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                    _Sales.GrandTotal = Convert.ToDecimal(reader["GrandTotal"].ToString());
                    _Sales.PaidAmount = Convert.ToDecimal(reader["PaidAmount"].ToString());
                    _Sales.Changes = Convert.ToDecimal(reader["Changes"].ToString());
                    _Sales.RemainingDue = Convert.ToDecimal(reader["RemainingDue"].ToString());
                    _Sales.Status = reader["Status"].ToString();
                    _Sales.Date = reader["Date"].ToString();

                    _SalesList.Add(_Sales);
                }
            }
            reader.Close();

            return _SalesList;
        }
    }
}
