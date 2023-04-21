Imports System
Imports System.Text
Imports System.IO
Imports System.Reflection



Namespace VCInstaller
    Public Class SimpleLogger

        Private DatetimeFormat As String
        Private LogFileName As String
        Private errorCount As Integer = 0   ' errors 
        Private failureCount As Integer = 0 ' fatal errors
        Private warningCount As Integer = 0 ' warnings

        Private StrgLevels As String()

        ''' <summary>
        ''' Supported log level
        ''' </summary>
        <Flags>
        Private Enum LogLevel
            TRACE
            INFO
            DEBUG
            WARNING
            [ERROR]
            FATAL
            BRIEF_REPORT
        End Enum

        ''' <summary>
        ''' [Enum] Log type (text, xml, no log)
        ''' </summary>
        <Flags>
        Public Enum LogType
            NoLog
            LogInTextFormat
        End Enum

        ''' <summary>
        ''' Initialize a new instance of SimpleLogger class.
        ''' Log file will be created automatically if not yet exists, else it can be either a fresh new file or append to the existing file.
        ''' Default is create a fresh new log file.
        ''' </summary>
        ''' <paramname="append">True to append to existing log file, False to overwrite and create new log file</param>
        ''' <paramname="filename">Optional : set a different name of the log if desired </param>
        Public Sub New(ByVal Optional filename As String = "", ByVal Optional append As Boolean = False)
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss.fff"
            StrgLevels = New String() {" [TRACE] ", " [INFO] ", " [DEBUG] ", " [WARNING] ", " [ERROR] ", " [FATAL] ", " [REPORT] "}

            ' If not defined filename use the application default one
            If Equals(filename, String.Empty) Then
                LogFileName = Assembly.GetExecutingAssembly().GetName().Name & ".log"
            Else
                LogFileName = filename & ".log"
            End If

            ' Log file header line
            Dim logHeader = LogFileName & " is created."
            If Not File.Exists(LogFileName) Then
                WriteLine(Date.Now.ToString(DatetimeFormat) & " " & logHeader, False)
            Else
                If append = False Then WriteLine(Date.Now.ToString(DatetimeFormat) & " " & logHeader, False)
            End If
        End Sub

        ''' <summary>
        ''' Log a debug message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub Debug(ByVal text As String)
            WriteFormattedLog(LogLevel.DEBUG, text)
        End Sub

        ''' <summary>
        ''' Log an error message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub [Error](ByVal text As String)
            WriteFormattedLog(LogLevel.ERROR, text)
            errorCount += 1
        End Sub

        ''' <summary>
        ''' Log a fatal error message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub Fatal(ByVal text As String)
            WriteFormattedLog(LogLevel.FATAL, text)
            failureCount += 1
        End Sub

        ''' <summary>
        ''' Log an info message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub Info(ByVal text As String)
            WriteFormattedLog(LogLevel.INFO, text)
        End Sub

        ''' <summary>
        ''' Log a trace message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub Trace(ByVal text As String)
            WriteFormattedLog(LogLevel.TRACE, text)
        End Sub

        ''' <summary>
        ''' Log a waning message
        ''' </summary>
        ''' <paramname="text">Message</param>
        Public Sub Warning(ByVal text As String)
            WriteFormattedLog(LogLevel.WARNING, text)
            warningCount += 1
        End Sub

        Public Sub Report(ByVal Optional text As String = "")
            WriteFormattedLog(LogLevel.BRIEF_REPORT, text)
        End Sub

        ''' <summary>
        ''' Format a log message based on log level
        ''' </summary>
        ''' <paramname="level">Log level</param>
        ''' <paramname="text">Log message</param>
        Private Sub WriteFormattedLog(ByVal level As LogLevel, ByVal text As String)
            Dim pretext = String.Empty

            Select Case level
                Case LogLevel.TRACE
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.TRACE)
                Case LogLevel.INFO
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.INFO)
                Case LogLevel.DEBUG
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.DEBUG)
                Case LogLevel.WARNING
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.WARNING)
                Case LogLevel.ERROR
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.ERROR)
                Case LogLevel.FATAL
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.FATAL)
                Case LogLevel.BRIEF_REPORT
                    pretext = Date.Now.ToString(DatetimeFormat) & StrgLevels(LogLevel.BRIEF_REPORT)
                Case Else
                    pretext = String.Empty
            End Select
            WriteLine(pretext & text)
        End Sub

        ''' <summary>
        ''' Write a line of formatted log message into a log file
        ''' </summary>
        ''' <paramname="text">Formatted log message</param>
        ''' <paramname="append">True to append, False to overwrite the file</param>
        ''' <exceptioncref="System.IO.IOException"></exception>
        Private Sub WriteLine(ByVal text As String, ByVal Optional append As Boolean = True)
            Try
                Using Writer As StreamWriter = New StreamWriter(LogFileName, append, Encoding.UTF8)
                    If Not Equals(text, "") Then Writer.WriteLine(text)
                End Using

            Catch
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' Returns the total errors logged.
        ''' </summary>
        Public ReadOnly Property TotalErrors As Integer
            Get
                Return errorCount
            End Get
        End Property

        ''' <summary>
        ''' Returns the total Fatal Errors encountered
        ''' </summary>
        Public ReadOnly Property TotalFatalErrors As Integer
            Get
                Return failureCount
            End Get
        End Property

        ''' <summary>
        ''' Returns the total number of warnings issued
        ''' </summary>
        Public ReadOnly Property TotalWarnings As Integer
            Get
                Return warningCount
            End Get
        End Property


    End Class
End Namespace
