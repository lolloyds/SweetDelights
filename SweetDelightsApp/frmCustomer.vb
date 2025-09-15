Imports System.Data.SqlClient

Public Class frmCustomer

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    Private Sub LoadCustomers()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT * FROM Customer", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCustomers.DataSource = dt
        End Using
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        ' Optional code
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        ' Optional code
    End Sub

    Private Sub dgvCustomers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellContentClick
        ' Optional code to handle clicks in the DataGridView
    End Sub

    ' --------------------- CRUD BUTTONS ---------------------

    ' SAVE (INSERT)
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using con As SqlConnection = GetConnection()
            con.Open()
            Dim cmd As New SqlCommand("INSERT INTO Customer (FirstName,LastName,ContactNumber,Email,StreetAddress,Barangay,City)
                                       VALUES (@fn,@ln,@cn,@em,@st,@br,@ct)", con)
            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text)
            cmd.Parameters.AddWithValue("@ln", txtLastName.Text)
            cmd.Parameters.AddWithValue("@cn", txtContactNumber.Text)
            cmd.Parameters.AddWithValue("@em", txtEmail.Text)
            cmd.Parameters.AddWithValue("@st", txtStreetAddress.Text)
            cmd.Parameters.AddWithValue("@br", txtBarangay.Text)
            cmd.Parameters.AddWithValue("@ct", txtCity.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Customer added.")
        End Using
        LoadCustomers()
    End Sub

    ' UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvCustomers.CurrentRow Is Nothing Then Return
        Dim id As Integer = dgvCustomers.CurrentRow.Cells("CustomerID").Value
        Using con As SqlConnection = GetConnection()
            con.Open()
            Dim cmd As New SqlCommand("UPDATE Customer SET FirstName=@fn,LastName=@ln,ContactNumber=@cn,Email=@em,
                                       StreetAddress=@st,Barangay=@br,City=@ct WHERE CustomerID=@id", con)
            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text)
            cmd.Parameters.AddWithValue("@ln", txtLastName.Text)
            cmd.Parameters.AddWithValue("@cn", txtContactNumber.Text)
            cmd.Parameters.AddWithValue("@em", txtEmail.Text)
            cmd.Parameters.AddWithValue("@st", txtStreetAddress.Text)
            cmd.Parameters.AddWithValue("@br", txtBarangay.Text)
            cmd.Parameters.AddWithValue("@ct", txtCity.Text)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Customer updated.")
        End Using
        LoadCustomers()
    End Sub

    ' DELETE
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvCustomers.CurrentRow Is Nothing Then Return
        Dim id As Integer = dgvCustomers.CurrentRow.Cells("CustomerID").Value
        Using con As SqlConnection = GetConnection()
            con.Open()
            Dim cmd As New SqlCommand("DELETE FROM Customer WHERE CustomerID=@id", con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Customer deleted.")
        End Using
        LoadCustomers()
    End Sub

    ' CLEAR
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Clear()
        txtLastName.Clear()
        txtContactNumber.Clear()
        txtEmail.Clear()
        txtStreetAddress.Clear()
        txtBarangay.Clear()
        txtCity.Clear()
    End Sub

    Private Sub dgvCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCustomers.SelectionChanged
        If dgvCustomers.CurrentRow IsNot Nothing Then
            txtFirstName.Text = dgvCustomers.CurrentRow.Cells("FirstName").Value.ToString()
            txtLastName.Text = dgvCustomers.CurrentRow.Cells("LastName").Value.ToString()
            txtContactNumber.Text = dgvCustomers.CurrentRow.Cells("ContactNumber").Value.ToString()
            txtEmail.Text = dgvCustomers.CurrentRow.Cells("Email").Value.ToString()
            txtStreetAddress.Text = dgvCustomers.CurrentRow.Cells("StreetAddress").Value.ToString()
            txtBarangay.Text = dgvCustomers.CurrentRow.Cells("Barangay").Value.ToString()
            txtCity.Text = dgvCustomers.CurrentRow.Cells("City").Value.ToString()
        End If
    End Sub

End Class


