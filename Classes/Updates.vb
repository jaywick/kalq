Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.ComponentModel

Public Class Updates
    Private Shared currentVersion_ As String ' cache of readable version (to avoid recalculating)

    Private Const AboutLink As String = "http://labs.jay-wick.com/kalq"
    Private Const UpdateLink As String = "http://updates.jay-wick.com/kalq"

    ' returns human friendly format of version data
    Public Shared ReadOnly Property ReadableVersionString() As String
        Get
            If currentVersion_ = "" Then
                currentVersion_ = readableVersion(VersionInfo)
            End If

            Return currentVersion_
        End Get
    End Property

    ' return version of this executable using reflection
    Public Shared ReadOnly Property VersionInfo As Version
        Get
            Return Reflection.Assembly.GetExecutingAssembly().GetName().Version
        End Get
    End Property

    ' information about the app
    Structure AboutInfo
        ' product name, version and company
        Public Shared ReadOnly Property Info As String
            Get
                Return Application.ProductName & " " & Updates.ReadableVersionString & " by " & Application.CompanyName
            End Get
        End Property

        ' url for more information
        Public Shared ReadOnly Property Link As String
            Get
                Return AboutLink
            End Get
        End Property
    End Structure

    Public Enum UpdateErrors
        None
        AlreadyUpdated
        ServerError
    End Enum

    Public Structure UpdateInfo
        Public ErrorResult As UpdateErrors
        Public Link As String
        Public Version As Version
        Public FriendlyVersion As String
    End Structure

    Dim updateCheckCallback As Action(Of UpdateInfo) = Nothing

    ' handles creation of background worker
    Public Sub CheckUpdates(callback As Action(Of UpdateInfo))
        Dim backgroundCheck As New BackgroundWorker
        AddHandler backgroundCheck.DoWork, AddressOf backgroundCheck_DoWork
        AddHandler backgroundCheck.RunWorkerCompleted, AddressOf backgroundCheck_RunWorkerCompleted
        updateCheckCallback = callback

        backgroundCheck.RunWorkerAsync()
    End Sub

    ' handles background worker finish
    Private Sub backgroundCheck_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim result As UpdateInfo = e.Result
        updateCheckCallback.Invoke(result)
    End Sub

    Private Sub backgroundCheck_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim result As New UpdateInfo With {.ErrorResult = UpdateErrors.None}

        Try
            Dim data As String
            Dim downloadlink As String
            Dim version As String

            Dim localVersion = VersionInfo
            Dim onlineVersion

            Dim client As WebClient = New WebClient()
            data = client.DownloadString(New Uri(UpdateLink))

            ' expected format: {VERSION}{tab}{LINK}
            ' future compatability to add more tags with TAB character
            Dim split = data.Split({ControlChars.Tab})
            version = split(0)
            downloadlink = split(1)

            onlineVersion = New Version(version)

            With result
                .Link = downloadlink
                .Version = onlineVersion
                .FriendlyVersion = readableVersion(onlineVersion)
            End With

            ' if nothing new then ignore
            If onlineVersion <= localVersion Then
                result.ErrorResult = UpdateErrors.AlreadyUpdated
            End If
        Catch ex As Exception
            ' any error is assumed to be a server issue
            ' includes URL issue, network issue, timeout, unexpected return format
            result.ErrorResult = UpdateErrors.ServerError
        End Try

        e.Result = result
    End Sub

    ''' <summary>
    ''' Return version numbers ignoring extra trailing zeros. <example>1.2.0 becomes 1.2</example>
    ''' </summary>
    ''' <param name="version">Version object to parse</param>
    ''' <returns>Human friendly version number as string</returns>
    ''' <remarks></remarks>
    Private Shared Function readableVersion(version As Version) As String
        Dim result As String

        If version.Build <= 0 And version.Revision = 0 Then
            result = version.Major & "." & version.Minor
        ElseIf version.Revision <= 0 Then
            result = version.Major & "." & version.Minor & "." & version.Build
        Else
            result = version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision
        End If

        Return result
    End Function

End Class
