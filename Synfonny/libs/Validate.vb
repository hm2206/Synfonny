Imports System
Imports System.Text.RegularExpressions

Public Class Validate

    Private pattern As String
    Private parse() As Object
    Private vista As Form
    Private self As Type = Me.GetType()
    Private isValidate As Boolean = True

    Public Sub New(ByVal vista As Form)
        Me.vista = vista
    End Sub

    Private Function recorevyValue(ByVal parse() As Object, ByVal tag As Object) As Object
        Dim recovery() As Object
        For Each p As Object In parse
            recovery = Split(p, ":")
            If recovery(0) = tag Then
                Return recovery(1)
            End If
        Next
        Return Nothing
    End Function

    Private Function parseMethods(ByVal methodParse As Object) As Object
        Dim methods() As Object = Split(methodParse, "|")
        Return methods
    End Function


    Private Function invokeValidate(ByVal name As Object, ByVal params() As Object) As Boolean
        Try
            Return Me.self.GetMethod(name).Invoke(Me, params)
        Catch ex As Exception
            Console.WriteLine("error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function verify(ByVal input As Object, ByVal tag As Object, ByVal validates() As Object) As Boolean
        For Each method As Object In validates
            If Me.invokeValidate(method, {input, tag}) Then
                Return True
            End If
        Next
        Return False
    End Function


    Public Sub preparate(ByVal inputs() As Object, ByVal tags() As Object)
        Try
            Dim tmp_parse(inputs.Length - 1) As Object
            Dim iter As Object = 0
            For Each input As Object In inputs
                tmp_parse(iter) = tags(iter) & ":" & input
                iter += 1
            Next
            Me.parse = tmp_parse
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub

    Public Function verifyBy(ByVal tags() As Object, ByVal methods() As Object) As Boolean
        Dim tmp_input As Object
        Dim tmp_methods() As Object
        Dim iter As Object = 0
        For Each tag As Object In tags
            tmp_input = Me.recorevyValue(Me.parse, tag)
            tmp_methods = Me.parseMethods(methods(iter))
            If Me.verify(tmp_input, tag, tmp_methods) = False Then
                Me.isValidate = False
                Return Me.isValidate
            End If
            iter += 1
        Next
        Me.isValidate = True
        Return Me.isValidate
    End Function


    Public Function nextTo() As Boolean
        Return Me.isValidate
    End Function

    'Métodos para validar intradas de tipo text

    Public Function required(ByVal input As Object, ByVal tags As Object) As Boolean
        If input.ToString <> "" Then
            Return True
        End If
        MsgBox("el campo " & tags & " es obligatorio")
        Return False
    End Function

    Public Function max(ByVal input As Object, ByVal tags As Object, ByVal maximo As Object) As Boolean
        If input.Length <= maximo Then
            Return True
        End If
        MsgBox("el campo " & tags & " solo debe tener como maximo " & maximo & " caracteres")
        Return False
    End Function

    Public Function min(ByVal input As Object, ByVal tags As Object, ByVal minimo As Object) As Boolean
        If input.Length >= minimo Then
            Return True
        End If
        MsgBox("el campo " & tags & " al menos debe tener " & minimo & " caracteres")
        Return False
    End Function

    Public Function number(ByVal input As Object, ByVal tags As Object) As Boolean
        Me.pattern = "^[0-9]+$"
        If Regex.IsMatch(input, pattern) Then
            Return True
        End If
        MsgBox("el campo " & tags & " debe se de tipo númerico")
        Return False
    End Function

    Public Function email(ByVal input As Object, ByVal tags As Object) As Boolean
        Me.pattern = "^[a-zA-Z0-9]+[@][a-z]+(.)[a-z]+$"
        If Regex.IsMatch(input, pattern) Then
            Return True
        End If
        MsgBox("el campo " & tags & " no es un email válido")
        Return False
    End Function

    Public Function unique(ByVal input As Object, ByVal tags As Object, ByVal obj As Model, ByVal id As Object) As Boolean
        Dim table As DataTable = obj.where(id, "=", input).gets()
        If table.Rows.Count = 0 Then
            Return True
        End If
        MsgBox("el valor " & input & " ya existe")
        Return False
    End Function

End Class
