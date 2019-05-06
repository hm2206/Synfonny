Public Class Carbon

    Private tiempo As Object
    Private fecha As Object
    Private dia As Object
    Private mes As Object
    Private year As Object
    Private horas As Object

    Sub New()
        Me.tiempo = DateTime.Now
        Me.setFormat()
    End Sub

    Private Sub setFormat()
        Dim temp() As Object = Split(tiempo, " ")
        Me.fecha = temp(0)
        Me.horas = temp(1)
        Me.setDate()
    End Sub

    Function newFormat(ByVal tiempo As Object) As Carbon
        Me.tiempo = tiempo
        Me.setFormat()
        Return Me
    End Function

    Private Sub setDate()
        Dim temp() As Object = Split(fecha, "/")
        Me.dia = temp(0)
        Me.mes = temp(1)
        Me.year = temp(2)
    End Sub

    Public Function getDateFull() As String
        Return year & "-" & mes & "-" & dia
    End Function

    Public Function now() As String
        Return getDateFull() & " " & Me.horas
    End Function

End Class
