Imports jaywick.labs.kalq.Exceptions
Imports System.Net

Public Class formMain
    Private calculation As Calculation
    Private visual As Visual
    Private formatting As Formatting

    Private result As Result = Nothing ' result of calculation
    Private blockTextEvents As New Block ' mutex to prevent infinite calls when programmatically editing text input
    Private history As New List(Of String) ' history of calculations

    ''' <summary>
    ''' Constructor for main Kalq form. Initialises the window and instantiates necessary classes
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        ' draw window without firing text edit events
        blockTextEvents.DoBlocked(AddressOf InitializeComponent)

        ' create the new classes
        formatting = New Formatting(textExpression)
        calculation = New Calculation()
        visual = New Visual(Me, textExpression, textResult, sizeTesterExpression, sizeTesterResult)

        ' prepare the form from settings
        textExpression.Text = ""
        fixTextboxSizes()
        Me.TopMost = Preferences.Instance.AlwaysOnTop
        Me.Opacity = Preferences.Instance.OpacityNormal
        Me.FormBorderStyle = IIf(Preferences.Instance.AutoBorder, FormBorderStyle.None, FormBorderStyle.FixedToolWindow)

        If Preferences.Instance.ScreenCenterX = 0 And Preferences.Instance.ScreenCenterY = 0 Then
            visual.CenterWindow()
        Else
            Me.Location = New Point(Preferences.Instance.ScreenCenterX - Me.Width / 2, Preferences.Instance.ScreenCenterY - Me.Height / 2)
        End If

        ' prepare settings menu
        prepareSettingsMenu()

        ' unhighlight settings button
        panelSettings_MouseLeave()

        ' read command line data
        processCommandLine()

        ' finally add handler to form resize events so nothing above will fire it
        AddHandler Me.ResizeEnd, AddressOf formMain_Move
    End Sub

    ''' <summary>
    ''' Handle changes to expression input
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub textExpression_TextChanged() Handles textExpression.TextChanged
        If blockTextEvents.isBlocked Then Return ' if editing blocked, exit

        ' reset timer, to ensure history saves are made when idle
        resetSaveTimer()

        If textExpression.Text = "" Then
            ' do not process if nothing entered
            textResult.Text = ""
        ElseIf textExpression.Text = "?" Then
            ' check for overriding input values

            ' show about info
            blockTextEvents.DoBlocked(Sub() textExpression.Text = Updates.AboutInfo.Info) 'perform action while blocking textchange event being called again
            textResult.Text = Updates.AboutInfo.Link

            ' select all of the input and update size
            textExpression.SelectAll()
            fixTextboxSizes()

            Return
        Else
            ' prettify expression (while preventing text edit)
            blockTextEvents.DoBlocked(AddressOf formatting.PrettifyInput)

            ' normalise entire expression
            Dim properExpression = formatting.Normalise(textExpression.Text)

            ' return result from calculation
            Dim calculationResult As ScriptResult = calculation.Evaluate(properExpression)

            If calculationResult.hasError = False AndAlso IsNumeric(calculationResult.ReturnValue) Then
                ' format the number, prepare return object
                Dim formattedResult = formatting.PrettifyOutput(calculationResult.ReturnValue)
                result = New Result(calculationResult, formattedResult)
            Else
                ' non numeric output (for example, hexadecimal or error)
                result = New Result(calculationResult)

            End If

            visual.ShowResult(result)
        End If

        fixTextboxSizes()
    End Sub


    ''' <summary>
    ''' Update size of window to ensure text fits snug
    ''' </summary>
    Private Sub fixTextboxSizes()
        visual.Resize()
    End Sub

#Region "Form Events"

    ''' <summary>
    ''' Handles user focusing on result, forces focus to input instead
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub textResult_GotFocus() Handles textResult.GotFocus
        textExpression.Focus()
    End Sub

    ''' <summary>
    ''' Handles key being released
    ''' </summary>
    ''' <remarks>Used for form related keys such as movement, not input or shortcut related</remarks>
    Private Sub formMain_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If Preferences.Instance.AutoBorder Then
            If (Not e.Alt) And Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow Then
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handles key being pressed down
    ''' </summary>
    ''' <remarks>Used for form related keys such as movement, not input or shortcut related</remarks>
    Private Sub formMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.Control And (Not e.Alt) And (Not e.Shift) Then
            'CONTROL key only

            e.SuppressKeyPress = True

            Select Case e.KeyCode
                Case Keys.Delete
                    formatting.TrimSelection()
                Case Keys.G
                    formatting.GroupSelection()
                Case Keys.F
                    formatting.DivideSelection()
                Case Keys.I
                    formatting.InvertSelection()
                Case Keys.M
                    formatting.MultiplySelection()
                Case Keys.R
                    formatting.SquareRootSelection()
                Case Keys.NumPad2, Keys.D2
                    formatting.SquareSelection()
                Case Keys.NumPad3, Keys.D3
                    formatting.CubeSelection()
                Case Keys.NumPad3, Keys.D3
                    formatting.CubeSelection()
                Case Keys.Enter
                    formatting.AddPlus()

                Case Keys.N
                    newWindow()
                Case Keys.D
                    duplicateWindow()
                Case Keys.E
                    extractWindow()

                Case Keys.Z
                    textExpression.Undo()

                Case Keys.Subtract, Keys.OemMinus
                    visual.AdjustTextSize(visual.ResizingDirection.Smaller)
                Case Keys.Add, Keys.Oemplus
                    visual.AdjustTextSize(visual.ResizingDirection.Larger)
                Case Keys.NumPad0, Keys.D0
                    visual.AdjustTextSize(visual.ResizingDirection.Reset)
                    visual.CenterWindow()

                Case Else
                    e.SuppressKeyPress = False
            End Select

        ElseIf e.Alt And (Not e.Control) And (Not e.Shift) Then
            ' ALT key only

            e.SuppressKeyPress = True

            Select Case e.KeyCode
                Case Keys.NumPad0, Keys.D0
                    visual.AdjustTextSize(visual.ResizingDirection.Reset)
                Case Else
                    e.SuppressKeyPress = False
                    If Preferences.Instance.AutoBorder Then Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            End Select
        End If

        ' shortcuts where modifier aren't important
        Select Case e.KeyCode
            Case Keys.Escape
                ' ESC = exit
                exitSafely()
            Case Keys.Return
                ' ENTER = copies result
                copyAndExit()
                e.SuppressKeyPress = True
        End Select
    End Sub

    ''' <summary>
    ''' Handles activation of window
    ''' </summary>
    ''' <remarks>This occurs after New() and Form.Load</remarks>
    Private Sub formMain_Activate() Handles Me.Activated
        ' set opacity
        Me.Opacity = Preferences.Instance.OpacityNormal
    End Sub

#End Region ' form events

    Private Function processCommandLine() As Boolean
        'TODO: add saftey check here
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length = 2 Then
            Dim arg As String = arguments(1)
            textExpression.Text = formatting.CleanExpression(arg)
            textExpression.SelectAll()
            Return True
        Else
            Return False
        End If
    End Function

    <Experimental>
    Private Function processClipboard() As Boolean
        'TODO: add saftey check here
        Dim clip As String = Clipboard.GetText
        If Clipboard.ContainsText() AndAlso clip <> "" Then
            textExpression.Text = formatting.CleanExpression(clip)
            textExpression.SelectAll()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub exitSafely()
        End
    End Sub

#Region "Settings Menu"

    ''' <summary>
    ''' Update items with new settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub reflectSettingsUpdate()
        textExpression_TextChanged()
    End Sub

    ''' <summary>
    ''' Update toggle values and add handlers to the designer created
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub prepareSettingsMenu()
        menuSeparateThousands.CheckState = checkValue(Preferences.Instance.FormatThousandsSeparation)
        menuWindowOnTop.CheckState = checkValue(Preferences.Instance.AlwaysOnTop)
        menuWindowAutoBorder.CheckState = checkValue(Preferences.Instance.AutoBorder)

        AddHandler menuNew.Click, AddressOf newWindow
        AddHandler menuDuplicate.Click, AddressOf duplicateWindow
        AddHandler menuExtract.Click, AddressOf extractWindow

        AddHandler menuSeparateThousands.CheckedChanged, AddressOf menuFormattingThousands_CheckedChanged
        AddHandler menuFraction.Click, AddressOf formatting.DivideSelection
        AddHandler menuMultiply.Click, AddressOf formatting.MultiplySelection
        AddHandler menuBracket.Click, AddressOf formatting.GroupSelection
        AddHandler menuInvert.Click, AddressOf formatting.InvertSelection
        AddHandler menuRoot.Click, AddressOf formatting.SquareRootSelection
        AddHandler menuSquare.Click, AddressOf formatting.SquareSelection
        AddHandler menuCube.Click, AddressOf formatting.CubeSelection
        AddHandler menuAddPlus.Click, AddressOf formatting.AddPlus

        AddHandler menuSizeLarger.Click, Sub() visual.AdjustTextSize(visual.ResizingDirection.Larger)
        AddHandler menuSizeReset.Click, Sub() visual.AdjustTextSize(visual.ResizingDirection.Reset)
        AddHandler menuSizeSmaller.Click, Sub() visual.AdjustTextSize(visual.ResizingDirection.Smaller)

        AddHandler menuWindowOnTop.CheckedChanged, AddressOf menuWindowOnTop_CheckedChanged
        AddHandler menuWindowAutoBorder.CheckedChanged, AddressOf menuAutoBorder_CheckedChanged

        AddHandler menuCopyExit.Click, AddressOf copyAndExit
        AddHandler menuPasteAnswer.Click, AddressOf exitAndPaste
        AddHandler menuExit.Click, AddressOf exitSafely
    End Sub

    ' return boolean value from CheckState enum
    Private Function checkValue(value As Boolean) As CheckState
        Return IIf(value, CheckState.Checked, CheckState.Unchecked)
    End Function

    ' settings menu
    Private Sub panelSettings_MouseDown() Handles panelSettings.MouseDown
        menuSettings.Show(panelSettings, 0, panelSettings.Height)
    End Sub

    ' thousands separation
    Private Sub menuFormattingThousands_CheckedChanged()
        Preferences.Instance.FormatThousandsSeparation = Not Preferences.Instance.FormatThousandsSeparation
        reflectSettingsUpdate()
    End Sub

    ' on top
    Private Sub menuWindowOnTop_CheckedChanged()
        Preferences.Instance.AlwaysOnTop = Not Preferences.Instance.AlwaysOnTop
        Me.TopMost = Not Me.TopMost
        reflectSettingsUpdate()
    End Sub

    ' hide border
    Private Sub menuAutoBorder_CheckedChanged()
        Preferences.Instance.AutoBorder = Not Preferences.Instance.AutoBorder
        Me.FormBorderStyle = IIf(Preferences.Instance.AutoBorder, FormBorderStyle.None, FormBorderStyle.FixedToolWindow)
        reflectSettingsUpdate()
    End Sub

#End Region

    ' copy answer, exit program then paste answer
    Private Sub exitAndPaste()
        If result IsNot Nothing Then
            Clipboard.SetText(result.Value.ToString())
            Me.Hide()
            Threading.Thread.Sleep(400)
            SendKeys.Send("^v")
            exitSafely()
        Else
            Beep()
        End If
    End Sub

    ' copy answer and exit
    Private Sub copyAndExit()
        If textResult.Text = Updates.AboutInfo.Link Then
            Process.Start("http://" & Updates.AboutInfo.Link)
            Clipboard.SetText(Updates.AboutInfo.Link)
            exitSafely()
            Return
        End If

        If result IsNot Nothing Then
            Clipboard.SetText(result.Value.ToString())
            exitSafely()
        Else
            Beep()
        End If
    End Sub

    ' save screen location
    Private Sub formMain_Move(sender As Object, e As EventArgs)
        Preferences.Instance.ScreenCenterX = Me.Location.X + Me.Width / 2
        Preferences.Instance.ScreenCenterY = Me.Location.Y + Me.Height / 2
    End Sub

    ' handle history item clicked
    Private Sub menuHistoryItem_Click(sender As Object, e As EventArgs)
        Dim item = DirectCast(sender, ToolStripItem)
        textExpression.Text = item.Text
        textExpression.SelectionStart = textExpression.TextLength
    End Sub

    ' update the settings menu when opened
    Private Sub menuSettings_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles menuSettings.Opening
        ' Version
        menuAbout.Text = Updates.AboutInfo.Info

        ' History
        menuHistory.Visible = Not history.Count = 0
        menuHistory.DropDownItems.Clear()
        For Each entry In history
            Dim item = menuHistory.DropDownItems.Add(entry)
            AddHandler item.Click, AddressOf menuHistoryItem_Click
        Next

        ' Website / Updates
        If textResult.Text = Updates.AboutInfo.Link Then
            menuCopyExit.Text = "Visit website"
            menuExpression.Visible = False
            menuPasteAnswer.Visible = False
            Return
        Else
            menuCopyExit.Text = "Copy result and exit"
            menuCopyExit.Visible = result IsNot Nothing
            menuPasteAnswer.Visible = result IsNot Nothing
        End If

        ' Expression / Selection
        If textExpression.SelectedText = "" Then
            menuExpression.Text = "Expression"
        Else
            menuExpression.Text = "Selection"
        End If
    End Sub

    ' create new instance of program
    Private Sub spawn(Optional arguments As String = "")
        Dim p As New Process()
        p.StartInfo.FileName = Application.ExecutablePath
        p.StartInfo.Arguments = """" & arguments & """"
        p.Start()
    End Sub

    ' save history using a timer
    Private Sub timerSave_Tick(sender As Object, e As EventArgs) Handles timerSave.Tick
        ' exit if there is no answer
        If result Is Nothing OrElse textExpression.Text = "" Then Return

        ' exit if last answer hasn't changed since last save
        If history.Count > 0 AndAlso textExpression.Text = history(history.Count - 1) Then Return

        ' add to history, remove last value from list
        history.Add(textExpression.Text)
        If history.Count >= 11 Then history.RemoveAt(history.Count - 1)
    End Sub

#Region "Update checking"

    ' handle 'Check for updates' menu item
    Private Sub menuUpdates_Click() Handles menuUpdates.Click
        Dim updater As New Updates()
        updater.CheckUpdates(AddressOf updateCheck_Result)

        menuUpdates.Text = "Checking for updates..."
        menuUpdates.Enabled = False
    End Sub

    ' check results callback
    Private Sub updateCheck_Result(result As Updates.UpdateInfo)
        Select Case result.ErrorResult
            Case Updates.UpdateErrors.AlreadyUpdated
                MessageBox.Show("Your current version is up to date!",
                                "No new updates",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case Updates.UpdateErrors.ServerError
                MessageBox.Show("Could not connect to the update server at this time. Please check if there is network connectivity." & vbCrLf & vbCrLf &
                                "Try to navigate to " & Updates.AboutInfo.Link & " to check for new versions manually.",
                                "Could not check for updates",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            Case Updates.UpdateErrors.None
                Dim userResponse = MessageBox.Show("Version " & result.FriendlyVersion & " is now available. Do you wish to download it now?",
                                                   "Update available",
                                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If userResponse = Windows.Forms.DialogResult.OK Then
                    Process.Start(result.Link)
                End If

        End Select

        menuUpdates.Text = "Check for updates"
        menuUpdates.Enabled = True
    End Sub

#End Region

    ' start counting again from 0 before saving
    Private Sub resetSaveTimer()
        timerSave.Stop()
        timerSave.Start()
    End Sub

    ' settings button mouse enter effect
    Private Sub panelSettings_MouseEnter() Handles panelSettings.MouseEnter
        panelSettings.BackColor = Color.Gray
    End Sub

    ' settings button mouse leave effect
    Private Sub panelSettings_MouseLeave() Handles panelSettings.MouseLeave
        panelSettings.BackColor = Color.FromArgb(27, 27, 27)
    End Sub

    ' create new window
    Private Sub newWindow()
        spawn()
    End Sub

    ' create new window with same contents
    Private Sub duplicateWindow()
        spawn(textExpression.Text)
    End Sub

    ' create new window only with selected contents
    Private Sub extractWindow()
        spawn(textExpression.SelectedText)
    End Sub

End Class