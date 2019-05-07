Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class AdapterSQLServer

    Protected con As SqlConnection
    Private cmd As SqlCommand
    Private datos As New DataTable

    Sub New(ByVal host As Object, ByVal user As Object, ByVal password As Object, ByVal database As Object)
        Try
            Dim conexion As New SqlConnectionStringBuilder()
            conexion.DataSource = host
            conexion.UserID = user
            conexion.InitialCatalog = database
            conexion.IntegratedSecurity = True
            conexion.Password = password
        Catch ex As Exception
            MsgBox("no se pudó conectar a la base de datos")
        End Try

    End Sub

    Public Function querySimple(ByVal sql As String) As Boolean
        Try
            Me.con.Open()
            Me.cmd = New SqlCommand(sql, Me.con)
            If Me.cmd.ExecuteNonQuery() Then
                Return True
            End If
            Me.con.Close()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        Return True
    End Function

    Public Function queryRetorno(ByVal sql As String) As DataTable
        Try
            Me.datos.Clear()
            Me.con.Open()
            Me.cmd = New SqlCommand(sql, Me.con)
            Me.cmd.CommandType = CommandType.Text
            Dim adp As New SqlDataAdapter(cmd)
            adp.Fill(datos)
            con.Close()
            Return datos
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
