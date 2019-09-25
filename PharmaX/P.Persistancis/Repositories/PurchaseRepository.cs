using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class PurchaseRepository
    {
        MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistData()
        {
            string query = "Select Count(*)from Purchase ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Purchases GetLastPurchaseId()
        {
            Purchases _Purchase = null;

            string query = "Select top 1 PurchaseId from Purchase order by PurchaseId desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Purchase = new Purchases();
                _Purchase.PurchaseId = (reader["PurchaseId"].ToString());
            }
            reader.Close();

            return _Purchase;
        }
        public List<Suppliers> GetAllSupplliers()
        {
            var _SuppliersList = new List<Suppliers>();
            string query = ("Select *From Suppliers");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Suppliers = new Suppliers();
                    _Suppliers.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Suppliers.Name = reader["Name"].ToString();

                    _SuppliersList.Add(_Suppliers);
                }
            }
            reader.Close();

            return _SuppliersList;
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
            string query = ("Select *From Items Where CategoriesId='"+Id+"' ");
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

    }
}
