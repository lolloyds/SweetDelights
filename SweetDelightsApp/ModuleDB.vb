Imports System.Data.SqlClient

Module ModuleDB
    ' Connection string for SQL Server Express
    Public connectionString As String = "Data Source=DESKTOP-8JG6SC3\SQLEXPRESS;Initial Catalog=SweetDelightsDB;Integrated Security=True"
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
End Module
