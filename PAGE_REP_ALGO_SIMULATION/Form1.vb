Public Class Form1

    Private pageReferences As New List(Of Integer)  ' To store page references
    Private random As New Random()
    Private Frames As Integer = 1
    Private pageFaults As Integer = 0


    Private Sub FIFO_Algorithm(ByRef frameList As List(Of Integer),
                          ByRef frameSet As HashSet(Of Integer),
                          ByRef pointer As Integer,
                          pageNum As Integer,
                          ByRef isPageFault As Boolean)
        If Not frameSet.Contains(pageNum) Then
            isPageFault = True
            pageFaults += 1

            If frameList.Count < Frames Then
                frameList.Add(pageNum)
                frameSet.Add(pageNum)
            Else
                Dim removedPage As Integer = frameList(pointer)
                frameSet.Remove(removedPage)
                frameList(pointer) = pageNum
                frameSet.Add(pageNum)
                pointer = (pointer + 1) Mod Frames
            End If
        End If
    End Sub

    Private Sub LRU_Algorithm(ByRef frameList As List(Of Integer),
                         ByRef frameSet As HashSet(Of Integer),
                         pageNum As Integer,
                         ByRef isPageFault As Boolean)
        If frameSet.Contains(pageNum) Then
            frameList.Remove(pageNum)
            frameList.Add(pageNum)
        Else
            isPageFault = True
            pageFaults += 1

            If frameList.Count < Frames Then
                frameList.Add(pageNum)
                frameSet.Add(pageNum)
            Else
                Dim removedPage As Integer = frameList(0)
                frameSet.Remove(removedPage)
                frameList.RemoveAt(0)
                frameList.Add(pageNum)
                frameSet.Add(pageNum)
            End If
        End If
    End Sub

    Private Sub OPT_Algorithm(ByRef frameList As List(Of Integer),
                         ByRef frameSet As HashSet(Of Integer),
                         pageNum As Integer,
                         refIndex As Integer,
                         ByRef isPageFault As Boolean)
        If Not frameSet.Contains(pageNum) Then
            isPageFault = True
            pageFaults += 1

            If frameList.Count < Frames Then
                frameList.Add(pageNum)
                frameSet.Add(pageNum)
            Else
                Dim farthestIndex As Integer = -1
                Dim replaceIndex As Integer = 0

                For i As Integer = 0 To frameList.Count - 1
                    Dim nextUse As Integer = pageReferences.IndexOf(frameList(i), refIndex + 1)
                    If nextUse = -1 Then
                        replaceIndex = i
                        Exit For
                    ElseIf nextUse > farthestIndex Then
                        farthestIndex = nextUse
                        replaceIndex = i
                    End If
                Next

                frameSet.Remove(frameList(replaceIndex))
                frameList(replaceIndex) = pageNum
                frameSet.Add(pageNum)
            End If
        End If
    End Sub


    Private Sub DisplayAlgorithms()
        pnlOutput.Controls.Clear()
        pageFaults = 0

        ' Initialize data structures
        Dim frameList As New List(Of Integer)()
        Dim frameSet As New HashSet(Of Integer)()
        Dim pointer As Integer = 0 ' Only used for FIFO
        Dim xOffset As Integer = 0

        For refIndex As Integer = 0 To pageReferences.Count - 1
            Dim pageNum As Integer = pageReferences(refIndex)
            Dim isPageFault As Boolean = False

            ' Create visualization panel
            Dim stepPanel As New Panel()
            stepPanel.Width = 80
            stepPanel.Height = 490
            stepPanel.Left = xOffset
            stepPanel.Top = 20
            stepPanel.BackColor = Color.FromArgb(5, 27, 30)
            stepPanel.BorderStyle = BorderStyle.None

            ' Execute selected algorithm
            Select Case cmbAlgo.SelectedItem.ToString()
                Case "FIFO"
                    FIFO_Algorithm(frameList, frameSet, pointer, pageNum, isPageFault)
                Case "LRU"
                    LRU_Algorithm(frameList, frameSet, pageNum, isPageFault)
                Case "OPTIMAL"
                    OPT_Algorithm(frameList, frameSet, pageNum, refIndex, isPageFault)
            End Select

            ' Draw frames visualization
            Dim yOffset As Integer = 10
            For i As Integer = 0 To Frames - 1
                Dim lbl As New Label()
                lbl.Text = If(i < frameList.Count, frameList(i).ToString(), " ")
                lbl.Width = 80
                lbl.Height = 50
                lbl.Left = 20
                lbl.Top = yOffset
                lbl.TextAlign = ContentAlignment.MiddleCenter
                lbl.BackColor = If(i < frameList.Count, Color.FromArgb(206, 171, 205), Color.WhiteSmoke)
                lbl.BorderStyle = BorderStyle.FixedSingle
                lbl.Padding = New Padding(5)
                stepPanel.Controls.Add(lbl)
                yOffset += 40
            Next

            ' Add fault indicator
            Dim faultLabel As New Label()
            faultLabel.Width = 40
            faultLabel.Height = 30
            faultLabel.Left = 20
            faultLabel.Top = stepPanel.Height - 50
            faultLabel.TextAlign = ContentAlignment.MiddleCenter
            faultLabel.Text = If(isPageFault, "!", ".")
            faultLabel.Font = New Font(faultLabel.Font, FontStyle.Bold)
            faultLabel.ForeColor = If(isPageFault, Color.FromArgb(206, 171, 205), Color.FromArgb(129, 24, 68))
            stepPanel.Controls.Add(faultLabel)

            ' Add reference label
            Dim refLabel As New Label()
            refLabel.Text = pageNum.ToString()
            refLabel.Width = 60
            refLabel.Height = 30
            refLabel.Left = 20
            refLabel.Top = 5
            refLabel.TextAlign = ContentAlignment.MiddleCenter
            refLabel.Font = New Font(refLabel.Font, FontStyle.Bold)
            stepPanel.Controls.Add(refLabel)

            pnlOutput.Controls.Add(stepPanel)
            xOffset += 120
        Next

        ' Final UI updates
        lblPageFault.Text = pageFaults.ToString()
        pnlOutput.HorizontalScroll.Enabled = (xOffset > pnlOutput.Width)
        pnlOutput.AutoScroll = True
    End Sub


    Private Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ' Clear previous page references
        pageReferences.Clear()


        ' Generate random page references (between 20 and 25)
        Dim numPages As Integer = random.Next(20, 25)
        For i As Integer = 1 To numPages
            pageReferences.Add(random.Next(0, 10)) ' Store randomly generated numbers, between 0 to 9, in pageReferences
        Next

        ' Display reference string in the Label
        lblPageRef.Text = String.Join(" ", pageReferences)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' lists the no. of frames to 10 and adds them to the combo box
        For i As Integer = 1 To 10
            cmbFrame.Items.Add(i)
        Next

        'Add the algorithms to the combo box
        cmbAlgo.Items.Add("FIFO")
        cmbAlgo.Items.Add("LRU")
        cmbAlgo.Items.Add("OPTIMAL")

    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        lblRefString.Text = lblPageRef.Text
        lblFrames.Text = cmbFrame.Text


        'Check if there is a reference string, if no. of frames selected, and if an algorithm is selected
        If lblPageRef.Text = "--" Then
            MessageBox.Show("Please generate a reference string first.", "Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf cmbFrame.SelectedItem Is Nothing Then
            MessageBox.Show("Please select the number of frames.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf cmbAlgo.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an Algorithm", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        'Parse the selected number of frames from the combo box into an integer
        Frames = Integer.Parse(cmbFrame.SelectedItem.ToString())


        'Call the appropriate algorithm based on the selected item in the combo box
        DisplayAlgorithms()

        pageFaults = 0

    End Sub


End Class

