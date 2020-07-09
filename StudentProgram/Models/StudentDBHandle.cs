using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentProgram.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection() {
            string conString = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(conString);
        }


        //************** ADD NEW STUDENT ***************************

        public bool AddStudent(StudentModel studentModel) {
            connection();
            SqlCommand command = new SqlCommand("AddNewStudent",con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", studentModel.name);
            command.Parameters.AddWithValue("@Address",studentModel.address);
            command.Parameters.AddWithValue("@City", studentModel.city);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        //************* SHOW STUDENTS DETAILS ************************

        public List<StudentModel> GetStudents() {
            connection();
            List<StudentModel> studentsList = new List<StudentModel>();

            SqlCommand command = new SqlCommand("GetStudentDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command); 
            DataTable dataTable = new DataTable();

            con.Open();
            sqlDataAdapter.Fill(dataTable);
            con.Close();

            foreach (DataRow dataRow in dataTable.Rows) {
                studentsList.Add(
                    new StudentModel { 
                        id= Convert.ToInt32(dataRow["Id"]),
                        name= Convert.ToString(dataRow["Name"]),
                        address= Convert.ToString(dataRow["Address"]),
                        city= Convert.ToString(dataRow["City"])
                    });
            }

            return studentsList;
        }


        //******* UPDATE STUDENT DETAILS ****************************

        public bool UpdateDetails(StudentModel studentModel) {
            connection();
            SqlCommand command = new SqlCommand("UpdateStudentDetail",con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@StdId",studentModel.id);
            command.Parameters.AddWithValue("@Name", studentModel.name);
            command.Parameters.AddWithValue("@Address", studentModel.address);
            command.Parameters.AddWithValue("@City", studentModel.city);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        //************ DELETE STUDENT ***************************

        public bool DeleteStudent(int id) {
            connection();
            SqlCommand command = new SqlCommand("DeleteStudent",con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@StdId",id);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}