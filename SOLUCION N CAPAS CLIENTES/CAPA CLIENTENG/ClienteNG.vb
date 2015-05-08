' Aquí debería ser Capa_clienteDA pero como el profesor cambio el nombre
' por ese motivo el sistema se quedó con la información anterior.
Imports CAPA_DATAACCESS

Public Class ClienteNG
    Dim obj As New ClienteDA

    Public Function PaisListar() As DataSet
        Return obj.PaisListar()
    End Function

    Public Function ClienteListar() As DataSet
        Return obj.ClienteListar()
    End Function
    Public Sub ClienteInsertar(cod As String, nom As String, dir As String,
                               idpais As String, fono As String)
        obj.ClienteInsertar(cod, nom, dir, idpais, fono)
    End Sub

    Public Sub ClienteActualizar(cod As String, nom As String, dir As String,
                               idpais As String, fono As String)
        obj.ClienteActualizar(cod, nom, dir, idpais, fono)
    End Sub

    Public Sub ClienteBaja(cod As String)
        obj.ClienteBaja(cod)
    End Sub
End Class