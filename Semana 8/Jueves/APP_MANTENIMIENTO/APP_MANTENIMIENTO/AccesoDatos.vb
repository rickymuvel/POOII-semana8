﻿Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class AccesoDatos
    Dim cn As New SqlConnection(ConnectionStrings("cno").ConnectionString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim ds As New DataSet

    Public Function PaisListar() As DataSet
        da = New SqlDataAdapter("usp_PaisListar", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        ds = New DataSet
        da.Fill(ds)
        Return ds
    End Function

    Public Function ClienteListar() As DataSet
        da = New SqlDataAdapter("usp_ClienteListado", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        ds = New DataSet
        da.Fill(ds)
        Return ds
    End Function

    'INSERTAR CLIENTE
    Public Sub ClienteInsertar(cod As String, nom As String, dir As String,
                               idpais As String, fono As String)
        cn.Open()
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ClienteInsertar"
        With cmd.Parameters
            .AddWithValue("@IdCliente", cod)
            .AddWithValue("@NomCliente", nom)
            .AddWithValue("@DirCliente", dir)
            .AddWithValue("@IdPais", idpais)
            .AddWithValue("@fonoCliente", fono)
        End With
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Cliente Registrado con EXITO....", "AVISO")
        Catch ex As Exception
            MessageBox.Show("ERROR......." + ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Public Sub ClienteActualizar(cod As String, nom As String, dir As String,
                               idpais As String, fono As String)
        cn.Open()
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ClienteActualizar"
        With cmd.Parameters
            .AddWithValue("@IdCliente", cod)
            .AddWithValue("@NomCliente", nom)
            .AddWithValue("@DirCliente", dir)
            .AddWithValue("@IdPais", idpais)
            .AddWithValue("@fonoCliente", fono)
        End With
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Cliente Actualizado con EXITO....", "AVISO")
        Catch ex As Exception
            MessageBox.Show("ERROR......." + ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Public Sub ClienteBaja(cod As String)
        cn.Open() 'abre la conexion
        cmd = New SqlCommand 'instancia el objeto sqlcommand
        cmd.Connection = cn 'establece la conexion que utilizara el command
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ClienteBaja" 'especifica el nombre del Store
        cmd.Parameters.AddWithValue("@IdCliente", cod)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("El Cliente fue dado de Baja....", "AVISO")
        Catch ex As Exception
            MessageBox.Show("ERROR......." + ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class
