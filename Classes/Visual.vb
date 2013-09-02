''' <summary>
''' Handles visual aspects of the program
''' </summary>
''' <remarks></remarks>
Public Class Visual

    ' constants
    Private Const MinimumExpressionWidth As Integer = 200,
                  MinimumResultWidth As Integer = 200,
                  ExpressionResultSeparation As Integer = 10,
                  CommonMarginBuffer As Integer = 10,
                  FontSizeDefault As Integer = 28,
                  FontSizeMinimum As Integer = 10,
                  FontSizeMaximum As Integer = 72

    ' references to the controls to use
    Private window As Form
    Private expression, result As TextBox
    Private expressionSizeTest, resultSizeTest As Label

    ' directions in which the sizes can be changed
    Enum ResizingDirection
        Reset = 0
        Smaller = 1
        Larger = 2
    End Enum

    ' gather all references to controls to be used
    Sub New(window As Form, ByRef expression As TextBox, result As TextBox, ByRef expressionSizeTest As Label, ByRef resultSizeTest As Label)
        Me.window = window
        Me.expression = expression
        Me.result = result
        Me.expressionSizeTest = expressionSizeTest
        Me.resultSizeTest = resultSizeTest
    End Sub

    ''' <summary>
    ''' Manipulate all controls to cater for a resize
    ''' </summary>
    ''' <remarks></remarks>
    Sub Resize()
        Dim lastCenter As Integer = window.Left + window.Width / 2

        ' resize expression
        expressionSizeTest.Text = expression.Text

        If expressionSizeTest.Size.Width > MinimumExpressionWidth Then
            expression.Size = expressionSizeTest.Size
        Else
            expression.Size = New Size(MinimumExpressionWidth, expression.Size.Width)
        End If

        expression.Left = CommonMarginBuffer 'result.Left - expression.Size.Width - 10

        'resize result
        resultSizeTest.Text = result.Text

        If resultSizeTest.Size.Width > MinimumResultWidth Then
            result.Size = resultSizeTest.Size
        Else
            result.Size = New Size(MinimumResultWidth, result.Size.Width)
        End If

        result.Left = expression.Right + ExpressionResultSeparation

        'resize window
        window.Width = result.Right + CommonMarginBuffer

        'reposition window (centered at = sign)
        Dim newLeft As Integer = lastCenter - (window.Width / 2)

        Dim screen As Screen = screen.FromControl(window)

        'check max left and max right with respect to screen
        Dim isNearingRight As Boolean = newLeft + window.Width > screen.WorkingArea.Right - 50
        Dim isNearingLeft As Boolean = newLeft < screen.WorkingArea.Left + 50

        If isNearingLeft And isNearingRight Then
            'TODO: account entire screen space being taken; solution = reduce size?
            AdjustTextSize(ResizingDirection.Smaller)
        ElseIf isNearingLeft Then
            newLeft = screen.WorkingArea.Left + 50
        ElseIf isNearingRight Then
            newLeft = screen.WorkingArea.Right - window.Width - 50
        End If

        window.Left = newLeft
    End Sub

    ''' <summary>
    ''' Reset window position to center screen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CenterWindow()
        Dim center As New Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2)
        Preferences.Instance.ScreenCenterX = center.X
        Preferences.Instance.ScreenCenterY = center.Y

        window.Location = center - New Point(window.Width / 2, window.Height / 2)
    End Sub

    ''' <summary>
    ''' Manipulate controls to adjust for change in size of text
    ''' </summary>
    ''' <param name="value">Size as a number</param>
    ''' <remarks></remarks>
    Public Sub AdjustTextSize(value As Single)
        'clamp font size
        If value > FontSizeMaximum Or value < FontSizeMinimum Then
            Beep()
            Exit Sub
        End If

        'apply font changes to text boxes and size testers
        Dim font = New Drawing.Font(expression.Font.Name, value, expression.Font.Style)
        applyFontChange(font)

        window.Height = expression.Bottom + CommonMarginBuffer + getWindowTitleHeight()

        Preferences.Instance.FontSize = value
    End Sub

    ''' <summary>
    ''' Manipulate controls to adjust for change in size of text
    ''' </summary>
    ''' <param name="Direction">Direction to resize</param>
    ''' <remarks></remarks>
    Public Sub AdjustTextSize(Direction As ResizingDirection)
        Dim newSize As Single

        ' determine new size
        If Direction = ResizingDirection.Reset Then
            newSize = FontSizeDefault
        ElseIf Direction = ResizingDirection.Smaller Then
            newSize = expression.Font.Size - 2
        ElseIf Direction = ResizingDirection.Larger Then
            newSize = expression.Font.Size + 2
        End If

        AdjustTextSize(newSize)
    End Sub

    ''' <summary>
    ''' Change the font of all display text (and size testers)
    ''' </summary>
    ''' <param name="font">Font to change</param>
    ''' <remarks>Note a change in size is a change in font as this data is contained in the Font class</remarks>
    Private Sub applyFontChange(font As Font)
        expression.Font = font
        result.Font = font
        expressionSizeTest.Font = font
        resultSizeTest.Font = font
    End Sub

    ''' <summary>
    ''' Determine height of top part of the window chrome
    ''' </summary>
    ''' <returns>Pixel buffer between top of client space and top of window</returns>
    ''' <remarks>Different themes, platforms and text settings will yield very different values</remarks>
    Private Function getWindowTitleHeight() As Integer
        Dim layoutY = window.RectangleToScreen(window.ClientRectangle).Top
        Dim windowY = window.Top

        Return layoutY - windowY
    End Function

    Sub ShowResult(resultObject As Result)
        Select Case resultObject.Output.ErrorReturned
            Case ResultErrors.None
                changeTextColour(Color.White, Color.Black, TextboxTypes.Both)
                result.Text = "= " & resultObject.Formatted

            Case ResultErrors.SyntaxError
                changeTextColour(Color.LightPink, Color.Black, TextboxTypes.Expression)
                changeTextColour(Color.Gray, Color.Black, TextboxTypes.Result)

            Case ResultErrors.DivisionByZero
                changeTextColour(Color.Tomato, Color.Black, TextboxTypes.Result)
                result.Text = "= " & Preferences.Instance.ResultDivisionByZero

            Case ResultErrors.Overflow
                changeTextColour(Color.Tomato, Color.Black, TextboxTypes.Result)
                result.Text = "= " & Preferences.Instance.ResultOverflow

            Case ResultErrors.Unknown
                changeTextColour(Color.DarkRed, Color.Black, TextboxTypes.Result)
                result.Text = "= " & Preferences.Instance.ResultUnknown
        End Select
    End Sub

    Private Enum TextboxTypes
        Expression
        Result
        Both
    End Enum

    Private Sub changeTextColour(foreground As Color, background As Color, which As TextboxTypes)

        Dim reference As TextBox
        If which = TextboxTypes.Expression Then
            reference = expression
        ElseIf which = TextboxTypes.Result Then
            reference = result
        Else
            changeTextColour(foreground, background, TextboxTypes.Expression)
            changeTextColour(foreground, background, TextboxTypes.Result)
            Return
        End If

        reference.ForeColor = foreground
        reference.BackColor = background
    End Sub
End Class