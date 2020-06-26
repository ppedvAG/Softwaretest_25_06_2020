Public MustInherit Class Entity
    Property Id As Integer
    Property Created As DateTime = DateTime.Now
    Property Modified As DateTime = DateTime.Now
End Class

Public Class Spender
    Inherits Entity

    Property Name As String
    Property GebDatum As Date
    Overridable Property Verfügbar As HashSet(Of Organ) = New HashSet(Of Organ)
    Property Blutgruppe As String

End Class

Public Class Organ
    Inherits Entity

    Property Name As String
    Property Wert As Decimal
    Overridable Property Spender As Spender

End Class
