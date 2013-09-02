''' <summary>
''' Custom mutex class with boolean lock state and reference to an action
''' to perform with blocking around it automatically
''' </summary>
''' <remarks></remarks>
Public Class Block
    ' state of block
    Public Property isBlocked As Boolean

    Public Sub New(Optional initialState = False)
        isBlocked = initialState
    End Sub

    Private Sub block()
        isBlocked = True
    End Sub

    Private Sub unblock()
        isBlocked = False
    End Sub

    ''' <summary>
    ''' Perform an action by blocking first
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Public Sub DoBlocked(action As Action(Of Object))
        Dim state = isBlocked

        block()
        action.Invoke(Nothing)

        ' return to original block state
        isBlocked = state
    End Sub
End Class
