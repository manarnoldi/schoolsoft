Imports System.Data.SqlClient
Public Class frmAcadResultsSummary
    Dim reader As SqlDataReader
    Dim cmdResultsSummary As New SqlCommand
    Dim rec As Integer = 0
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAcadResultsSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            loadCombos()
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub loadCombos()
        Me.cboClass.Items.Clear()
        Me.cboClass.Text = ""
        Me.cboClass.SelectedIndex = -1

        Me.cboStream.Items.Clear()
        Me.cboStream.Text = ""
        Me.cboStream.SelectedIndex = -1

        Me.cboTerm.Items.Clear()
        Me.cboTerm.Text = ""
        Me.cboTerm.SelectedIndex = -1

        Me.cboYear.Items.Clear()
        Me.cboYear.Text = ""
        Me.cboYear.SelectedIndex = -1

        Me.cmdResultsSummary.Connection = conn
        Me.cmdResultsSummary.CommandType = CommandType.Text
        Me.cmdResultsSummary.CommandText = "SELECT DISTINCT className FROM tblClasses WHERE (status=1) ORDER BY className"
        Me.cmdResultsSummary.Parameters.Clear()
        reader = Me.cmdResultsSummary.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboClass.Items.Add(IIf(DBNull.Value.Equals(reader!className), "", reader!className))
            End While
        End If
        reader.Close()

        Me.cmdResultsSummary.CommandText = "SELECT DISTINCT stream FROM tblClasses WHERE (status=1) ORDER BY stream"
        Me.cmdResultsSummary.Parameters.Clear()
        reader = Me.cmdResultsSummary.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboStream.Items.Add(IIf(DBNull.Value.Equals(reader!stream), "", reader!stream))
            End While
        End If
        reader.Close()

        Me.cmdResultsSummary.CommandText = "SELECT DISTINCT termName FROM tblSchoolCalendar WHERE (status=1) ORDER BY termName"
        Me.cmdResultsSummary.Parameters.Clear()
        reader = Me.cmdResultsSummary.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboTerm.Items.Add(IIf(DBNull.Value.Equals(reader!termName), "", reader!termName))
            End While
        End If
        reader.Close()

        Me.cmdResultsSummary.CommandText = "SELECT DISTINCT year FROM tblSchoolCalendar WHERE (status=1) ORDER BY year"
        Me.cmdResultsSummary.Parameters.Clear()
        reader = Me.cmdResultsSummary.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Me.cboYear.Items.Add(IIf(DBNull.Value.Equals(reader!year), "", reader!year))
            End While
        End If
        reader.Close()
    End Sub
    Private Sub frmAcadResultsSummary_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Me.IsMdiChild Then
            Dim PnlLoc As New Point
            PnlLoc.X = CInt((Me.Width - Me.pnlResultSummary.Width) / 2)
            PnlLoc.Y = CInt((Me.Height - Me.pnlResultSummary.Height) / 2.5)
            Me.pnlResultSummary.Location = PnlLoc
        Else
            Me.pnlResultSummary.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        If Me.cboYear.Text.Trim.Length <= 0 Then
            MsgBox("Missing Year.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.cboTerm.Text.Trim.Length <= 0 Then
            MsgBox("Missing Term.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        ElseIf Me.rbnbroadclass.Checked = False And Me.rbnbroadgradeclass.Checked = False And Me.rbnbroadgradestream.Checked = False _
            And Me.rbnbroadstream.Checked = False And Me.rbnPointClass.Checked = False And Me.rbnPointStream.Checked = False And _
            Me.rbnSchSummaryGradeWise.Checked = False And Me.rbnSchSummaryMarkWise.Checked = False And _
            Me.rbnsubjectclass.Checked = False And Me.rbnsubjectstream.Checked = False Then
            MsgBox("Select Analysis Report.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
            Exit Sub
        End If
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dbconnection()
            Me.cmdResultsSummary.Connection = conn
            Me.cmdResultsSummary.CommandType = CommandType.Text
            Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblSchoolCalendar WHERE (termName=@termName) AND (year=@year) AND (status=1)"
            Me.cmdResultsSummary.Parameters.Clear()
            Me.cmdResultsSummary.Parameters.AddWithValue("@termName", Me.cboTerm.Text.Trim)
            Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
            reader = Me.cmdResultsSummary.ExecuteReader
            i = 0
            While reader.Read
                i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
            End While
            reader.Close()

            If i <= 0 Then
                MsgBox("Term Details not registered.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            If Me.rbnbroadstream.Checked = True Then
                If Me.cboStream.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Stream Name.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                ElseIf Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumMarkStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()


                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumMarkStream"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@stream", Me.cboStream.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsMarkClassStream
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumMarkStream.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumMarkStream.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumMarkStream.stream}=" & Chr(34) & Me.cboStream.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumMarkStream.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumMarkStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()

            ElseIf Me.rbnbroadclass.Checked = True Then
                If Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumMarkClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumMarkClass"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsMarkClass
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumMarkClass.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumMarkClass.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumMarkClass.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumMarkClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnbroadgradestream.Checked = True Then
                If Me.cboStream.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Stream Name.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                ElseIf Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumGradeStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumGradeStream"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@stream", Me.cboStream.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsGradeClassStream
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumGradeStream.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumGradeStream.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumGradeStream.stream}=" & Chr(34) & Me.cboStream.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumGradeStream.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumGradeStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnbroadgradeclass.Checked = True Then
                If Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumGradeClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumGradeClass"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsGradeClass
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumGradeClass.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumGradeClass.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumGradeClass.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumGradeClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnsubjectstream.Checked = True Then
                If Me.cboStream.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Stream Name.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                ElseIf Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSubSummaryStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandTimeout = 0
                Me.cmdResultsSummary.CommandText = "sprocTempERSubSummaryStream"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@stream", Me.cboStream.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsSubjectSummaryStream
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSubSummaryStream.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSubSummaryStream.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSubSummaryStream.stream}=" & Chr(34) & Me.cboStream.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSubSummaryStream.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSubSummaryStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnsubjectclass.Checked = True Then
                If Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSubSummaryClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandTimeout = 0
                Me.cmdResultsSummary.CommandText = "sprocTempERSubSummaryClass"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsSubjectSummaryClass
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSubSummaryClass.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSubSummaryClass.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSubSummaryClass.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSubSummaryClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnSchSummaryMarkWise.Checked = True Then
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSchSummaryMarks1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandTimeout = 0
                Me.cmdResultsSummary.CommandText = "sprocTempERSchSummaryMarks"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsSchoolSummaryMarkWise
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.SummaryInfo.ReportTitle = ("SCHOOL RESULTS SUMMARY MARK WISE FOR " & _
                    Me.cboTerm.Text.Trim & " " & Me.cboYear.Text.Trim).ToUpper
                RptResultsView.RecordSelectionFormula = "({tblTempERSchSummaryMarks.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSchSummaryMarks.year}=" & Me.cboYear.Text.Trim & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSchSummaryMarks1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()

            ElseIf Me.rbnSchSummaryGradeWise.Checked = True Then
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSchSummaryMarks1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandTimeout = 0
                Me.cmdResultsSummary.CommandText = "sprocTempERSchSummaryMarks"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsSchoolSummaryGradeWise
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.SummaryInfo.ReportTitle = ("SCHOOL RESULTS SUMMARY GRADE WISE FOR " & _
                    Me.cboTerm.Text.Trim & " " & Me.cboYear.Text.Trim).ToUpper
                RptResultsView.RecordSelectionFormula = "({tblTempERSchSummaryGrades.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSchSummaryGrades.year}=" & Me.cboYear.Text.Trim & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSchSummaryMarks1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()

            ElseIf Me.rbnPointStream.Checked = True Then
                If Me.cboStream.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Stream Name.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                ElseIf Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumPointsStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumPointsStream"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@stream", Me.cboStream.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsPointsStream
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumPointsStream.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumPointsStream.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumPointsStream.stream}=" & Chr(34) & Me.cboStream.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumPointsStream.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumPointsStream1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            ElseIf Me.rbnPointClass.Checked = True Then
                If Me.cboClass.Text.Trim.Length <= 0 Then
                    MsgBox("Missing Class.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If
                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "SELECT COUNT(*) AS count FROM tblTempERSumPointsClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                reader = Me.cmdResultsSummary.ExecuteReader
                i = 0
                While reader.Read
                    i = (IIf(DBNull.Value.Equals(reader!count), "", reader!count))
                End While
                reader.Close()

                If i > 0 Then
                    MsgBox("Some printing on the reporting criteria going on.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
                    Exit Sub
                End If

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.StoredProcedure
                Me.cmdResultsSummary.CommandText = "sprocTempERSumPointsClass"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.Parameters.AddWithValue("@term", Me.cboTerm.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@year", Me.cboYear.Text.Trim)
                Me.cmdResultsSummary.Parameters.AddWithValue("@class", Me.cboClass.Text.Trim)
                Me.cmdResultsSummary.ExecuteNonQuery()

                Dim RptResultsView As New crtAcadResultsPointsClass
                SetReportLogOn(RptResultsView)
                RptResultsView.SummaryInfo.ReportComments = fullName.Trim
                RptResultsView.RecordSelectionFormula = "({tblTempERSumPointsClass.className}=" & Chr(34) & Me.cboClass.Text.Trim & Chr(34) & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumPointsClass.year}=" & Me.cboYear.Text.Trim & ")"
                RptResultsView.RecordSelectionFormula += "AND ({tblTempERSumPointsClass.termName}=" & Chr(34) & Me.cboTerm.Text.Trim & Chr(34) & ")"
                frmResultsViewing.crtViewResultsSummary.ReportSource = RptResultsView
                frmResultsViewing.crtViewResultsSummary.Zoom(100)
                frmResultsViewing.crtViewResultsSummary.RefreshReport()
                frmResultsViewing.MdiParent = frmHome
                frmResultsViewing.Show()

                Me.cmdResultsSummary.Connection = conn
                Me.cmdResultsSummary.CommandType = CommandType.Text
                Me.cmdResultsSummary.CommandText = "DELETE FROM tblTempERSumPointsClass1"
                Me.cmdResultsSummary.Parameters.Clear()
                Me.cmdResultsSummary.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(Err.GetException.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "Error Detected")
        Finally
            Me.Cursor = Cursors.Arrow
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub rbnbroadstream_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnbroadstream.CheckedChanged
        If Me.rbnbroadstream.Checked = True Then
            Me.cboStream.Enabled = True
        ElseIf Me.rbnbroadstream.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbnbroadclass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnbroadclass.CheckedChanged
        If Me.rbnbroadclass.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboStream.Enabled = False
        ElseIf Me.rbnbroadclass.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbnbroadgradestream_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnbroadgradestream.CheckedChanged
        If Me.rbnbroadgradestream.Checked = True Then
            Me.cboStream.Enabled = True
        ElseIf Me.rbnbroadgradestream.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbnbroadgradeclass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnbroadgradeclass.CheckedChanged
        If Me.rbnbroadgradeclass.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboStream.Enabled = False
        ElseIf Me.rbnbroadgradeclass.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbnsubjectstream_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnsubjectstream.CheckedChanged
        If Me.rbnsubjectstream.Checked = True Then
            Me.cboStream.Enabled = True
        ElseIf Me.rbnsubjectstream.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbnsubjectclass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnsubjectclass.CheckedChanged
        If Me.rbnsubjectclass.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboStream.Enabled = False
        ElseIf Me.rbnsubjectclass.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub

    Private Sub rbSchSummaryMarkWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnSchSummaryMarkWise.CheckedChanged
        If Me.rbnSchSummaryMarkWise.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboClass.SelectedIndex = -1
            Me.cboStream.Enabled = False
            Me.cboClass.Enabled = False
        ElseIf Me.rbnSchSummaryMarkWise.Checked = False Then
            Me.cboStream.Enabled = True
            Me.cboClass.Enabled = True
        End If
    End Sub

    Private Sub rbSchSummaryGradeWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnSchSummaryGradeWise.CheckedChanged
        If Me.rbnSchSummaryGradeWise.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboClass.SelectedIndex = -1
            Me.cboStream.Enabled = False
            Me.cboClass.Enabled = False
        ElseIf Me.rbnSchSummaryGradeWise.Checked = False Then
            Me.cboStream.Enabled = True
            Me.cboClass.Enabled = True
        End If
    End Sub
    Private Sub rbPointStream_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnPointStream.CheckedChanged
        If Me.rbnPointStream.Checked = True Then
            Me.cboStream.Enabled = True
        ElseIf Me.rbnPointStream.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub
    Private Sub rbPointClass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnPointClass.CheckedChanged
        If Me.rbnPointClass.Checked = True Then
            Me.cboStream.SelectedIndex = -1
            Me.cboStream.Enabled = False
        ElseIf Me.rbnPointClass.Checked = False Then
            Me.cboStream.Enabled = True
        End If
    End Sub
    

    
End Class