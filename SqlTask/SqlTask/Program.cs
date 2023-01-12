using System.Data;
using System.Data.SqlClient;

namespace SqlTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0UDOH5O;Database=DynamicDataMaskingDb2;Trusted_Connection=True");
            sqlConnection.Open();
            string query = "Execute as User='Hiko'\r\nSelect * from Users\r\nRevert";
            SqlDataAdapter sqlCommand = new SqlDataAdapter(query, sqlConnection);
            DataTable userTable = new DataTable();
            sqlCommand.Fill(userTable);

            foreach (var item in userTable.Columns)
            {
                Console.Write($"{item}    ");

            }
            Console.WriteLine();
            for (int i = 0; i < userTable.Rows.Count; i++)
            {
                foreach (var item in userTable.Columns)
                {

                    Console.Write($"{userTable.Rows[i][item.ToString()]}  ");

                }
                Console.WriteLine();
            }

            sqlConnection.Close();









        }
    }
}