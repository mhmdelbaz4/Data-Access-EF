using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

var config =  new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
SqlConnection conn =new(config.GetConnectionString("DefaultConnection"));

#region Insert -> connected mode
//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "Insert into Wallets (Holder, Balance) Values (@Holder1, @Balance1),(@Holder2,@Balance2)";
//cmd.CommandType = CommandType.Text;
//cmd.Parameters.AddWithValue("@Holder1", "Ali Ahmed");
//cmd.Parameters.AddWithValue("@Balance1", 5000);
//cmd.Parameters.AddWithValue("@Holder2", "Osama Khaled");
//cmd.Parameters.AddWithValue("@Balance2", 3000);
//conn.Open();
//if (cmd.ExecuteNonQuery() > 0)
//    Console.WriteLine("Inserted Correctly");
//else
//   Console.WriteLine("Insertion Failed!");
//conn.Close();
#endregion

#region Update -> connected mode
//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "update wallets set Balance=10000 where id = 2";
//cmd.CommandType = CommandType.Text;
//conn.Open();
//if (cmd.ExecuteNonQuery() > 0)
//    Console.WriteLine("updated Correctly");
//else
//    Console.WriteLine("Update Failed!");
//conn.Close();
#endregion

#region Delete -> connected mode
//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "DELETE FROM WALLETS WHERE ID = 2";
//cmd.CommandType = CommandType.Text;
//conn.Open();
//if (cmd.ExecuteNonQuery() > 0)
//    Console.WriteLine("Inserted Correctly");
//else
//    Console.WriteLine("Insertion Failed!");
//conn.Close();
#endregion

#region Select -> connected mode
// ExcuteScalar() ->returns the first cell of the first row in the result set

//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "SELECT COUNT(*) FROM Wallets";
//conn.Open();
//int result = (int)cmd.ExecuteScalar();
//conn.Close();
//Console.WriteLine($"Number of wallets = {result}");   


//ExecuteReader -> returns result as stream of data as bulks to read it
//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "SELECT * FROM Wallets";
//cmd.CommandType = CommandType.Text;
//conn.Open();
//SqlDataReader reader = cmd.ExecuteReader();
//while (reader.Read())
//{
//    Console.WriteLine($"ID: {reader["ID"]}, Holder: {reader["Holder"]}, Balance: {reader["Balance"]}");
//}
//conn.Close();

#endregion

#region Stored Procedure-> connected mode
//SqlCommand cmd = new SqlCommand();
//cmd.Connection = conn;
//cmd.CommandText = "AddWallet";
//cmd.CommandType = CommandType.StoredProcedure;
//cmd.Parameters.AddWithValue("@Holder", "Elbaz");
//cmd.Parameters.AddWithValue("@Balance", 50000);
//conn.Open();
//if(cmd.ExecuteNonQuery() > 0)
//    Console.WriteLine("SP Called Successfully!");
//else
//    Console.WriteLine("SP Failed!");
#endregion

#region Transaction -> connected mode
//conn.Open();
//SqlTransaction transaction = conn.BeginTransaction();
//SqlCommand cmd1 = new SqlCommand();
//cmd1.Connection = conn;
//cmd1.CommandText = "Update Wallets Set Balance = Balance - 500 where id = 2;";
//cmd1.CommandType = CommandType.Text;
//cmd1.Transaction = transaction;

//SqlCommand cmd2 = new SqlCommand();
//cmd2.Connection = conn;
//cmd2.CommandText = "Update Wallets Set Balance = Balance + 500 where id = 3;";
//cmd2.CommandType = CommandType.Text;
//cmd2.Transaction = transaction;

//try
//{
//    cmd1.ExecuteNonQuery();
//    cmd2.ExecuteNonQuery();
//    transaction.Commit();
//}catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//    transaction.Rollback();
//}
//finally
//{
//    conn.Close();
//}
#endregion

#region Disconnected mode
//SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Wallets",conn);
//DataSet ds = new DataSet();
//adapter.Fill(ds);
//DataTable dt = ds.Tables[0];
//foreach(DataRow row in dt.Rows)
//    Console.WriteLine($"ID: {row["ID"]}, Holder: {row["Holder"]}, Balance: {row["Balance"]}");

// update
//dt.Rows[0]["Holder"] = "Mona";
//// delete
//dt.Rows[1].Delete();

//// insert
//DataRow newRow = dt.NewRow();
//newRow["Holder"] = "Ali";
//newRow["Balance"] = 1000;
//dt.Rows.Add(newRow);
//SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
adapter.Update(ds);
#endregion