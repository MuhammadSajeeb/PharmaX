using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class ShelfRepository
    {
        MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistName(Shelfs _Shelfs)
        {
            string query = "Select Count(*)from Shelfs Where Name='" + _Shelfs.Name + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Shelfs _Shelfs)
        {
            string query = "Insert Into Shelfs(Name,StoreQty,Date) Values ('" + _Shelfs.Name + "','" + _Shelfs.StoreQty + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Update(Categories _Categories)
        {
            string query = "Update Categories SET Name='" + _Categories.Name + "' where Code='" + _Categories.Code + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int Delete(Shelfs _Shelfs)
        {
            string query = ("Delete From Shelfs Where Name='" + _Shelfs.Name + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Shelfs> GetAll()
        {
            var _ShelfList = new List<Shelfs>();
            string query = ("Select *From Shelfs");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Shelfs = new Shelfs();
                    _Shelfs.Name = reader["Name"].ToString();
                    _Shelfs.StoreQty = Convert.ToInt32(reader["StoreQty"].ToString());

                    _ShelfList.Add(_Shelfs);
                }
            }
            reader.Close();

            return _ShelfList;
        }
    }
}
