Imports Spendors.Model

Public Class EfRepository
    Implements IRepository

    Dim context As New EfContext

    Public Sub Add(Of T As Entity)(entity As T) Implements IRepository.Add
        'If GetType(T) = GetType(Organ) Then
        '    context.Organe.Add(entity As Organ)
        'End If

        context.Set(Of T).Add(entity)
    End Sub

    Public Sub Delete(Of T As Entity)(entity As T) Implements IRepository.Delete
        context.Set(Of T).Remove(entity)
    End Sub

    Public Sub Save() Implements IRepository.Save
        context.SaveChanges()
    End Sub

    Public Function GetAll(Of T As Entity)() As IEnumerable(Of T) Implements IRepository.GetAll
        Return context.Set(Of T).ToList()
    End Function

    Public Function GetById(Of T As Entity)(id As Integer) As T Implements IRepository.GetById
        Return context.Set(Of T).Find(id)
    End Function
End Class
