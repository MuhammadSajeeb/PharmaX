using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class SupplierRepository
    {
        MainRepository _MainRepository = new MainRepository();
        public decimal AlreadyExistSupplier(Suppliers _Suppliers)
        {
            string query = "Select Count(*)from Suppliers Where Name='" + _Suppliers.Name + "' And Contact='"+_Suppliers.Contact+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Suppliers _Suppliers)
        {
            string query = "Insert Into Suppliers(Name,Email,Contact,Address,Date) Values ('" + _Suppliers.Name + "','" + _Suppliers.Email + "','" + _Suppliers.Contact + "','" + _Suppliers.Address + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Update(Categories _Categories)
        {
            string query = "Update Categories SET Name='" + _Categories.Name + "' where Code='" + _Categories.Code + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int Delete(Suppliers _Suppliers)
        {
            string query = ("Delete From Suppliers Where Contact='" + _Suppliers.Contact + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
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
                    _Suppliers.Name = reader["Name"].ToString();
                    _Suppliers.Email = reader["Email"].ToString();
                    _Suppliers.Contact = reader["Contact"].ToString();
                    _Suppliers.Address = reader["Address"].ToString();

                    _SuppliersList.Add(_Suppliers);
                }
            }
            reader.Close();

            return _SuppliersList;
        }
    }
}
