using P.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Persistancis.Repositories
{
    public class ItemRepository
    {
        MainRepository _MainRepository = new MainRepository();
        public decimal AlreadyExistData()
        {
            string query = "Select Count(*)from Categories ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Items GetLastCode()
        {
            Items _Items = null;

            string query = "Select top 1 Code from Items order by Code desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Items = new Items();
                _Items.Code = (reader["Code"].ToString());
            }
            reader.Close();

            return _Items;
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
        public List<Shelfs> GetAllShelfs()
        {
            var _ShelfList = new List<Shelfs>();
            string query = ("Select *From Shelfs");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Shelfs = new Shelfs();
                    _Shelfs.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Shelfs.Name = reader["Name"].ToString();

                    _ShelfList.Add(_Shelfs);
                }
            }
            reader.Close();

            return _ShelfList;
        }
        public int Add(Items _Items)
        {
            string query = "Insert Into Shelfs(Code,Name,GenericName,ReorderLevel,CategoriesId,ShelfsId,Date) Values ('" + _Items.Code + "','" + _Items.Name + "','" + _Items.GenericName + "','" + _Items.ReorderLevel + "','" + _Items.CategoriesId+ "','" + _Items.ShelfsId + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public Shelfs GetQtyByShelfs(int Id)
        {
            Shelfs _Shelfs = null;

            string query = ("Select *From Shelfs where Id='" + Id + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Shelfs = new Shelfs();
                _Shelfs.StoreQty = Convert.ToInt32(reader["StoreQty"].ToString());
            }
            reader.Close();

            return _Shelfs;
        }
        public decimal GetTotalStoreByShelfs(int Id)
        {
            string query = "Select Count(*)from Items Where ShelfsId='"+Id+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
    }
}
