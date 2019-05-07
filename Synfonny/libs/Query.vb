Public MustInherit Class Query

    Private sql As Object = ""
    Private t As Object = ""
    Private attributes() As Object = {"*"}
    Private values() As Object = {}
    Private wheres() As Object = {}
    Private key_value() As Object = {}
    Private joins() As Object = {}
    Private select_string As Object = ""
    Private value_string As Object = ""
    Private where_string As Object = ""
    Private join_string As Object = ""
    Private key_value_string As Object = ""
    Private decorador_string As Object = ""
    Private operation As Object = ""
    Private limite As Object


    Protected Function setTable(ByVal t As Object) As Query
        Me.t = t
        Return Me
    End Function


    'RESET DATOS
    Protected Sub reset()
        Me.attributes = {"*"}
        Me.wheres = {}
        Me.key_value = {}
        Me.joins = {}
        Me.select_string = ""
        Me.value_string = ""
        Me.where_string = ""
        Me.join_string = ""
        Me.key_value_string = ""
        Me.decorador_string = ""
        Me.operation = ""
        Me.limite = ""
    End Sub

    'SET de attribures y select_string
    Protected Function setAttributes(ByVal attr() As Object) As Query
        Dim iter As Object = 0

        'Verifica si hay datos en el arreglo attr, si hay datos lo almacena en Me.attributes
        If attr.Length > 0 Then
            Me.attributes = attr
        End If

        'Aqui se convierte un arreglo a un string
        ' Array = {"id", "name"} => String id, name
        select_string = Join(Me.attributes, ",")
        Return Me
    End Function

    Protected Sub setLimite(ByVal valor As Object)
        Me.limite = " LIMIT " & valor
    End Sub

    Protected Sub setLimite(ByVal valor1 As Object, ByVal valor2 As Object)
        Me.limite = " LIMIT " & valor1 & ", " & valor2 & " "
    End Sub

    Protected Function setAttributesConcat(ByVal attr() As Object) As Query
        Dim iter As Object = 0
        Dim tmp_attributes((Me.attributes.Length + attr.Length) - 1) As Object

        'Verifica si hay datos en el arreglo attr, si hay datos lo almacena en Me.attributes
        If attr.Length > 0 Then

            For Each obj As Object In Me.attributes
                tmp_attributes(iter) = obj
                iter += 1
            Next

            For Each obj As Object In attr
                tmp_attributes(iter) = obj
                iter += 1
            Next
            Me.attributes = tmp_attributes
        End If

        'Aqui se convierte un arreglo a un string
        ' Array = {"id", "name"} => String id, name
        select_string = Join(Me.attributes, ",")
        Return Me
    End Function


    'GET select_string
    Protected Function getAttributes() As Object
        Me.setAttributes({})
        Return Me.select_string
    End Function


    'SET values() y value_string
    Protected Function setValues(ByVal val() As Object) As Query
        Me.values = val
        Me.value_string = "'" & Join(Me.values, "','") & "'"
        Return Me
    End Function


    'KEY => VALUE de key(attributes()) => value(values())
    Protected Function keyValue() As Query
        If Me.attributes.Length > 0 And Me.values.Length > 0 And Me.attributes.Length = Me.values.Length Then
            Dim tmp_key_value(Me.attributes.Length - 1) As Object
            Dim iter As Object = 0
            For Each obj As Object In tmp_key_value
                tmp_key_value(iter) = Me.attributes(iter) & "='" & Me.values(iter) & "'"
                iter += 1
            Next

            Me.key_value = tmp_key_value
            Me.key_value_string = Join(Me.key_value, ", ")
        End If
        Return Me
    End Function

    'SET wheres() y where_string
    Protected Function setWhere(ByVal val1 As Object, ByVal signo As Object, ByVal val2 As Object, ByVal opt As Object) As Query
        Dim parse As Object = val1 & " " & signo & " '" & val2 & "'"
        Dim tmp_where(Me.wheres.Length + 1) As Object
        Dim iter As Object = 0
        If (Me.wheres.Count > 0) Then
            For Each sentencia As Object In Me.wheres
                tmp_where(iter) = sentencia
                iter += 1
            Next
            tmp_where(tmp_where.Length - 1) = opt & " " & parse
        Else
            tmp_where(0) = parse
        End If
        Me.wheres = tmp_where
        Me.where_string = " WHERE " & Join(Me.wheres, " ")
        Return Me
    End Function


    'SET joins() y join_string
    Protected Sub setJoin(ByVal t2 As Object, ByVal val1 As Object, ByVal val2 As Object, ByVal opt As Object)
        Dim parse As Object = t2 & " ON " & val1 & " = " & val2
        Dim tmp_join(Me.joins.Length + 1) As Object
        Dim iter As Object = 0
        If (Me.joins.Count > 0) Then
            For Each sentencia As Object In Me.joins
                tmp_join(iter) = sentencia
                iter += 1
            Next
            tmp_join(tmp_join.Length - 1) = opt & " " & parse
        Else
            tmp_join(0) = opt & " " & parse
        End If
        Me.joins = tmp_join
        Me.join_string = Join(Me.joins, " ")
    End Sub

    'QUERIES MULTITABLE
    Public Function innerJoin(ByVal t2 As Object, ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.setJoin(t2, val1, val2, "INNER JOIN")
        Return Me
    End Function

    Public Function leftJoin(ByVal t2 As Object, ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.setJoin(t2, val1, val2, "LEFT JOIN")
        Return Me
    End Function

    Public Function rightJoin(ByVal t2 As Object, ByVal val1 As Object, ByVal val2 As Object) As DB
        Me.setJoin(t2, val1, val2, "RIGHT JOIN")
        Return Me
    End Function



    'TRANSACCIONES SQL
    Protected Function selectFrom() As Query
        Me.getAttributes()
        Me.operation = "SELECT " & Me.select_string & " FROM " & Me.t & " "
        Return Me
    End Function

    Protected Function insertInto() As Query
        Me.operation = "INSERT INTO " & Me.t & "(" & Me.select_string & ") VALUES(" & Me.value_string & ") "
        Return Me
    End Function


    Protected Function updateSet() As Query
        Me.operation = "UPDATE " & t & " SET " & Me.key_value_string & " "
        Return Me
    End Function

    Protected Function deleteFrom() As Query
        Me.operation = "DELETE FROM " & Me.t & " "
        Return Me
    End Function


    'GENERADOR DE CONSULTA SQL
    Protected Function generate() As Object
        Me.sql = Me.operation & where_string & join_string & Me.decorador_string & Me.limite
        Me.reset()
        Return Me.sql
    End Function





End Class
