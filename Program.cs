using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;

#region Odbc

Console.WriteLine("Odbc");
string MyConString = "DRIVER={MySQL ODBC 8.0 Unicode Driver};" +
            "SERVER=localhost;" +
            "DATABASE=mospolylabdb;" +
            "UID=root;" +
            "PASSWORD=root;" +
            "OPTION=3";

OdbcConnection odbcConnection = new OdbcConnection(MyConString); 
OdbcCommand command = odbcConnection.CreateCommand();
command.CommandText = "SELECT * FROM mospolylabdb.users";
odbcConnection.Open();
OdbcDataReader odbcDataReader = command.ExecuteReader();
while (odbcDataReader.Read())
{
    Console.WriteLine(odbcDataReader.GetString(0));
}
#endregion

#region OleDB

Console.WriteLine("Ole");
var myConn = new OleDbConnection("Provider=SQLOLEDB;Data Source=RDESKTOP\\MSSQLSERVER06;database=rufov; Integrated Security=SSPI");

myConn.Open();
string sql = "SELECT * FROM dbo.Table_1";
OleDbCommand cmd = new OleDbCommand(sql, myConn);

OleDbDataReader MyReader = cmd.ExecuteReader();

while (MyReader.Read())
{
    Console.WriteLine(MyReader["test"].ToString());
}

MyReader.Close();

#endregion

#region LINQ

Console.WriteLine("LINQ");

List<string> students = new List<string>() { "Смирнов", "Петров", "Яковлев", "Сидоров", "Иванов"};

var studentsFiltred = students.Where(s => s.ToUpper().StartsWith("С")).OrderBy(s => s).Select(s => s[2]);

foreach (var student in studentsFiltred)
{
    Console.WriteLine(student);
}

#endregion
