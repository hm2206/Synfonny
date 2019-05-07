Imports MySql.Data.MySqlClient

Public Class AdapterMysql

    Protected con As MySqlConnection
    Private cmd As MySqlCommand
    Private datos As New DataTable

    Sub New(ByVal host As Object, ByVal user As Object, ByVal password As Object, ByVal database As Object, ByVal port As Object)
        Try
            Dim conexion As New MySqlConnectionStringBuilder()
            conexion.Server = host
            conexion.UserID = user
            conexion.Password = password
            conexion.Port = port
            conexion.Database = database
            Me.con = New MySqlConnection(conexion.ToString)
        Catch ex As Exception
            MsgBox("no se pudó conectar a la base de datos")
        End Try
    End Sub

    Public Function querySimple(ByVal sql As String) As Boolean
        Try
            Me.con.Open()
            Me.cmd = New MySqlCommand(sql, Me.con)
            If Me.cmd.ExecuteNonQuery() Then
                Return True
            End If
        Catch ex As Exception
            Console.WriteLine(ex)
        Finally
            Me.con.Close()
        End Try
        Return False
    End Function

    Public Function queryRetorno(ByVal sql As String) As DataTable
        Try
            Me.datos.Clear()
            Me.con.Open()
            Me.cmd = New MySqlCommand(sql, Me.con)
            Me.cmd.CommandType = CommandType.Text
            Dim adp As New MySqlDataAdapter(cmd)
            adp.Fill(datos)
            Return datos
        Catch ex As Exception
            Return Nothing
        Finally
            Me.con.Close()
        End Try
    End Function

End Class



