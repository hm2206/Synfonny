Public Class Map

    Private rows As DataRow
    Private datos As DataTable
    Private model As Model
    Private this As Type
    Private key As Object
    Private PrimaryKey As Object = "id"
    Private attr As Reflection.FieldInfo()


    Sub New(ByVal model As Model, ByVal id As Object)

        'Configuracion general
        Me.model = model
        Me.this = model.GetType
        Me.attr = Me.this.GetFields
        Me.key = id

        'configurar llave primaria
        Me.settingPrimaryKey()

        ' Configuracion de la consulta
        Me.handle()

    End Sub

    Sub New(ByVal model As Model, ByVal table As DataTable)

        'Configuración general
        Me.model = model
        Me.this = model.GetType
        Me.attr = Me.this.GetFields

        'configurar llave primaria
        Me.settingPrimaryKey()


        ' Configuracion de la consulta
        Me.handle(table)

    End Sub

    Private Sub handle()
        Me.datos = model.where(Me.PrimaryKey, Me.key).gets()
        Me.validate()
    End Sub


    Private Sub handle(ByVal table As DataTable)
        Me.datos = table
        Me.validate()
    End Sub


    Private Sub validate()
        If Me.datos.Rows.Count > 0 Then
            Me.rows = Me.datos.Rows.Item(0)
            Me.key = Me.rows.Item(Me.PrimaryKey.ToString)
        End If
    End Sub

    Private Sub settingPrimaryKey()
        For Each field As Reflection.FieldInfo In Me.attr
            If field.Name = "primaryKey" Then
                Me.key = field.GetValue(Me.model)
            End If
        Next
    End Sub


    Public Function item(ByVal name As Object) As Object
        Try
            Return Me.rows.Item(name)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function update(ByVal attr() As Object, ByVal val() As Object) As Boolean
        Me.model.where(Me.PrimaryKey, Me.key)
        Dim query As Boolean = Me.model.update(attr, val)
        Me.handle()
        Return query
    End Function

    Public Function delete() As Boolean
        Me.model.where(Me.PrimaryKey, Me.key)
        Return Me.model.delete()
    End Function


    Public Function source() As DataTable
        Return Me.datos
    End Function

End Class
