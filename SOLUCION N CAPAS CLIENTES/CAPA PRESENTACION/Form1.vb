Imports CAPA_CLIENTENG

Public Class Form1
    Dim objNG As New ClienteNG

    Sub PaisListar()
        cboPais.DataSource = objNG.PaisListar.Tables(0)
        cboPais.DisplayMember = "NombrePais"
        cboPais.ValueMember = "IdPais"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PaisListar()
        dgClientes.DataSource = objNG.ClienteListar.Tables(0)
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub dgClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgClientes.SelectionChanged
        Try
            txtCodigo.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(0).Value()
            txtCliente.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(1).Value()
            txtDireccion.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(2).Value()
            cboPais.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(3).Value()
            txtTelefono.Text = dgClientes.Rows(dgClientes.CurrentRow.Index).Cells(4).Value()
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar una fila con datos")
        End Try
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
            objNG.ClienteInsertar(txtCodigo.Text.ToUpper, txtCliente.Text,
                                 txtDireccion.Text.ToUpper, cboPais.SelectedValue.ToString,
                                 txtTelefono.Text)
            dgClientes.DataSource = objNG.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            objNG.ClienteActualizar(txtCodigo.Text.ToUpper, txtCliente.Text,
                                 txtDireccion.Text.ToUpper, cboPais.SelectedValue.ToString,
                                 txtTelefono.Text)
            dgClientes.DataSource = objNG.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Try
            objNG.ClienteBaja(txtCodigo.Text.ToUpper)
            dgClientes.DataSource = objNG.ClienteListar.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "ERROR....")
        End Try
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
