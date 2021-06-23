using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CourseManager.Repos
{
    public class DbTeachersRepo : ITeacherRepo
    {
        SqlCommand cmd;
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
            DataSet set = ExecuteQuery("insert into Teachers (Name) output inserted.Id values ('" + name + "')");

            id = set.Tables[0].Rows[0].Field<int>("Id");

            return id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Teacher toEdit)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> toReturn = new List<Teacher>();

            DataSet set = ExecuteQuery("select Id, Name from Teachers");

            var table = set.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Teacher toAdd = new Teacher();
                var setId = int.Parse(table.Rows[i]["Id"].ToString());
                var name = table.Rows[i].Field<string>("Name");

                toAdd.Id = setId;
                toAdd.Name = name;

                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public Teacher GetById(int id)
        {
            Teacher toReturn = null;
            DataSet set = ExecuteQuery("select Id, Name from Teachers where Id =" + id);

            var table = set.Tables[0];

            if(table.Rows.Count == 1)
            {
                toReturn = new Teacher();
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
