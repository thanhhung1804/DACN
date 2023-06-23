using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DesktopApp.DAO
{
    public class CategoryDAO
    {
        private SqlServerDatabase database;

        public CategoryDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<CategoryDTO> GetAll(bool ascSortByName = true, bool descSortByCreatedDate = false)
        {
            string query = "select * from dbo.[Category]";

            if (descSortByCreatedDate)
            {
                query += " order by CreatedDate desc";
            }
            else if (ascSortByName)
            {
                query += " order by Name";
            }
            else
            {
                query += " order by Name desc";
            }

            List<CategoryDTO> categories = new List<CategoryDTO>();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                CategoryDTO category = new CategoryDTO(row);
                categories.Add(category);
            }
            return categories;
        }

        public bool Create(string name, string description = null)
        {
            string query = "insert into dbo.[Category] (CategoryId, Name, Description) values ( @categoryId , @name , @description )";

            Guid newCategoryId = Guid.NewGuid();
            List<object> parameters = new List<object>() { newCategoryId, name, description };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(Guid categoryId, string name, string description = null)
        {
            string query = "update dbo.[Category] set Name = @name , Description = @description where CategoryId = @categoryId";

            List<object> parameters = new List<object>() { name, description, categoryId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid categoryId)
        {
            string query = "delete from dbo.[Category] where CategoryId = @categoryId";

            List<object> parameters = new List<object>() { categoryId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool IsExistName(string name)
        {
            string query = @"select * from dbo.[Category] where Name = @name";
            List<object> parameters = new List<object> { name };
            DataTable result = database.ExecuteQuery(query, parameters);
            if (result.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
