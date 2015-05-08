Public Class Form1
    'Instanciar la clase AccesoDatos
    Dim obj As New AccesoDatos

    Sub PaisListar()
        cboPais.DataSource = obj.PaisListar.Tables(0)
        cboPais.DisplayMember = "NombrePais"
        cboPais.ValueMember = "IdPais"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PaisListar()
        dgClientes.DataSource = obj.ClienteListar.Tables(0)
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dgClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgClientes.SelectionChanged
        txtCodigo.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(0).Value()
        txtCliente.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(1).Value()
        txtDireccion.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(2).Value()
        cboPais.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(3).Value()
        txtTelefono.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(4).Value()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        For Each objeto As Object In Me.Controls
            If TypeOf objeto Is TextBox Then objeto.Text = String.Empty
        Next
        cboPais.SelectedIndex = -1
        txtCodigo.Focus()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            obj.ClienteInsertar(txtCodigo.Text.ToUpper, txtCliente.Text,
                                 txtDireccion.Text.ToUpper, cboPais.SelectedValue.ToString,
                                 txtTelefono.Text)
            dgClientes.DataSource = obj.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            obj.ClienteActualizar(txtCodigo.Text.ToUpper, txtCliente.Text,
                                 txtDireccion.Text.ToUpper, cboPais.SelectedValue.ToString,
                                 txtTelefono.Text)
            dgClientes.DataSource = obj.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Try
            obj.ClienteBaja(txtCodigo.Text.ToUpper)
            dgClientes.DataSource = obj.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Form2.Show()
        'Me.Hide()
    End Sub
End Class
