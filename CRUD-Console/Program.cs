using System.Data;
using System.Data.SqlClient;

namespace CRUD_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Data source=DESKTOP-IO41HSE; Database=CRUD_console; integrated Security= true");
            con.Open();

            string Name, Course;
            int StudentID;
            Console.WriteLine("Enter your Name:");
            Name= Console.ReadLine();

            Console.WriteLine("Enter your Course:");
            Course = Console.ReadLine();

            //INSERT
            String InsertQuery = "Insert into tbl_Student values ('" + Name+"','"+Course+"') ";
            SqlCommand cmd= new SqlCommand(InsertQuery, con);
            cmd.ExecuteNonQuery();
            show();

            //SELECT
           void show()
            {
                String SelectQuery = "select * from tbl_Student ";
                SqlCommand cmd2 = new SqlCommand(SelectQuery, con);
                cmd2.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Console.WriteLine("Student ID \t  Name  \t Course");
                Console.WriteLine("_____________________________________");
                foreach (DataRow row in dt.Rows)
                {
                    Console.Write(row[0] + "\t \t");
                    Console.Write(row[1] + "\t \t");
                    Console.Write(row[2]);
                    Console.WriteLine();

                }
            }

            //DELETE
            Console.WriteLine("Enter StudentId that you want to delete:");
            StudentID = Convert.ToInt32( Console.ReadLine());
            String DeleteQuery = "Delete from tbl_Student where StudentID=" + StudentID +" ";
            SqlCommand cmd3 = new SqlCommand(DeleteQuery, con);
            cmd3.ExecuteNonQuery();
            show();

            //Update
            Console.WriteLine("Enter StudentId that you want to update:");
            StudentID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter your Course:");
            Course = Console.ReadLine();

            String UpdateQuery = "update tbl_Student set Name= '" + Name + "', Course='" + Course + "' where StudentID=" + StudentID + "";
            SqlCommand cmd4 = new SqlCommand(UpdateQuery, con);
            cmd4.ExecuteNonQuery();
            show();

            Console.ReadKey();
        }
    }
}