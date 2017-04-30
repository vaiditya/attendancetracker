Imports System.Data.SqlClient

Public Class StudentListAttendanceForm
    Dim cn As SqlConnection
    Dim Query As String
    Dim Que As String
    Dim Qu As String
    Dim divque As String



    Dim cmd As SqlCommand
    Dim cmmd As SqlCommand
    Dim cmmmd As SqlCommand

    Dim reader As SqlDataReader
    Dim di As Char
    Dim i As Integer
    Dim data As String
    Dim count As Integer
    Dim c As Integer
    Dim total As Integer

    Dim SUBJ = TakeAttendanceForm.subject
    Dim SEM = TakeAttendanceForm.sem
    Dim DIV = TakeAttendanceForm.div


    'form load event
    Private Sub StudentListAttendanceForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load



        studentList.CheckOnClick = True




        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\AKAV\Documents\amsdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        cn.Open()



        Query = "select * from sem" & TakeAttendanceForm.sem & " where div='" & TakeAttendanceForm.div & "'"

        cmd = New SqlCommand(Query, cn)
        reader = cmd.ExecuteReader
        i = 1

        While reader.Read
            Dim sname = reader("name")
            sname = " " & i & "       " & sname

            studentList.Items.Add(sname)
            i = i + 1

        End While
        'MessageBox.Show("connection established")


    End Sub







    'studentList is listCheckBox
    Private Sub studentList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles studentList.SelectedIndexChanged
       


    End Sub


   

    'When this button is clicked changes are reflected in database
    Private Sub goButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles goButton.Click

        ' MessageBox.Show(SUBJ)
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\AKAV\Documents\amsdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        cn.Open()


        Query = " select " & SUBJ & " ,div,roll_no  from sem" & SEM & "  "

        cmd = New SqlCommand(Query, cn)


        For Each indexChecked In studentList.CheckedIndices
            ' The indexChecked variable contains the index of the item.
            'MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" + _
            ' studentList.GetItemCheckState(indexChecked).ToString() + ".")
            data = indexChecked.ToString() + 1
            ' MessageBox.Show(Data)

            reader = cmd.ExecuteReader

            While reader.Read
                If ((reader("div") = DIV) And reader("roll_no") = data) Then
                    ' MessageBox.Show(reader(SUBJ))

                    'MessageBox.Show(reader(SUBJ))
                    count = reader(SUBJ) + 1
                    ' MessageBox.Show(count)

                End If



            End While

           

            cn.Close()
            cn.Open()




            Que = " update sem" & SEM & " set " & SUBJ & "=" & count & " where  roll_no=" & data & " "



            cmmd = New SqlCommand(Que, cn)
            'reader = cmmd.ExecuteReader
            c = cmmd.ExecuteNonQuery
            ' MessageBox.Show(c)

            cn.Close()
            cn.Open()





        Next

        divque = " select " & SUBJ & " , roll_no  from sem" & SEM & ""
        cmmmd = New SqlCommand(divque, cn)
        reader = cmmmd.ExecuteReader

        If (DIV = "A") Then

            While reader.Read
                If (reader("roll_no") = 111) Then
                    total = reader(SUBJ) + 1
                    ' MessageBox.Show("done" & total)
                End If
            End While


        Else
            While reader.Read
                If (reader("roll_no") = 222) Then
                    total = reader(SUBJ) + 1
                    ' MessageBox.Show("done" & total)
                End If
            End While


        End If



        cn.Close()
        cn.Open()



        If (DIV = "A") Then
            Qu = " update sem" & SEM & " set " & SUBJ & "=" & total & " where  roll_no='111' "
            cmd = New SqlCommand(Qu, cn)
            'reader = cmmd.ExecuteReader
            c = cmd.ExecuteNonQuery
            'MessageBox.Show(c)
        Else
            Qu = " update sem" & SEM & " set " & SUBJ & "=" & total & " where  roll_no='222' "
            cmd = New SqlCommand(Qu, cn)
            'reader = cmmd.ExecuteReader
            c = cmd.ExecuteNonQuery
            'MessageBox.Show(c)
        End If










        MessageBox.Show("ATTENDANCE SUCCESSFULLY UPDATED")
        MainScreen.Show()
        Me.Close()

    End Sub

    Private Sub backButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles backButton.Click


        MainScreen.Show()
        Me.Close()
    End Sub
End Class