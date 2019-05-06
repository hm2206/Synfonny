Public Class Model
    Inherits Eloquent

    Private CREATED_AT As Object = "created_at"
    Private UPDATED_AT As Object = "updated_at"
    Private timestamps As Boolean = True
    Private carbon As New Carbon


    'SETTERS
    Protected Sub setTimes(ByVal times As Boolean)
        Me.timestamps = times
    End Sub

    Public Function selects(ByVal attr As Object) As Model
        Me.db.selects(attr)
        Return Me
    End Function


    Public Function limite(ByVal valor As Object) As Model
        Me.db.limite(valor)
        Return Me
    End Function

    Public Function limite(ByVal valor1 As Object, ByVal valor2 As Object) As Model
        Me.db.limite(valor1, valor2)
        Return Me
    End Function

    Protected Function concat(ByVal obj1() As Object, ByVal obj2() As Object) As Object()
        Dim newObj(obj1.Length + obj1.Length) As Object
        Dim iter As Object = 0
        Dim limite As Object = 0
        For Each o As Object In obj1
            newObj(iter) = obj1(limite)
            iter += 1
            limite += 1
        Next

        limite = 0

        For Each o As Object In obj2
            newObj(iter) = obj2(limite)
            iter += 1
            limite += 1
        Next

        Return newObj
    End Function

    'SENTENCIAS

    Public Function where(ByVal val1 As Object, ByVal signo As Object, ByVal val2 As Object) As Model
        Me.db.where(val1, signo, val2)
        Return Me
    End Function

    Public Function where(ByVal val1 As Object, ByVal val2 As Object) As Model
        Me.db.where(val1, val2)
        Return Me
    End Function

    Public Function orWhere(ByVal val1 As Object, ByVal signo As Object, ByVal val2 As Object) As Model
        Me.db.orWhere(val1, signo, val2)
        Return Me
    End Function

    Public Function orWhere(ByVal val1 As Object, ByVal val2 As Object) As Model
        Me.db.orWhere(val1, val2)
        Return Me
    End Function


    'QUERIES PREPARATE
    Public Function all() As DataTable
        Return Me.db.gets()
    End Function

    Public Function find(ByVal id As Object) As Map
        Return New Map(Me, id)
    End Function

    Public Function first() As Map
        Dim t As DataTable = Me.db.limite(1).gets()
        Return New Map(Me, t)
    End Function

    Public Function create(ByVal attr() As Object, ByVal val() As Object) As Boolean
        If Me.timestamps Then
            attr = Me.concat(attr, {Me.CREATED_AT, Me.UPDATED_AT})
            val = Me.concat(val, {Me.carbon.now, Me.carbon.now})
        End If
        Return Me.db.create(attr, val)
    End Function

    Public Function update(ByVal attr() As Object, ByVal val() As Object) As Boolean
        Return Me.db.update(attr, val)
    End Function

    Public Function delete() As Boolean
        Return Me.db.delete()
    End Function


    Public Function gets() As DataTable
        Return Me.db.gets()
    End Function

    Public Function gets(ByVal attr() As Object) As DataTable
        Return Me.db.gets(attr)
    End Function


End Class
