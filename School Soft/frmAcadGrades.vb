Imports System.Data.SqlClient
Public Class frmAcadGrades
    Dim duplicateFound As Boolean = True
    Dim cmdGrades As New SqlCommand
    Dim reader As SqlDataReader
    Dim rec As Integer = 0
    Dim queryType As String = Nothing
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmAcadGrades_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Me.IsMdiChild Then
            Dim PnlLoc As New Point
            PnlLoc.X = CInt((Me.Width - Me.pnlAcadGrades.Width) / 2)
            PnlLoc.Y = CInt((Me.Height - Me.pnlAcadGrades.Height) / 2.5)
            Me.pnlAcadGrades.Location = PnlLoc
        Else
            Me.pnlAcadGrades.Dock = DockStyle.Fill
        End If
    End Sub
    Private Sub frmAcadGrades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            loadCombos()
            loadList()
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub CLOSEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSEToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub loadCombos()

        Me.cboRemarkEng.Items.Clear()
        Me.cboRemarkEng.SelectedIndex = -1
        Me.cboRemarkSwa.Items.Clear()
        Me.cboRemarkSwa.SelectedIndex = -1

        cmdGrades.Connection = conn
        cmdGrades.CommandText = "SELECT DISTINCT remarkSwa FROM tblGrades WHERE (Status='True') ORDER BY remarkSwa"
        cmdGrades.CommandType = CommandType.Text
        cmdGrades.Parameters.Clear()
        reader = cmdGrades.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboRemarkSwa.Items.Add(IIf(DBNull.Value.Equals(reader!remarkSwa), "", reader!remarkSwa))
            End While
        End If
        reader.Close()

        cmdGrades.CommandText = "SELECT DISTINCT remarkEng FROM tblGrades WHERE (Status='True') ORDER BY remarkEng"
        cmdGrades.Parameters.Clear()
        reader = cmdGrades.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboRemarkEng.Items.Add(IIf(DBNull.Value.Equals(reader!remarkEng), "", reader!remarkEng))
            End While
        End If
        reader.Close()
    End Sub
    Private Sub loadList()
        Me.lstAcadGrades.Items.Clear()
        cmdGrades.Connection = conn
        cmdGrades.CommandText = "SELECT * FROM tblGrades WHERE (Status='True') ORDER BY upperMark desc"
        cmdGrades.CommandType = CommandType.Text
        cmdGrades.Parameters.Clear()
        reader = cmdGrades.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                li = Me.lstAcadGrades.Items.Add(IIf(DBNull.Value.Equals(reader!gradeName), "", reader!gradeName))
                li.SubItems.Add(IIf(DBNull.Value.Equals(reader!upperMark), "", reader!upperMark))
                li.SubItems.Add(IIf(DBNull.Value.Equals(reader!lowerMark), "", reader!lowerMark))
                li.SubItems.Add(IIf(DBNull.Value.Equals(reader!points), "", reader!points))
                li.SubItems.Add(IIf(DBNull.Value.Equals(reader!remarkSwa), "", reader!remarkSwa))
                li.SubItems.Add(IIf(DBNull.Value.Equals(reader!remarkEng), "", reader!remarkEng))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub txtUpperMark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpperMark.TextChanged
        If Me.txtUpperMark.Text.Trim.Length <= 0 Then
            Exit Sub
        End If
        If IsNumeric(Me.txtUpperMark.Text.Trim) = False Then
            MsgBox("Non-Numeric Values Detected", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Me.txtUpperMark.Text = ""
        End If
    End Sub

    Private Sub txtLowerMark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLowerMark.TextChanged
        If Me.txtLowerMark.Text.Trim.Length <= 0 Then
            Exit Sub
        End If
        If IsNumeric(Me.txtLowerMark.Text.Trim) = False Then
            MsgBox("Non-Numeric Values Detected", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Me.txtLowerMark.Text = ""
        End If
    End Sub
    Private Sub clearTexts()
        Me.txtGradeName.Text = ""
        Me.txtGradePoints.Text = ""
        Me.txtLowerMark.Text = ""
        Me.txtUpperMark.Text = ""
        Me.cboRemarkEng.Text = ""
        Me.cboRemarkSwa.Text = ""
        Me.cboRemarkEng.SelectedIndex = -1
        Me.cboRemarkSwa.SelectedIndex = -1
    End Sub
    Private Sub txtGradePoints_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGradePoints.TextChanged
        If Me.txtGradePoints.Text.Trim.Length <= 0 Then
            Exit Sub
        End If
        If IsNumeric(Me.txtGradePoints.Text.Trim) = False Then
            MsgBox("Non-Numeric Values Detected", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Me.txtGradePoints.Text = ""
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            clearTexts()
            loadCombos()
            loadList()
            Me.btnSave.Enabled = True
            Me.btnSaveChanges.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.txtGradeName.Enabled = True
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtGradeName.Text.Trim.Length <= 0 Then
            MsgBox("Missing Grade Name", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtGradePoints.Text.Trim.Length <= 0 Then
            MsgBox("Missing Grade points", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtLowerMark.Text.Trim.Length <= 0 Then
            MsgBox("Missing Lower Marks", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtUpperMark.Text.Trim.Length <= 0 Then
            MsgBox("Missing Upper Marks", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.cboRemarkEng.Text.Trim.Length <= 0 Then
            MsgBox("Missing English Remark", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.cboRemarkSwa.Text.Trim.Length <= 0 Then
            MsgBox("Missing Swahili Remark", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        i = 0
        maxrec = Me.lstAcadGrades.Items.Count - 1
        For i = 0 To maxrec
            If Me.lstAcadGrades.Items(i).Text.Trim = Me.txtGradeName.Text.Trim Then
                MsgBox("Grade name already added", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If
            If Me.lstAcadGrades.Items(i).SubItems(1).Text.Trim = Me.txtUpperMark.Text.Trim Then
                MsgBox("Upper Mark Already Added", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If
            If Me.lstAcadGrades.Items(i).SubItems(2).Text.Trim = Me.txtLowerMark.Text.Trim Then
                MsgBox("Lower Mark Already Added", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If
            If Me.lstAcadGrades.Items(i).SubItems(3).Text.Trim = Me.txtGradePoints.Text.Trim Then
                MsgBox("Points Already Added", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If
        Next

        li = Me.lstAcadGrades.Items.Add(Me.txtGradeName.Text.Trim)
        li.SubItems.Add(Me.txtUpperMark.Text.Trim)
        li.SubItems.Add(Me.txtLowerMark.Text.Trim)
        li.SubItems.Add(Me.txtGradePoints.Text.Trim)
        li.SubItems.Add(Me.cboRemarkSwa.Text.Trim)
        li.SubItems.Add(Me.cboRemarkEng.Text.Trim)
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            Me.lstAcadGrades.Items.Clear()
            clearTexts()
            loadCombos()
            Me.btnSave.Enabled = True
            Me.btnSaveChanges.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.txtGradeName.Enabled = True
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Me.lstAcadGrades.Items.Count = 0 Then
            MsgBox("No items in the list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.lstAcadGrades.SelectedItems.Count <= 0 Then
            MsgBox("Selected items to remove from list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        i = 0
        For i = 0 To Me.lstAcadGrades.SelectedItems.Count - 1
            Me.lstAcadGrades.SelectedItems(0).Remove()
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.lstAcadGrades.Items.Count <= 0 Then
            MsgBox("No items in the list to save", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        If Me.lstAcadGrades.Items.Count > 0 Then
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                dbconnection()
                Dim result As MsgBoxResult = MsgBox("Save Record?", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo, "Confirm Transaction")
                If result = MsgBoxResult.No Then
                    Exit Sub
                End If
                i = 0
                For i = 0 To Me.lstAcadGrades.Items.Count - 1
                    queryType = "INSERT"
                    cmdGrades.Connection = conn
                    cmdGrades.CommandType = CommandType.StoredProcedure
                    cmdGrades.CommandText = "sprocGrades"
                    cmdGrades.Parameters.Clear()
                    cmdGrades.Parameters.AddWithValue("@queryType", queryType)
                    cmdGrades.Parameters.AddWithValue("@regBy", userName.Trim)
                    cmdGrades.Parameters.AddWithValue("@dateOfReg", Date.Now)
                    cmdGrades.Parameters.AddWithValue("@gradeName", Me.lstAcadGrades.Items(i).Text.Trim)
                    cmdGrades.Parameters.AddWithValue("@upperMark", Me.lstAcadGrades.Items(i).SubItems(1).Text.Trim)
                    cmdGrades.Parameters.AddWithValue("@lowerMark", Me.lstAcadGrades.Items(i).SubItems(2).Text.Trim)
                    cmdGrades.Parameters.AddWithValue("@points", Me.lstAcadGrades.Items(i).SubItems(3).Text.Trim)
                    cmdGrades.Parameters.AddWithValue("@remarkSwa", Me.lstAcadGrades.Items(i).SubItems(4).Text.Trim)
                    cmdGrades.Parameters.AddWithValue("@remarkEng", Me.lstAcadGrades.Items(i).SubItems(5).Text.Trim)
                    rec = cmdGrades.ExecuteNonQuery
                Next
                If rec > 0 Then
                    MsgBox("Record/s Saved", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "SuccessFull Transaction")
                End If
                clearTexts()
                loadCombos()
                loadList()
                Me.queryType = Nothing
                Me.btnSave.Enabled = True
                Me.btnSaveChanges.Enabled = False
                Me.btnAdd.Enabled = True
                Me.btnRemove.Enabled = True
                Me.txtGradeName.Enabled = True
            Catch ex As Exception
                MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try

        End If
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATEToolStripMenuItem.Click
        If Me.lstAcadGrades.Items.Count = 0 Then
            MsgBox("No Items in the list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.lstAcadGrades.SelectedItems.Count <= 0 Then
            MsgBox("Selected Items to remove from list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.lstAcadGrades.SelectedItems.Count > 1 Then
            MsgBox("Selected One Item at a time", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        If Me.lstAcadGrades.SelectedItems.Count = 1 Then
            Me.btnSave.Enabled = False
            Me.btnSaveChanges.Enabled = True
            Me.btnAdd.Enabled = False
            Me.btnRemove.Enabled = False
            Me.txtGradeName.Enabled = False
            Me.txtGradeName.Text = Me.lstAcadGrades.SelectedItems(0).Text.Trim
            Me.txtUpperMark.Text = Me.lstAcadGrades.SelectedItems(0).SubItems(1).Text.Trim
            Me.txtLowerMark.Text = Me.lstAcadGrades.SelectedItems(0).SubItems(2).Text.Trim
            Me.txtGradePoints.Text = Me.lstAcadGrades.SelectedItems(0).SubItems(3).Text.Trim
            Me.cboRemarkEng.Text = Me.lstAcadGrades.SelectedItems(0).SubItems(5).Text.Trim
            Me.cboRemarkSwa.Text = Me.lstAcadGrades.SelectedItems(0).SubItems(4).Text.Trim
            Me.lstAcadGrades.Items.Clear()
        End If
    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        If Me.txtGradeName.Text.Trim.Length <= 0 Then
            MsgBox("Grade Name Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtUpperMark.Text.Trim.Length <= 0 Then
            MsgBox("Upper Mark Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtLowerMark.Text.Trim.Length <= 0 Then
            MsgBox("Lower Mark Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.txtGradePoints.Text.Trim.Length <= 0 Then
            MsgBox("Grade Points Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.cboRemarkSwa.Text.Trim.Length <= 0 Then
            MsgBox("Swahili Remarks Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.cboRemarkEng.Text.Trim.Length <= 0 Then
            MsgBox("English Remarks Missing", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            duplicateFound = True
            checkExistence()
            If duplicateFound = True Then
                MsgBox("Duplicate Found", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If
            Dim result As MsgBoxResult = MsgBox("Update Record?", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo, "Confirm Transaction")
            If result = MsgBoxResult.No Then
                Exit Sub
            End If
            queryType = "UPDATE"
            cmdGrades.Connection = conn
            cmdGrades.CommandType = CommandType.StoredProcedure
            cmdGrades.CommandText = "sprocGrades"
            cmdGrades.Parameters.Clear()
            cmdGrades.Parameters.AddWithValue("@queryType", queryType)
            cmdGrades.Parameters.AddWithValue("@regBy", userName.Trim)
            cmdGrades.Parameters.AddWithValue("@dateOfReg", Date.Now)
            cmdGrades.Parameters.AddWithValue("@gradeName", Me.txtGradeName.Text.Trim)
            cmdGrades.Parameters.AddWithValue("@upperMark", Me.txtUpperMark.Text.Trim)
            cmdGrades.Parameters.AddWithValue("@lowerMark", Me.txtLowerMark.Text.Trim)
            cmdGrades.Parameters.AddWithValue("@points", Me.txtGradePoints.Text.Trim)
            cmdGrades.Parameters.AddWithValue("@remarkSwa", Me.cboRemarkSwa.Text.Trim)
            cmdGrades.Parameters.AddWithValue("@remarkEng", Me.cboRemarkEng.Text.Trim)
            rec = cmdGrades.ExecuteNonQuery
            If rec > 0 Then
                MsgBox("Record Updated", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "SuccessFull Transaction")
            End If
            clearTexts()
            loadCombos()
            loadList()
            Me.queryType = Nothing
            Me.btnSave.Enabled = True
            Me.btnSaveChanges.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.txtGradeName.Enabled = True
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub checkExistence()
        cmdGrades.Connection = conn
        cmdGrades.CommandType = CommandType.Text
        cmdGrades.CommandText = "SELECT * FROM tblGrades WHERE (Status='True') AND (gradeName=@gradeName) AND (uppermark=@upperMark) " & _
            vbNewLine & "AND (lowerMark=@lowerMark) AND (points=@points) AND (remarkSwa=@remarkSwa) AND (remarkSwa=@remarkSwa)"
        cmdGrades.Parameters.Clear()
        cmdGrades.Parameters.AddWithValue("@gradeName", Me.txtGradeName.Text.Trim)
        cmdGrades.Parameters.AddWithValue("@upperMark", Me.txtUpperMark.Text.Trim)
        cmdGrades.Parameters.AddWithValue("@lowerMark", Me.txtLowerMark.Text.Trim)
        cmdGrades.Parameters.AddWithValue("@points", Me.txtGradePoints.Text.Trim)
        cmdGrades.Parameters.AddWithValue("@remarkSwa", Me.cboRemarkSwa.Text.Trim)
        cmdGrades.Parameters.AddWithValue("@remarkEng", Me.cboRemarkEng.Text.Trim)
        reader = cmdGrades.ExecuteReader
        If reader.HasRows = True Then
            duplicateFound = True
        ElseIf reader.HasRows = False Then
            duplicateFound = False
        End If
        reader.Close()
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        If Me.lstAcadGrades.Items.Count = 0 Then
            MsgBox("No Items in the list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.lstAcadGrades.SelectedItems.Count <= 0 Then
            MsgBox("Selected Items to remove from list", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.lstAcadGrades.SelectedItems.Count > 1 Then
            MsgBox("Selected One Item at a time", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        If Me.lstAcadGrades.SelectedItems.Count = 1 Then
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                dbconnection()
                Dim result As MsgBoxResult = MsgBox("Delete Record?", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo, "Confirm Transaction")
                If result = MsgBoxResult.No Then
                    Exit Sub
                End If
                queryType = "DELETE"
                cmdGrades.Connection = conn
                cmdGrades.CommandType = CommandType.StoredProcedure
                cmdGrades.CommandText = "sprocGrades"
                cmdGrades.Parameters.Clear()
                cmdGrades.Parameters.AddWithValue("@queryType", queryType)
                cmdGrades.Parameters.AddWithValue("@regBy", userName.Trim)
                cmdGrades.Parameters.AddWithValue("@dateOfReg", Date.Now)
                cmdGrades.Parameters.AddWithValue("@gradeName", Me.lstAcadGrades.SelectedItems(0).Text.Trim)
                cmdGrades.Parameters.AddWithValue("@upperMark", Me.lstAcadGrades.SelectedItems(0).SubItems(1).Text.Trim)
                cmdGrades.Parameters.AddWithValue("@lowerMark", Me.lstAcadGrades.SelectedItems(0).SubItems(2).Text.Trim)
                cmdGrades.Parameters.AddWithValue("@points", Me.lstAcadGrades.SelectedItems(0).SubItems(3).Text.Trim)
                cmdGrades.Parameters.AddWithValue("@remarkSwa", Me.lstAcadGrades.SelectedItems(0).SubItems(4).Text.Trim)
                cmdGrades.Parameters.AddWithValue("@remarkEng", Me.lstAcadGrades.SelectedItems(0).SubItems(5).Text.Trim)
                rec = cmdGrades.ExecuteNonQuery
                If rec > 0 Then
                    MsgBox("Record Deleted", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "SuccessFull Transaction")
                End If
                clearTexts()
                loadCombos()
                loadList()
                Me.queryType = Nothing
                Me.btnSave.Enabled = True
                Me.btnSaveChanges.Enabled = False
                Me.btnAdd.Enabled = True
                Me.btnRemove.Enabled = True
                Me.txtGradeName.Enabled = True
            Catch ex As Exception
                MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub
End Class