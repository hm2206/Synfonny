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

    Public Function limite(ByVal valor As Object) As DB
        Me.setLimite(valor)
        Return Me
    End Function

    Public Function limite(ByVal valor1 As Object, ByVal valor2 As Object) As DB
        Me.setLimite(valor1, valor2)
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
    Public Function create(ByVal attr() As Object, ByVal val() As Object) As Boolean
        Me.setAttributes(attr)
        Me.setValues(val)
        Me.insertInto()
        Return Me.query(Me.generate())
    End Function

    Public Function update(ByVal attr As Object, ByVal val() As Object) As Boolean
        Me.setAttributes(attr)
        Me.setValues(val)
        Me.keyValue()
        Me.updateSet()
        Return Me.query(Me.generate())
    End Function


    Public Function delete() As Boolean
        Me.deleteFrom()
        Return Me.query(Me.generate())
    End Function

    Public Function rawReturn(ByVal sqlRaw As Object) As DataTable
        Return Me.queryReturn(sqlRaw)
    End Function

    Public Function raw(ByVal sqlRaw As Object) As Boolean
        Return Me.query(sqlRaw)
    End Function


    'EJECUTAR CONSULTA DE RETORNO
    Public Function gets() As DataTable
        Me.selectFrom()
        Return Me.queryReturn(Me.generate())
    End Function

    Public Function gets(ByVal attr() As Object) As DataTable
        Me.setAttributes(attr)
        Me.selectFrom()
        Return Me.queryReturn(Me.generate())
    End Function

End Class
