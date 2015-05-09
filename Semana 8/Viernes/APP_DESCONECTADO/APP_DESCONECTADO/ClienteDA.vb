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

    Public Function PaisListar() As DataSet
        da = New SqlDataAdapter("USP_PAISLISTAR", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        ds = New DataSet
        da.Fill(ds, "Paises")
        Return ds
    End Function

    Public Sub ClienteInsertar(idCliente As String, NomCliente As String, _
                                    DirCliente As String, idPais As String, fono As String)
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(idCliente)

        ' Si está vacío
        If dr Is Nothing Then
            dr = ds.Tables("Clientes").NewRow
            dr("idCliente") = idCliente
            dr("nomCliente") = idCliente
            dr("dirCliente") = DirCliente
            dr("idPais") = idPais
            dr("fonoCliente") = fono
            dr("Activo") = True
            ds.Tables("Clientes").Rows.Add(dr)
            MessageBox.Show("Cliente registrado correctamente...", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El cliente ya se encuentra registrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub SincronizarDatos()
        da = New SqlDataAdapter("SELECT * FROM VENTAS.CLIENTES", cn)
        Dim sql As New SqlCommandBuilder(da)
        Try
            da.Update(ds, "Clientes")
            MessageBox.Show("Actualizado correctamente", "sistema", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ds.RejectChanges()
        End Try
    End Sub

    Public Sub ClienteActualizar(idCliente As String, NomCliente As String, _
                                    DirCliente As String, idPais As String, fono As String)

        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(idCliente)

        ' Si no está vacío.
        If Not dr Is Nothing Then
            dr = ds.Tables("Clientes").NewRow
            dr("nomCliente") = idCliente
            dr("dirCliente") = DirCliente
            dr("idPais") = idPais
            dr("fonoCliente") = fono
            MessageBox.Show("Cliente registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El cliente ya se encuentra registrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub ClienteBaja(idCliente As String)
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(idCliente)
        If Not dr Is Nothing Then
            dr.Delete()
            MessageBox.Show("Cliente eliminado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class
