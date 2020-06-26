Imports System.Text
Imports AutoFixture
Imports FluentAssertions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Spendors.Model

<TestClass()>
Public Class EfContextTests

    <TestMethod()>
    Public Sub EfContext_can_create_new_db()

        Using con As New EfContext()
            If con.Database.Exists() Then
                con.Database.Delete()
            End If

            con.Database.Create()
            'Assert.IsTrue(con.Database.Exists())
            con.Database.Exists().Should().BeTrue()
        End Using
    End Sub


    <TestMethod()>
    Public Sub EfContext_can_CRUD_Spender()

        Dim spender As New Spender With {
            .Name = $"Fred Feuerstein {Guid.NewGuid()}",
            .Blutgruppe = "rot",
            .GebDatum = New Date(1980, 11, 11)
        }

        Dim newName = $"Wilma Feuestein {Guid.NewGuid()}"

        'CREATE
        Using con As New EfContext()
            con.Spender.Add(spender)
            con.SaveChanges()
        End Using

        'READ + UPDATE
        Using con As New EfContext()
            Dim loaded = con.Spender.Find(spender.Id)
            'Assert.AreEqual(spender.Name, loaded.Name)
            loaded.Name.Should().Be(spender.Name)
            loaded.GebDatum.Month.Should().BePositive()

            loaded.Name = newName
            con.SaveChanges()
        End Using

        'check UPDATE + DELETE
        Using con As New EfContext()
            Dim loaded = con.Spender.Find(spender.Id)
            loaded.Name.Should().Be(newName)

            con.Spender.Remove(loaded)
            con.SaveChanges()
        End Using

        'check DELETE
        Using con As New EfContext()
            Dim loaded = con.Spender.Find(spender.Id)
            loaded.Should().BeNull()
        End Using

    End Sub

    <TestMethod>
    Sub EfContext_Spender_insert_and_read_with_AutoFixture_Fluentassertion()

        Dim fix = New Fixture
        fix.Behaviors.Add(New OmitOnRecursionBehavior())
        Dim spender = fix.Create(Of Spender)

        Using con As New EfContext()
            con.Spender.Add(spender)
            con.SaveChanges()
        End Using

        Using con As New EfContext()
            Dim loaded = con.Spender.Find(spender.Id)
            loaded.Should().BeEquivalentTo(spender, Function(x)
                                                        x.IgnoringCyclicReferences()
                                                        'x.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation)).WhenTypeIs<DateTime>();
                                                        x.Using(Of Date)(Function(ctx) ctx.Subject.Should().BeCloseTo(ctx.Expectation, 100)).WhenTypeIs(Of Date)()
                                                        Return x
                                                    End Function)
        End Using



    End Sub


End Class