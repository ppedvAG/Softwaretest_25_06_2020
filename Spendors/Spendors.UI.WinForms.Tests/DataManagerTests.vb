Imports Moq
Imports NUnit.Framework
Imports Spendors.Model

<TestFixture>
Public Class DataManagerTests

    <Test>
    Sub DataManager_GetSpenderWithMostValuableOrgans__()

        Dim dm As New DataManager(New TestRepo())

        Dim result = dm.GetSpenderWithMostValuableOrgans()

        Assert.AreEqual("Berta", result.Name)

    End Sub

    <Test>
    Sub DataManager_GetSpenderWithMostValuableOrgans_MOQ()

        Dim mock As New Mock(Of IRepository)
        mock.Setup(Function(x) x.GetAll(Of Spender)).Returns(Function()
                                                                 Dim s1 = New Spender With {
                                                                     .Name = "Hansi"
                                                                 }
                                                                 Dim s2 = New Spender With {
                                                                     .Name = "Berta"
                                                                 }

                                                                 s1.Verfügbar.Add(New Organ With {.Wert = 12})
                                                                 s2.Verfügbar.Add(New Organ With {.Wert = 8})
                                                                 s2.Verfügbar.Add(New Organ With {.Wert = 8})

                                                                 Return New List(Of Spender) From {
                                                                     s1,
                                                                     s2
                                                                 }
                                                             End Function)
        Dim dm As New DataManager(mock.Object)

        Dim result = dm.GetSpenderWithMostValuableOrgans()

        Assert.AreEqual("Berta", result.Name)

        mock.Verify(Function(x) x.GetAll(Of Spender), Times.Exactly(1))

    End Sub


End Class

Class TestRepo
    Implements IRepository

    Public Sub Add(Of T As Entity)(entity As T) Implements IRepository.Add
        Throw New NotImplementedException()
    End Sub

    Public Sub Delete(Of T As Entity)(entity As T) Implements IRepository.Delete
        Throw New NotImplementedException()
    End Sub

    Public Sub Save() Implements IRepository.Save
        Throw New NotImplementedException()
    End Sub

    Public Iterator Function GetAll(Of T As Entity)() As IEnumerable(Of T) Implements IRepository.GetAll

        Dim s1 = New Spender With {
            .Name = "Hansi"
        }
        Dim s2 = New Spender With {
            .Name = "Berta"
        }

        s1.Verfügbar.Add(New Organ With {.Wert = 12})
        s2.Verfügbar.Add(New Organ With {.Wert = 8})
        s2.Verfügbar.Add(New Organ With {.Wert = 8})

        Yield CType(s1, Entity)
        Yield CType(s2, Entity)
    End Function

    Public Function GetById(Of T As Entity)(id As Integer) As T Implements IRepository.GetById
        Throw New NotImplementedException()
    End Function
End Class
