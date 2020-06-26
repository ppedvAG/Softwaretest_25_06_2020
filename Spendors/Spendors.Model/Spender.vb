Public Class Spender
    Inherits Entity

    Property Name As String
    Property GebDatum As Date
    Overridable Property Verfügbar As HashSet(Of Organ) = New HashSet(Of Organ)
    Property Blutgruppe As String

End Class
