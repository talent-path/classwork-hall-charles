using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    public class DBStudentsRepo : IStudentRepo
    {
        string _connectionString = "Server=localhost;Database=CourseManager;Trusted_Connection=True;";

        private DataSet ExecuteQuery(string sql)
        {
            DataSet set = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(set);
            }

            return set;
        }

        public int Add(string name)
        {
            int id = 0;
            DataSet set = ExecuteQuery("insert into Students (Name) output inserted.Id values ('" + name + "')");

            id = set.Tables[0].Rows[0].Field<int>("Id");

            return id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            List<Student> toReturn = new List<Student>();

            DataSet set = ExecuteQuery("select Id, Name from Students");

            var table = set.Tables[0];

            for(int i = 0; i < table.Rows.Count; i++)
            {
                Student toAdd = new Student();
                var setId = int.Parse(table.Rows[i]["Id"].ToString());
                var name = table.Rows[i].Field<string>("Name");

                toAdd.Id = setId;
                toAdd.Name = name;
                //TODO need list of courses

                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public Student GetById(int id)
        {
            Student toReturn = null;
            DataSet set = ExecuteQuery("select Id, Name from Students where Id =" + id);

            var table = set.Tables[0];

            if (table.Rows.Count == 1)
            {
                toReturn = new Student();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");

                toReturn.Id = setId;
                toReturn.Name = name;
                //TODO need list of courses
            }

            return toReturn;
        }
    }
}
