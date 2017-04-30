Imports System.Data
Imports System.Data.SqlClient



Public Class StudentOverallAttendanceForm
    Dim cn As SqlConnection
    Dim Query As String
    Dim cmd As SqlCommand

    Dim reader As SqlDataReader
    Dim SUBJ = TrackAttendanceForm.subject
    Dim SEM = TrackAttendanceForm.sem
    Dim DIV = TrackAttendanceForm.div


    Private Sub StudentOverallAttendanceForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        showData.DataSource = Getlist()
    End Sub
    Private Function getlist() As DataTable
        Dim dtemployees As New DataTable
        Dim SUBJ = TrackAttendanceForm.subject

        MessageBox.Show(SEM & SUBJ)



        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\AKAV\Documents\amsdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        cn.Open()



        Query = "select * from sem" & SEM & " where div='" & DIV & "'"

        cmd = New SqlCommand(Query, cn)
        reader = cmd.ExecuteReader()


        dtemployees.Load(reader)



        Return dtemployees


    End Function


    Private Sub backButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles backButton.Click
        MainScreen.Show()
        Me.Close()
    End Sub

    Private Sub classHeader_Click(ByVal sender As Object, ByVal e As EventArgs) Handles classHeader.Click

    End Sub

    Private Sub showData_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles showData.CellContentClick

    End Sub

End Class