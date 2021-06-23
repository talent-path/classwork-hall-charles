using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CourseManager.Repos
{
    public class DbCoursesRepo : ICourseRepo
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
        public int Add(Course toAdd)
        {
            int id = 0;
            DataSet set = ExecuteQuery("insert into Courses (Name, TeacherId) output inserted.Id values ('" + toAdd.Name + "', " + toAdd.ClassTeacher.Id + ")");
            id = set.Tables[0].Rows[0].Field<int>("Id");

            return id;
        }
        
        public List<Course> GetCoursesByTeacherId(int id)
        {
            List<Course> toReturn = new List<Course>();

            DataSet set = ExecuteQuery("select Id, Name, TeacherId from Courses where TeacherId =" + id);

            var table = set.Tables[0];

            for(int i = 0; i < table.Rows.Count; i++)
            {
                Course toAdd = new Course();
                var setId = int.Parse(table.Rows[i]["Id"].ToString());
                var name = table.Rows[i].Field<string>("Name");

                Teacher teacher = new Teacher();
                teacher.Id = table.Rows[i].Field<int>("TeacherId");

                toAdd.Id = setId;
                toAdd.Name = name;
                toAdd.ClassTeacher = teacher;
                //TODO need list of students & class teacher

                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public List<int> GetCoursesByStudentId(int id)
        {
            List<int> toReturn = new List<int>();

            DataSet set = ExecuteQuery("select CourseId, StudentId from StudentCourses where StudentId =" + id);

            var table = set.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                toReturn.Add(table.Rows[i].Field<int>("CourseId"));
            }

            return toReturn;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll()
        {
            List<Course> toReturn = new List<Course>();

            DataSet set = ExecuteQuery("select Id, Name, TeacherId from Courses");

            var table = set.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Course toAdd = new Course();
                var setId = int.Parse(table.Rows[i]["Id"].ToString());
                var name = table.Rows[i].Field<string>("Name");

                Teacher teacher = new Teacher();
                teacher.Id = table.Rows[i].Field<int>("TeacherId");


                toAdd.Id = setId;
                toAdd.Name = name;
                toAdd.ClassTeacher = teacher;
                //TODO need list of courses

                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public Course GetById(int id)
        {
            Course toReturn = null;
            DataSet set = ExecuteQuery("select Id, Name, TeacherId from Courses where Id =" + id);

            var table = set.Tables[0];

            if (table.Rows.Count == 1)
            {
                toReturn = new Course();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");
                
                Teacher teacher = new Teacher();
                teacher.Id = table.Rows[0].Field<int>("TeacherId");

                toReturn.Id = setId;
                toReturn.Name = name;
                toReturn.ClassTeacher = teacher;
                //TODO need list of students & class teacher
            }

            return toReturn;
        }
    }
}
