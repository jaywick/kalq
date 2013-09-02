''' <summary>
''' Custom exceptions
''' </summary>
''' <remarks>Some exceptions may seem redundant as the .NET framework already
''' supports them (eg DivisionByZero) but for consistency this custom set is used.</remarks>
Public Class Exceptions

    ''' <summary>
    ''' Custom exception class to pass errors from script control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SyntaxError
        Inherits Exception

        Public Property ScriptError As MSScriptControl.Error

        Sub New(scriptError As MSScriptControl.Error)
            Me.ScriptError = scriptError
        End Sub
    End Class

    ' calculation error: division by zero
    Public Class DivisionByZero
        Inherits Exception
    End Class

    ' calculation error: overflow
    Public Class Overflow
        Inherits Exception
    End Class

    ' calculation error: unknown cause
    Public Class Unknown
        Inherits Exception
    End Class

End Class
