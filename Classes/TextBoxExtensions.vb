Imports System.Runtime.CompilerServices

Module TextBoxExtensions

    <Extension()>
    Public Function SelectedOrAll(target As TextBox) As String
        If target.SelectionLength = 0 Then
            Return target.Text
        Else
            Return target.SelectedText
        End If
    End Function

End Module
