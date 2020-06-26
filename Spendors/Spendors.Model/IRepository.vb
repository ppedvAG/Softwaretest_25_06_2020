Public Interface IRepository

    Function GetAll(Of T As Entity)() As IEnumerable(Of T)
    Function GetById(Of T As Entity)(id As Integer) As T
    Sub Add(Of T As Entity)(entity As T)
    Sub Delete(Of T As Entity)(entity As T)

    Sub Save()


End Interface
