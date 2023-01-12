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
            string queryColumnCount = "SELECT COLUMN_NAME\r\nFROM INFORMATION_SCHEMA.COLUMNS\r\nWHERE TABLE_NAME = 'Users'";
            SqlCommand sqlCommandColumnCount = new SqlCommand(queryColumnCount, sqlConnection);
            var colmnCountRead = sqlCommandColumnCount.ExecuteReader();
            List<string> newColmnName = new List<string>();
            while (colmnCountRead.Read())
            {
                newColmnName.Add((string)colmnCountRead[0]);
            }
            colmnCountRead.Close();
            string query = "Execute as User='Hiko'\r\nSelect * from Users\r\nRevert";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            var data = sqlCommand.ExecuteReader();
            while (data.Read())
            {
                foreach (var item in newColmnName)
                {
                    if (item == "Id")
                    {
                        Console.WriteLine(" ");
                    }
                    Console.Write($"{item}-{data[item]}\t");
                    

                }

            }

            data.Close();
            sqlConnection.Close();









        }
    }
}