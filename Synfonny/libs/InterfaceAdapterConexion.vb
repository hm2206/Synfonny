Public Interface InterfaceAdapterConexion
    Function querySimple(ByVal sql As Object) As Boolean

    Function queryRetorno(ByVal sql As Object) As DataTable

End Interface
