Public Class Form1
    Dim obj As New ClienteDA

    Sub llenaPais()
        cboPais.DataSource = obj.PaisListar.Tables("Paises")
        cboPais.DisplayMember = "nombrePais"
        cboPais.ValueMember = "idPais"
    End Sub

    Sub llenaClientes()
        dgClientes.DataSource = obj.ClienteListar.Tables("Clientes")
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaPais()
        llenaClientes()
    End Sub
End Class
