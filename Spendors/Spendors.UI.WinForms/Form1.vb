Imports Spendors.Model

Public Class Form1

    Dim manager As New DataManager

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = manager.Repository.GetAll(Of Spender)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        manager.Repository.Save()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result = manager.GetSpenderWithMostValuableOrgans()
        MessageBox.Show($"[{result.Id}] {result.Name}")
    End Sub
End Class
