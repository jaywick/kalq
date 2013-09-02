
''' <summary>
''' Contains result as both value and formatted string
''' </summary>
''' <remarks>Class preferred over structure to allow objects to be referenceable</remarks>
Public Class Result
    Public Property Formatted As String ' formatted string of result
    Public Property Value As Double ' numeric value of result
    Public Property Output As ScriptResult ' output from script

    ' wrap script output then store and evaluate both string and numeric result forms
    Public Sub New(scriptOut As ScriptResult, Optional formattedValue As String = "")
        Output = scriptOut
        Formatted = formattedValue

        If (formattedValue <> "") Then
            Value = Double.Parse(scriptOut.ReturnValue)
        Else
            Value = Double.NaN
        End If
    End Sub

End Class

Public Class ScriptResult
    Public Property ReturnValue As String
    Public Property ErrorReturned As ResultErrors ' error returned from calculation
    Public ReadOnly hasError As Boolean = ErrorReturned <> ResultErrors.None ' check to see if error exists

    ' create a result containing something
    Public Sub New(value As String)
        ErrorReturned = ResultErrors.None
        ReturnValue = value
    End Sub

    ' create a result containing an error
    Public Sub New(resultError As ResultErrors)
        ErrorReturned = resultError
        ReturnValue = Nothing
    End Sub
End Class

Public Enum ResultErrors
    None
    SyntaxError
    DivisionByZero
    Overflow
    Unknown
End Enum
