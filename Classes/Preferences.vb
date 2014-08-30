Imports System.Xml.Serialization
Imports System.IO
Imports System.Environment

''' <summary>
''' Database of settings serialised as XML and accessible as a singleton
''' </summary>
''' <remarks></remarks>
<XmlRoot("Preferences")>
Public Class Preferences

#Region "Singleton Access"

    Private Shared instance_ As Preferences
    Public Shared Property Instance As Preferences
        Get
            ' public access to self contained instance
            If instance_ Is Nothing Then
                instance_ = New Preferences()
                instance_.init()
            End If
            Return instance_
        End Get
        Private Set(value As Preferences)
            ' only this class should ever set the value
            instance_ = value
        End Set
    End Property

#End Region

#Region "All Settings"

    ' window settings
    <XmlElement(Type:=GetType(Boolean))> Public Property AlwaysOnTop As Boolean = True
    <XmlElement(Type:=GetType(Boolean))> Public Property AutoBorder As Boolean = True
    <XmlElement(Type:=GetType(Double))> Public Property OpacityNormal As Double = 0.8#

    ' formatting settings
    <XmlElement(Type:=GetType(Boolean))> Public Property FormatThousandsSeparation As Boolean = True

    ' error strings
    <XmlElement(Type:=GetType(String))> Public Property ResultUnknown As String = "?"
    <XmlElement(Type:=GetType(String))> Public Property ResultOverflow As String = "URGH"
    <XmlElement(Type:=GetType(String))> Public Property ResultDivisionByZero As String = "ERR"

    ' font size
    <XmlElement(Type:=GetType(Integer))> Public Property FontSize As Integer = 28

    ' screen position
    <XmlElement(Type:=GetType(Integer))> Public Property ScreenCenterX As Integer = 0
    <XmlElement(Type:=GetType(Integer))> Public Property ScreenCenterY As Integer = 0

#End Region

#Region "Serialisation"

    Private ReadOnly settingsPath() As String = {"Jay Wick Labs", "Kalq", "preferences.xml"} ' components of settings file's path
    Private filePath As String ' path to file (created when settingsPath array is compiled into a path)
    Private Shared isRead As Boolean = False ' specifies if settings file has been read yet

    Private Sub New()
        checkSettingsFile()
    End Sub

    ''' <summary>
    ''' Private initialiser to be used only once (otherwise serialisation will call constructor again causing a stackoverflow)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        If File.Exists(filePath) Then read()
    End Sub

    ''' <summary>
    ''' Save settings on finalisation
    ''' </summary>
    ''' <remarks>This is called when the GC chooses to destroy the instance, which should upon expected application exit</remarks>
    Protected Overrides Sub Finalize()
        write()
    End Sub

    ''' <summary>
    ''' Write to the settings file
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub write()
        Dim writer As New StreamWriter(filePath)
        Dim s As New XmlSerializer(GetType(Preferences))
        s.Serialize(writer, Instance)
        writer.Close()
    End Sub

    ''' <summary>
    ''' Read from the settings from settings file
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub read()
        ' only read once for single instance
        If isRead Then Return Else isRead = True

        Dim reader As New StreamReader(filePath)
        Dim serialiser As New XmlSerializer(GetType(Preferences))

        Try
            Instance = serialiser.Deserialize(reader)
        Catch ex As InvalidOperationException
            reader.Close()
            Dim result = MessageBox.Show("Loading preferences failed. " & ex.Message & NewLine & "Fix the settings file and press Retry or Cancel to overwrite with defaults", "Settings Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If result = DialogResult.Retry Then
                isRead = False
                read()
                Return
            End If
        End Try

        reader.Close()
    End Sub

    ''' <summary>
    ''' Check for settings file and create the folder hierarchy if missing
    ''' </summary>
    ''' <remarks>In future, take into account portable versions of this software (no appdata)</remarks>
    Public Sub checkSettingsFile()
        Dim appData = GetFolderPath(SpecialFolder.ApplicationData)

        Dim labsFolder = Path.Combine(appData, settingsPath(0))
        If Not Directory.Exists(labsFolder) Then Directory.CreateDirectory(labsFolder)

        Dim kalqFolder = Path.Combine(labsFolder, settingsPath(1))
        If Not Directory.Exists(kalqFolder) Then Directory.CreateDirectory(kalqFolder)

        filePath = Path.Combine(kalqFolder, settingsPath(2))
    End Sub

#End Region

End Class
