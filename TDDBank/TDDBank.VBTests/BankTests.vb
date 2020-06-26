Imports Microsoft.QualityTools.Testing.Fakes
Imports NUnit.Framework

<TestFixture>
Public Class BankTests

    <Test>
    Sub IsOpen()

        Dim oh = New OpeningHours()

        Dim result = oh.IsOpen(New DateTime(2020, 6, 26, 12, 0, 0))

        Assert.IsTrue(Not Not result)

    End Sub

    <Test>
    Sub IsNowOpenMitFakes()
        Using ShimsContext.Create()

            Dim oh = New OpeningHours()

            Dim metodeAlsFunc As Func(Of Integer, String, Long) = Function()
                                                                      Return 3456789345678
                                                                  End Function

            Dim mthodeAlsActio As Action(Of String) = Sub(txt As String)
                                                          Console.WriteLine(txt)
                                                      End Sub


            System.Fakes.ShimDateTime.NowGet = Function() New DateTime(2020, 6, 26, 20, 0, 0)
            System.Fakes.ShimDateTime.NowGet = Function()
                                                   Return New DateTime(2020, 6, 26, 20, 0, 0)
                                               End Function

            System.Fakes.ShimDateTime.NowGet = AddressOf GetTestTime

            Assert.IsFalse(oh.IsNowOpen)

        End Using
    End Sub

    Private Function GetTestTime() As Date
        Return New DateTime(2020, 6, 26, 20, 0, 0)
    End Function
End Class
