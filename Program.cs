using System.Data.Odbc;

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