using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Student_Manager_UT.Pages
{
    public class Student_InfoModel : PageModel
    {
        public void OnGet() 
        {
        }

        public void OnPost()
        {
            string name = Request.Form["name"];
            string cityName = Request.Form["city"];
            int courseId = int.Parse(Request.Form["course"]);

            string connectionStr = @"Data Source=LAPTOP-6HT1TUDO;Initial Catalog=""Student Manager"";Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);

            string query = "INSERT INTO Student (Name, City, CourseID) VALUES (@name, @city, @course)";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@city", cityName);
            cmd.Parameters.AddWithValue("@course", courseId);

            cmd.ExecuteScalar();


            conn.Close();
        }
    }
    
}
