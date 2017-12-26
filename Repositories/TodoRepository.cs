using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace FantaCode.Todoapi.Repositories
{
    public class TodoRepository
    {

        private string connectionString;

        public TodoRepository()
        {
            connectionString = @"Data Source=tcp:todointern.database.windows.net,1433;Initial Catalog=Fcdone;User Id=sabeersulaimanpv@todointern.database.windows.net;Password=Mic#128$AbEeR;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public IEnumerable<Todo> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<Todo>("SELECT * FROM Todo");
            }
        }

        public void Add(Todo item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "INSERT INTO Todo (Task, Description, Done)"
                                + " VALUES(@Task, @Description, @Done)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }

        public Todo View(int item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "Select * from Todo where Todoid = @id ";
                dbConnection.Open();
                List<Todo> todos = dbConnection.Query<Todo>(sQuery, new { id = item }).ToList();
                
                return todos.FirstOrDefault();
            }
        }

        public void Update(Todo item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "UPDATE Todo SET Task = @Task,"
                                + " Done = @Done ,"
                               + " Description = @Description"
                               + " WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        public void Delete(Todo item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "delete from Todo WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        public void Done(int id)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "UPDATE Todo SET Done = 1 WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, new {Todoid = id});
            }
        }
    }
}