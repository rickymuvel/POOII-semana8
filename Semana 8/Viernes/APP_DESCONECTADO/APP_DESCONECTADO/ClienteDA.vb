Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class ClienteDA
    Dim cn As New SqlConnection(ConnectionStrings("cno").ConnectionString)
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Public Function ClienteListar() As DataSet
        da = New SqlDataAdapter("USP_CLIENTELISTAR_DS", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        ds = New DataSet
        da.Fill(ds, "Clientes")
        ds.Tables("Clientes").PrimaryKey =
            New DataColumn() {ds.Tables("Clientes").Columns(0)}
        Return ds
    End Function


End Class
