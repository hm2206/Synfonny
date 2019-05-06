Public Class Conexion

    Inherits DBConfig

    Private adaptador As Object

    Public Sub New()

        If Me.driver = "mysql" Then
            Me.adaptador = New AdapterMysql(Me.host, Me.user, Me.password, Me.dabaBase, Me.port)
        End If

    End Sub


    Public Function query(ByVal sql As Object) As Boolean
        Return Me.adaptador.querySimple(sql)
    End Function

    Public Function queryReturn(ByVal sql As Object) As DataTable
        Return Me.adaptador.queryRetorno(sql)
    End Function





End Class
