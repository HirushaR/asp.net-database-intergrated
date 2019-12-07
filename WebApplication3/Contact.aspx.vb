Imports System.Data
Imports System.Data.SqlClient


Public Class Contact1
    Inherits System.Web.UI.Page
    Dim con As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\hiru\works\C#web\WebApplication3\webtest01.mdf;Integrated Security=True;Connect Timeout=30")




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            btnDelete.Enabled = False
        End If



    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        Clear()


    End Sub


    Public Sub Clear()
        hfContactID.Value = ""
        txtName.Text = txtMobile.Text = txtAddress.Text = ""
        LblErrorMessage.Text = LblSuccessMessage.Text = ""
        btnSave.Text = "Save"
        btnDelete.Enabled = False

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If (con.State = ConnectionState.Closed) Then
            con.Open()
            Dim cmd As New SqlCommand("UserCreateOrUpdate", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", 1)
            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim())
            cmd.Parameters.AddWithValue("@mobile", txtMobile.Text.Trim())
            cmd.Parameters.AddWithValue("@adderss", txtAddress.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
            Clear()
            If hfContactID.Value = "" Then
                LblSuccessMessage.Text = "sava successfully"
            Else
                LblSuccessMessage.Text = "update"
            End If
        End If

    End Sub
End Class