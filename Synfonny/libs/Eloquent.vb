
Public MustInherit Class Eloquent



    Protected db As New DB()
    Private className As String = ""
    Private self As Type
    Private table As Object = ""
    Protected datos As Object

    Sub New()

        'Obtener reflexion de una clase instanciada
        Me.self = Me.GetType()

        'SET de className, Obtenemos el nombre de la clase instanciada
        Me.className = Me.self.Name.ToLower

        'Configurar el nombre de la table
        Me.tableDefault()

    End Sub


    'SET Y GET => Table, PrimaryKey
    Public Function getTable() As Object
        Return Me.table
    End Function

    Protected Sub setTable(ByVal obj As Object)
        Me.table = obj
    End Sub

    'Tabla por default
    Private Sub tableDefault()
        Dim last As Object = Me.className.ElementAt(Me.className.Count - 1)
        If last = "y" Then
            Me.table = Me.className.Replace(last, "ies")
        Else
            Me.table = Me.className & "s"
        End If
        db.table(Me.table)
    End Sub

End Class
