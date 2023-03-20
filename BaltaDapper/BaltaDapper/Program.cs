using Microsoft.Data.SqlClient;
// See https://aka.ms/new-console-template for more information

const string connectionString = "Server=localhost,1433;Databae=BaltaRestore;User ID=SA;Password=lbg@2022";

using (var connection = new SqlConnection(connectionString)) { }