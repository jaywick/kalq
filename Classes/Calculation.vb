
''' <summary>
''' Handles all mathematical aspects of Kalq
''' </summary>
''' <remarks></remarks>
Public Class Calculation

    ' math constants
    Private Const PI As Double = 3.14159265357989
    Private Const E As Double = 2.71828182845905

    ' MS Script Control object, the main engine of kalq
    Private interpreter As New MSScriptControl.ScriptControl

    ''' <summary>
    ''' Evaluates the given expression. Main crux of the Kalq program
    ''' </summary>
    ''' <param name="expression">Expression such as '1+4/5'</param>
    ''' <returns>Result class containing value or error returned.</returns>
    ''' <remarks></remarks>
    Function Evaluate(expression As String) As ScriptResult

        ' prepare the interpreter
        interpreter.Language = "VBScript"
        interpreter.Reset()
        interpreter.UseSafeSubset = True ' disable harmful functions
        interpreter.AllowUI = False ' disable any UI functions
        interpreter.Reset()

        ' prepare the script
        Dim script As New ScriptWrapper
        addFunctions(script)
        script.StartMain()
        addConstants(script)
        script.EndMain(expression)

        ' initialise result to null
        Dim result = Nothing

        ' add code, catch errors if any
        ' throws custom exceptions to be dealt by caller
        Try
            interpreter.AddCode(script.Code)
        Catch ex As Runtime.InteropServices.COMException
            If ex.Message = "Syntax error" Then
                Return New ScriptResult(ResultErrors.SyntaxError)
            Else
                Return New ScriptResult(ResultErrors.Unknown)
            End If
        Catch
            Return New ScriptResult(ResultErrors.Unknown)
        End Try

        ' run the code, catch errors if any
        ' throws custom exceptions to be dealt by caller
        Try
            result = interpreter.Run("Kalq")

            If result Is Nothing Then
                Return New ScriptResult(ResultErrors.Unknown)
            End If
        Catch ex As DivideByZeroException
            Return New ScriptResult(ResultErrors.DivisionByZero)
        Catch ex As OverflowException
            Return New ScriptResult(ResultErrors.Overflow)
        Catch ex As Exception
            Return New ScriptResult(ResultErrors.Unknown)
        Finally
            interpreter.Reset()
        End Try

        Return New ScriptResult(result.ToString())
    End Function

    ''' <summary>
    ''' Add predefined constants to the script
    ''' </summary>
    ''' <param name="script">Script to add constants to</param>
    ''' <remarks></remarks>
    Private Sub addConstants(script As ScriptWrapper)
        script.Add("pi", PI)
        script.Add("e", E)
    End Sub

    ''' <summary>
    ''' Adds custom functions to the script
    ''' </summary>
    ''' <param name="script">Script to add custom functions to</param>
    ''' <remarks></remarks>
    Private Sub addFunctions(script As ScriptWrapper)
        script.Add("root", "value", "sqr(value)")
    End Sub

    ''' <summary>
    ''' Inner class for wrapping expression with necessary code to work create a complete VB script
    ''' </summary>
    ''' <remarks></remarks>
    Class ScriptWrapper
        Property Code As String = ""

        ''' <summary>
        ''' Add a custom function to the vbs code
        ''' </summary>
        ''' <param name="method">Function name</param>
        ''' <param name="parameters">Inputs to the function</param>
        ''' <param name="expression">Expression to return</param>
        ''' <remarks></remarks>
        Sub Add(method As String, parameters As String, expression As String)
            Add("Function " & method & "(" + parameters + ")")
            Add(method & " = " & expression)
            Add("End Function")
        End Sub

        ''' <summary>
        ''' Add a variable (or constant) to the vbs code
        ''' </summary>
        ''' <param name="Name">Variable name</param>
        ''' <param name="Value">Value of variable</param>
        ''' <remarks></remarks>
        Sub Add(Name As String, Value As Object)
            Add("Dim " & Name)
            Add(Name & " = " & Value)
        End Sub

        ''' <summary>
        ''' Add a raw line to the vbs code
        ''' </summary>
        ''' <param name="line">Raw line to add</param>
        ''' <remarks>Private scope as only the ScriptWrapper class should add raw lines</remarks>
        Private Sub Add(line As String)
            Code &= line & ControlChars.NewLine
        End Sub

        ''' <summary>
        ''' Create function declaration for main kalq expression
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StartMain()
            Add("Function Kalq()")
        End Sub

        ''' <summary>
        ''' Return the expression and declare end of function
        ''' </summary>
        ''' <param name="expression"></param>
        ''' <remarks></remarks>
        Public Sub EndMain(expression As String)
            Add("Kalq = " & expression)
            Add("End Function")
        End Sub
    End Class

End Class