Imports System.Data.Entity
Imports Spendors.Model

Public Class EfContext
    Inherits DbContext

    Property Organe As DbSet(Of Organ)
    Property Spender As DbSet(Of Spender)

    Sub New(conString As String)
        MyBase.New(conString)
    End Sub

    Sub New()
        Me.New("Server=(localdb)\MSSQLLocaldb;Database=Spendors;Trusted_Connection=true")

    End Sub

End Class
