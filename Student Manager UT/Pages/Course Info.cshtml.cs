using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Student_Manager_UT.Pages
{
    public class Course_InfoModel : PageModel
    {

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string name = Request.Form["name"];
            string lecturerName = Request.Form["lecturer"];

            string connectionStr = @"Data Source=LAPTOP-6HT1TUDO;Initial Catalog=""Student Manager"";Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);

            string query = "INSERT INTO Course (Name, LecturerName) VALUES (@name, @lecturerName)";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lecturerName", lecturerName);

            cmd.ExecuteScalar();

            conn.Close();
        }

    }
}