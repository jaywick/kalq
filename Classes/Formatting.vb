
''' <summary>
''' Handles formatting of text aspects of the program
''' </summary>
''' <remarks></remarks>
Public Class Formatting

    ' constants defining next cursor after formatting text
    Public Enum FinalCursorPositionConsts
        After = 0 ' after the envelope
        Within = 1 ' withing the envelope
    End Enum

    ' reference to textbox to format
    Private textBoxReference As TextBox

    ' tuple list of formatting replacements
    Private replacements As New Dictionary(Of String, String)

    ''' <summary>
    ''' Create new instance of formatter, initialise replacements
    ''' </summary>
    ''' <param name="textBoxReference">Reference to the textbox to format</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef textBoxReference As TextBox)
        Me.textBoxReference = textBoxReference
        replacements.Add("/", "÷")
        replacements.Add("*", "×")
    End Sub

    ''' <summary>
    ''' Envelope in brackets
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GroupSelection()
        envelope("(", ")")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and divide
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DivideSelection()
        envelope("(", ")/")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and multiply
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MultiplySelection()
        envelope("(", ")*")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and invert
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InvertSelection()
        envelope("1/(", ")")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and square root
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SquareRootSelection()
        envelope("root(", ")")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and raise power by 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SquareSelection()
        envelope("(", ")^2")
    End Sub

    ''' <summary>
    ''' Envelope in brackets and raise power by 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CubeSelection()
        envelope("(", ")^3")
    End Sub

    ''' <summary>
    ''' Add a plus to the end
    ''' </summary>
    ''' <remarks></remarks>
    Sub AddPlus()
        envelope("", "+")
    End Sub

    ''' <summary>
    ''' Remove text which is not selected
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TrimSelection()
        If textBoxReference.Text <> "" Then
            textBoxReference.Text = textBoxReference.SelectedText
            textBoxReference.SelectAll()
        End If
    End Sub

    ''' <summary>
    ''' Removes the prettification replacements made by <see>PrettifyInput</see>
    ''' </summary>
    ''' <param name="expression">Prettified expression to normalise</param>
    ''' <returns>Expression with prettification replacements removed</returns>
    ''' <remarks></remarks>
    Public Function Normalise(expression As String) As String
        Dim replacedtxt As String = expression

        ' remove replacements (apply original)
        For Each properItem In replacements.Keys
            Dim prettyItem = replacements(properItem)
            replacedtxt = Replace(replacedtxt, prettyItem, properItem)
        Next

        Return replacedtxt
    End Function

    ''' <summary>
    ''' Format the textbox and 'prettify' it by applying replacement characters
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrettifyInput()
        Dim selStart As Integer = textBoxReference.SelectionStart
        Dim selLen As Integer = textBoxReference.SelectionLength
        Dim replacedtxt As String = textBoxReference.Text

        ' apply the replacements (prettify)
        For Each properItem In replacements.Keys
            Dim prettyItem = replacements(properItem)
            replacedtxt = Replace(replacedtxt, properItem, prettyItem)
        Next

        textBoxReference.Text = replacedtxt
        textBoxReference.SelectionStart = selStart
        textBoxReference.SelectionLength = selLen
    End Sub

    ''' <summary>
    ''' Formats the answer by applying a thousands separator or scientific notion if very small/large
    ''' </summary>
    ''' <param name="answer">Answer which requires formatting</param>
    ''' <returns>Returns a string value of the formatted answer</returns>
    ''' <remarks></remarks>
    Public Function PrettifyOutput(answer As Double) As String
        Dim result = answer

        Dim separateByThousands As Boolean = Preferences.Instance.FormatThousandsSeparation

        Dim veryLarge As Boolean = (Math.Abs(result) >= 10 ^ 15)
        Dim verySmall As Boolean = (Math.Abs(result) <= 10 ^ -15 AndAlso result <> 0)

        If veryLarge Or verySmall Then
            Return applyScientificNotation(answer)
        ElseIf separateByThousands Then
            Return IIf(Math.Sign(result) = -1, "-", "") & Trim(String.Format("{0:### ### ### ### ### ### ### ##0.### ### ### ### ### ### ###}", Math.Abs(result)))
        Else
            Return result
        End If

        Return result
    End Function

    ''' <summary>
    ''' Create a scientific notation form for very small/large values
    ''' </summary>
    ''' <param name="answer">Raw numeric answer</param>
    ''' <returns>Returns a scient</returns>
    ''' <remarks>Converts to <code>AeB</code> form and returns <code>A×10^B</code> form</remarks>
    Private Function applyScientificNotation(answer As String) As String
        ' convert to scientific notation of framework, AeB form
        Dim formattedValue As String = String.Format("{0:e}", answer)

        ' split the mantissa (the A in A×10^B)
        '  and exponent (the B in A×10^B)
        Dim components As String() = formattedValue.Split("E"c)
        Dim mantissa = components(0)
        Dim exponent = components(1)

        ' format components to Ax10^B  form
        Return String.Format("{0:g}", mantissa) & "×10^" & String.Format("{0:g}", CInt(exponent))
    End Function

    ''' <summary>
    ''' Removes whitespace characters from the raw input
    ''' </summary>
    ''' <param name="message">Raw input message</param>
    ''' <returns>Returns message without whitepsace characters</returns>
    ''' <remarks>Also removes surrounding quotation marks</remarks>
    Public Function CleanExpression(message As String) As String
        ' ignore tabs, lines, space (warning: might impede future custom functions)
        message = message.Replace(ControlChars.Tab, "")
        message = message.Replace(ControlChars.NewLine, "")
        message = message.Replace(" ", "")

        If message = "" Then Return ""

        ' ignore surrounding quotation marks
        If message.Substring(0) = """" And message.Substring(message.Length - 1) = """" Then
            message = message.Substring(1, message.Length - 2)
        End If

        Return message
    End Function

    ''' <summary>
    ''' Surrounds the selection of the textbox (or all if no selection made) with two strings for before and after
    ''' </summary>
    ''' <param name="preString">String to add before</param>
    ''' <param name="postString">String to add afterwards</param>
    ''' <param name="finalCursorPosition">Position of where the curors moves to, either just after the evelopment or before the postString</param>
    ''' <remarks></remarks>
    Private Sub envelope(preString As String, postString As String, Optional finalCursorPosition As FinalCursorPositionConsts = FinalCursorPositionConsts.After)
        Dim start As Integer = textBoxReference.SelectionStart
        Dim length As Integer = textBoxReference.SelectionLength

        If length = 0 Then
            ' if nothing selected, process entire expression
            start = 0
            length = textBoxReference.TextLength
        End If

        Dim strFront As String = textBoxReference.Text.Substring(0, start)
        Dim strMiddle As String = textBoxReference.Text.Substring(start, length)
        Dim strBack As String = textBoxReference.Text.Substring(start + length)

        textBoxReference.Text = strFront & (preString & strMiddle & postString) & strBack

        ' decide where the cursor goes
        If finalCursorPosition = FinalCursorPositionConsts.After Then
            textBoxReference.SelectionStart = start + length + (preString & postString).Length
            textBoxReference.SelectionLength = 0
        ElseIf finalCursorPosition = FinalCursorPositionConsts.Within Then
            textBoxReference.SelectionStart = start + 1
            textBoxReference.SelectionLength = length
        End If
    End Sub

End Class
