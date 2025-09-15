Imports System.Data.SqlClient

Public Class frmProducts
    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCakes()
        LoadIcing()
        LoadTopping()
    End Sub

    ' === Cakes Table ===
    Private Sub LoadCakes()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT * FROM Cake", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCakes.DataSource = dt
        End Using
    End Sub

    ' === Icing Table ===
    Private Sub LoadIcing()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT * FROM Icing", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvIcing.DataSource = dt
        End Using
    End Sub

    ' === Toppings Table ===
    Private Sub LoadTopping()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT * FROM Topping", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvTopping.DataSource = dt
        End Using
    End Sub

    Private Sub dgvCakes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCakes.CellContentClick
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIcing.CellContentClick
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTopping.CellContentClick
    End Sub

    Private Sub dgvIcings_TextChanged(sender As Object, e As EventArgs) Handles dgvIcings.TextChanged

    End Sub
End Class
