Public Class Form1

    Private pageReferences As New List(Of Integer)  ' To store page references
    Private random As New Random()
    Private Frames As Integer = 1                   ' Stores number of frames
    Private pageFaults As Integer = 0               ' Stores number of page faults

    Private Sub FIFO_Algorithm(ByRef frameList As List(Of Integer),
                          ByRef frameSet As HashSet(Of Integer),
                          ByRef pointer As Integer,
                          pageNum As Integer,
                          ByRef isPageFault As Boolean)

        ' Checks if pageNum is not in memory (frameSet)
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
                           refIndex As Integer,
                           ByVal lastUsedMap As Dictionary(Of Integer, Integer),
                           ByRef isPageFault As Boolean)


        ' Checks if pageNum is in memory (frameSet)
        If frameSet.Contains(pageNum) Then
            ' Update last used time
            lastUsedMap(pageNum) = refIndex
        Else
            isPageFault = True
            pageFaults += 1

            If frameList.Count < Frames Then
                frameList.Add(pageNum)
                frameSet.Add(pageNum)
            Else
                ' Find least recently used page
                Dim lruPage As Integer = frameList.OrderBy(Function(p) If(lastUsedMap.ContainsKey(p), lastUsedMap(p), -1)).First()
                Dim indexToReplace As Integer = frameList.IndexOf(lruPage)

                ' Replace the least recently used page with the new page
                frameSet.Remove(lruPage)
                frameList(indexToReplace) = pageNum
                frameSet.Add(pageNum)
            End If

            ' Update last used time
            lastUsedMap(pageNum) = refIndex
        End If
    End Sub

    Private Sub OPT_Algorithm(ByRef frameList As List(Of Integer),
                         ByRef frameSet As HashSet(Of Integer),
                         pageNum As Integer,
                         refIndex As Integer,
                         ByRef isPageFault As Boolean)

        ' Checks if pageNum is not in memory (frameSet)
        If Not frameSet.Contains(pageNum) Then
            isPageFault = True
            pageFaults += 1

            ' Checks if a page reference can still be loaded into the memory
            If frameList.Count < Frames Then
                frameList.Add(pageNum)
                frameSet.Add(pageNum)

                ' 
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

        ' ====== ADD REFERENCE STRING HEADER ======
        Dim headerPanel As New Panel With {
        .Width = 95 * pageReferences.Count,
        .Height = 40,
        .Left = 10,
        .Top = 10,
        .BackColor = Color.FromArgb(5, 27, 30)
    }

        ' Add each reference number as a label in the header
        Dim refXOffset As Integer = 15
        For Each ref In pageReferences
            Dim refHeaderLabel As New Label With {
            .Text = ref.ToString(),
            .Width = 80,
            .Height = 30,
            .Left = refXOffset,
            .Top = 5,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(DefaultFont, FontStyle.Bold)
        }
            headerPanel.Controls.Add(refHeaderLabel)
            refXOffset += 95
        Next
        pnlOutput.Controls.Add(headerPanel)


        ' Initialize data structures
        Dim frameList As New List(Of Integer)()
        Dim frameSet As New HashSet(Of Integer)()
        Dim pointer As Integer = 0 ' Only used for FIFO
        Dim xOffset As Integer = 15

        Dim lastUsedMap As New Dictionary(Of Integer, Integer)()

        For refIndex As Integer = 0 To pageReferences.Count - 1
            Dim pageNum As Integer = pageReferences(refIndex)
            Dim isPageFault As Boolean = False

            ' Create visualization panel
            Dim stepPanel As New Panel With {
                .Width = 80,
                .Height = 490,
                .Left = xOffset,
                .Top = 30,
                .BackColor = Color.FromArgb(5, 27, 30),
                .BorderStyle = BorderStyle.None
            }

            ' Execute selected algorithm
            Select Case cmbAlgo.SelectedItem.ToString()
                Case "FIFO"
                    FIFO_Algorithm(frameList, frameSet, pointer, pageNum, isPageFault)
                Case "LRU"
                    LRU_Algorithm(frameList, frameSet, pageNum, refIndex, lastUsedMap, isPageFault)

                Case "OPTIMAL"
                    OPT_Algorithm(frameList, frameSet, pageNum, refIndex, isPageFault)
            End Select

            ' Draw frames visualization
            Dim yOffset As Integer = 10
            For i As Integer = 0 To Frames - 1

                Dim lbl As New Label With {
        .Text = If(i < frameList.Count, frameList(i).ToString(), " "),
        .Width = 80,
        .Height = 50,
        .Left = 10,
        .Top = yOffset,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BackColor = If(i < frameList.Count,
                        If(isPageFault AndAlso frameList(i) = pageNum,
                           Color.FromArgb(255, 100, 100), ' RED for replaced
                           Color.FromArgb(206, 171, 205)), ' Purple for normal
                        Color.WhiteSmoke),
        .BorderStyle = BorderStyle.FixedSingle,
        .Padding = New Padding(5)
    }

                stepPanel.Controls.Add(lbl)
                yOffset += 45
            Next


            ' Add fault indicator
            Dim faultLabel As New Label With {
                .Width = 80,
                .Height = 30,
                .Left = 10,
                .Top = stepPanel.Height - 50,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = If(isPageFault, "Fault", "Miss")
            }
            faultLabel.Font = New Font(faultLabel.Font, FontStyle.Bold)
            faultLabel.ForeColor = If(isPageFault, Color.FromArgb(129, 24, 68), Color.FromArgb(206, 171, 205))

            stepPanel.Controls.Add(faultLabel)

            pnlOutput.Controls.Add(stepPanel)
            xOffset += 95
        Next

        ' Final UI updates
        lblPageFault.Text = pageFaults.ToString()
        pnlOutput.HorizontalScroll.Enabled = (xOffset > pnlOutput.Width)
        pnlOutput.AutoScroll = True
    End Sub


    Private Sub BtnGen_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ' Clear previous page references
        pageReferences.Clear()


        ' Generate random page references (count is between 10 and 25 page references)
        Dim numPages As Integer = random.Next(10, 25)
        For i As Integer = 1 To numPages

            ' Generate and Store each randomly generated numbers, between 0 to 9, in pageReferences
            pageReferences.Add(random.Next(0, 10))
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

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ' Display page reference string in the output panel
        lblRefString.Text = lblPageRef.Text

        ' Display selected number of frames in the output panel
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


        'Parse the selected number of frames, from the combo box, into an integer
        Frames = Integer.Parse(cmbFrame.SelectedItem.ToString())


        'Call the appropriate algorithm based on the selected item in the combo box
        DisplayAlgorithms()


        pageFaults = 0

    End Sub


End Class

