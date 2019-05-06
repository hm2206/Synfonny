Public Class Model
    Inherits Eloquent

    Private key As Object
    Private CREATED_AT As Object = "created_at"
    Private UPDATED_AT As Object = "updated_at"
    Private timestamps As Boolean = True
    Private carbon As New Carbon


    'SETTERS
    Public Sub setKey(ByVal newKey As Object)
        Me.key = newKey
    End Sub

    Public Function getKey() As Object
        Return Me.key
    End Function

    Protected Sub setTimes(ByVal times As Boolean)
        Me.timestamps = times
    End Sub

    Public Function selects(ByVal attr As Object) As Model
        Me.db.selects(attr)
        Return Me
    End Function


    Public Function concat(ByVal obj1() As Object, ByVal obj2() As Object) As Object()
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


    'QUERIES PREPARATE
    Public Function all() As DataTable
        Return Me.db.allBy()
    End Function

    Public Function find(ByVal id As Object) As Map
        Me.datos = Me.db.findBy(Me.getPrimaryKey, id)
        Return New Map(Me.datos)
    End Function

    Public Function create(ByVal attr() As Object, ByVal val() As Object) As Boolean
        If Me.timestamps Then
            attr = Me.concat(attr, {Me.CREATED_AT, Me.UPDATED_AT})
            val = Me.concat(val, {Me.carbon.now, Me.carbon.now})
        End If
        Return Me.db.createBy(attr, val)
    End Function

    Public Function update(ByVal attr() As Object, ByVal val() As Object) As Boolean
        Return Me.db.updateBy(Me.getPrimaryKey, Me.key, attr, val)
    End Function

    Public Function update(ByVal row As Object, ByVal id As Object, ByVal attr() As Object, ByVal val() As Object) As Boolean
        Return Me.db.updateBy(row, id, attr, val)
    End Function

    Public Function delete() As Boolean
        Return Me.db.deleteBy(Me.getPrimaryKey, Me.key)
    End Function

    Public Function delete(ByVal row As Object, ByVal id As Object) As Boolean
        Return Me.db.deleteBy(row, id)
    End Function



End Class
