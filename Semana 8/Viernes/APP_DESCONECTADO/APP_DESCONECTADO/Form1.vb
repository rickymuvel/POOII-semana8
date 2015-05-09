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

    Private Sub dgClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgClientes.SelectionChanged
        Try
            txtCodigo.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(0).Value()
            txtCliente.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(1).Value()
            txtDireccion.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(2).Value()
            cboPais.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(3).Value()
            txtTelefono.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(4).Value()
        Catch ex As Exception
            MessageBox.Show("Seleccione una fila de datos", "Aviso", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        obj.ClienteInsertar(txtCodigo.Text, txtCliente.Text, txtDireccion.Text, cboPais.SelectedValue, txtTelefono.Text)
    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        obj.ClienteActualizar(txtCodigo.Text, txtCliente.Text, txtDireccion.Text, cboPais.SelectedValue, txtTelefono.Text)
    End Sub


    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        obj.ClienteBaja(txtCodigo.Text)
    End Sub


    Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        obj.SincronizarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        For Each objeto As Object In Me.Controls
            If TypeOf objeto Is TextBox Then objeto.Text = String.Empty
        Next
        cboPais.SelectedIndex = -1
        txtCodigo.Focus()
    End Sub
End Class
