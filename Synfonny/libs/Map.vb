Public Class Map

    Private rows As DataRow
    Private datos As DataTable


    Sub New(ByVal table As DataTable)
        Me.datos = table
        If table.Rows.Count > 0 Then
            Me.rows = table.Rows.Item(0)
        End If
    End Sub


    Public Function item(ByVal name As Object) As Object
        Try
            Return Me.rows.Item(name)
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function source() As DataTable
        Return Me.datos
    End Function

End Class
