Public Class DBConfig

    Inherits Query

    'Solo comenta la región que no se va a utilizar
    'y descomenta la que si

#Region "MYSQL"
    Protected host As Object = "localhost"
    Protected user As Object = "root"
    Protected password As Object = ""
    Protected port As Object = "3306"
    Protected dabaBase As Object = "prueba"
    Protected driver As Object = "mysql"
#End Region


    '#Region "SQLSERVER"
    '    Protected host As Object = "(local)"
    '    Protected user As Object = "root"
    '    Protected password As Object = ""
    '    Protected port As Object = "1433"
    '    Protected dabaBase As Object = "prueba"
    '    Protected driver As Object = "sqls"
    '#End Region




End Class
