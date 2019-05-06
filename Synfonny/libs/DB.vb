Public Class DB
    Inherits Conexion

    Private datos As DataTable
    Private bool As Boolean

    'SET SENTENCIAS y ATTRIBUTOS SQL
    Public Function table(ByVal t As Object) As DB
        Me.setTable(t)
        Return Me
    End Function

    Public Function selects(ByVal attr() As Object) As DB
        Me.setAttributes(attr)
        Return Me
    End Function

    Public Function selectConcat(ByVal attr() As Object) As DB
        Me.setAttributesConcat(attr)
        Return Me
    End Function


    Public Function join(ByVal t2 As Object, ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.innerJoin(t2, val1, val2)
        Return Me
    End Function

    Public Function where(ByVal val1 As Object, ByVal signo As Object, ByVal val2 As Object) As DB
        Me.setWhere(val1, signo, val2, "AND")
        Return Me
    End Function

    Public Function where(ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.setWhere(val1, "=", val2, "AND")
        Return Me
    End Function

    Public Function orWhere(ByVal val1 As Object, ByVal signo As Object, ByVal val2 As Object) As DB
        Me.setWhere(val1, signo, val2, "OR")
        Return Me
    End Function

    Public Function orWhere(ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.setWhere(val1, "=", val2, "OR")
        Return Me
    End Function


    'QUERIES PREPARADAS
    Public Function createBy(ByVal attr() As Object, ByVal val() As Object) As Boolean
        Me.setAttributes(attr)
        Me.setValues(val)
        Me.insertInto()
        Return Me.query(Me.generate())
    End Function

    Public Function allBy() As DataTable
        Me.selectFrom()
        Return Me.queryReturn(Me.generate())
    End Function

    Public Function findBy(ByVal row As Object, ByVal id As Object) As DataTable
        Me.selectFrom()
        Me.where(row, id)
        Return Me.queryReturn(Me.generate())
    End Function

    Public Function updateBy(ByVal row As Object, ByVal id As Object, ByVal attr As Object, ByVal val() As Object) As Boolean
        Me.setAttributes(attr)
        Me.setValues(val)
        Me.keyValue()
        Me.updateSet()
        Me.where(row, id)
        Return Me.query(Me.generate())
    End Function


    Public Function deleteBy(ByVal row As Object, ByVal id As Object) As Boolean
        Me.deleteFrom()
        Me.where(row, id)
        Return Me.query(Me.generate())
    End Function

    Public Function rawDataTable(ByVal sqlRaw As Object) As DataTable
        Return Me.queryReturn(sqlRaw)
    End Function

    Public Function raw(ByVal sqlRaw As Object) As Boolean
        Return Me.query(sqlRaw)
    End Function


    'EJECUTAR CONSULTA DE RETORNO
    Public Function getBy() As DataTable
        Me.selectFrom()
        Return Me.queryReturn(Me.generate())
    End Function

    Public Function getBy(ByVal attr() As Object) As DataTable
        Me.setAttributes(attr)
        Me.selectFrom()
        Return Me.queryReturn(Me.generate())
    End Function

End Class
