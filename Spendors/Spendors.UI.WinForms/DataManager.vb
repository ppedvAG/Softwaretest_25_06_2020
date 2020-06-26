Imports Spendors.Model

Public Class DataManager

    ReadOnly Property Repository As IRepository

    Sub New(repo As IRepository) '  DI (Dependency Injection) 
        Repository = repo
    End Sub

    Sub New()
        MyClass.New(New Data.EF.EfRepository())
    End Sub

    Function GetSpenderWithMostValuableOrgans() As Spender
        Return Repository.GetAll(Of Spender)().OrderByDescending(Function(x) x.Verfügbar.Sum(Function(y) y.Wert)).FirstOrDefault()
    End Function

End Class
