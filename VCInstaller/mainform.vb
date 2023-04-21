Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Security.Principal
Imports System.Windows.Forms

Namespace VCInstaller
    Friend Enum ArgumentsbyVCYear
        args2005
        args2008
        args_2010
        args2012
        args2013
        args_2015
    End Enum



    Partial Public Class frm_installer
        Inherits Form
        Private installer_files_full_path As String()
        Private installer_files As String()
        Private selected_files As String()

        Private installer_args_by_pkg As String()
        Private log As SimpleLogger ' Will create a fresh new log file
        Private info As String

        ''' <summary>
        ''' Construct 
        ''' </summary>
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frm_installer_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
            log = New SimpleLogger()
            log.Info("Application : " & ProductName)
            log.Info("System version reported is : " & Environment.OSVersion.ToString())
            log.Info("System is 64 bits ? :" & Environment.Is64BitOperatingSystem.ToString())
            log.Info("Current process is 64 bit? : " & Environment.Is64BitProcess.ToString())
            log.Info("Current program startup folder is : " & Environment.CurrentDirectory)

            log.Trace("Verifiy if tool can run in Admin mode ...")
            If WindowsIdentity.GetCurrent().Owner Is WindowsIdentity.GetCurrent().User Then   ' Check for Admin privileges   
                Try
                    Visible = False
                    Dim info As ProcessStartInfo = New ProcessStartInfo(Application.ExecutablePath) ' my own .exe
                    info.UseShellExecute = True
                    info.Verb = "runas"   ' invoke UAC prompt
                    Process.Start(info)
                Catch ex As Win32Exception
                    If ex.NativeErrorCode = 1223 Then 'The operation was canceled by the user.
                        MessageBox.Show("Why did you not selected Yes?", "WHY?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        log.Error("Application was not able to run in admin mode: Load event")
                        Call Application.Exit()
                    Else
                        log.Warning("The user cancelled the admin elevation or another unexpected error.")
                        Throw New Exception("Something went wrong :-(")
                    End If

                End Try
                log.Trace("Application bail out!")
                Call Application.Exit()
            Else
                'MessageBox.Show("I have admin privileges :-)");
                log.Info("I have admin privileges :-)")
            End If

            radio_select_all.Enabled = False
            radio_select_none.Enabled = False
            btn_install.Enabled = False

            installer_args_by_pkg = New String() {"/q", "/qb", "/passive /norestart", "/passive /norestart", "/install /passive /norestart", "/install /passive /norestart"}


            tabControl1.SelectedIndex = 0
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            notifyIcon1.BalloonTipTitle = "VC INSTALLER"
            notifyIcon1.Icon = Icon

            info = String.Empty

            log.Trace("Application var init reached.")

            info += "VCINstaller v" & Application.ProductVersion & Environment.NewLine
            info += "How to use this tool :" & Environment.NewLine
            info += "1 . Copy all your vcredist packages into a folder, and copy this tool too." & Environment.NewLine
            info += "2 . Click on the 'Show Files' Button and select your packages" & Environment.NewLine
            info += "3 . Once you are sure of your selection click the 'Start Install' button" & Environment.NewLine
            info += "4 . Wait for the packages to finish, a notifycation will be seen when the process is done" & Environment.NewLine
            info += " " & Environment.NewLine
            info += "This tool works better if your vcredist are named in a more readable manner such as :" & Environment.NewLine
            info += "vcredist-2010-x64.exe, vcredist_x86-2008.exe, etc" & Environment.NewLine
            info += "Just make sure the name vcredist +<year>+<type> is on the filenaame." & Environment.NewLine
            info += "Tool developer : C. A. Herrera" & Environment.NewLine

            txt_info.Text = info
            log.Trace("Application reached end of load event")
        End Sub

        Private Sub btn_exit_Click_1(sender As Object, e As EventArgs) Handles btn_exit.Click
            log.Trace("Application Exit!")
            log.Report("Errors    :" & log.TotalErrors.ToString())
            log.Report("Warnings  :" & log.TotalWarnings.ToString())
            log.Report("Failures  :" & log.TotalFatalErrors.ToString())

            Call Application.Exit()
        End Sub

        Private Sub btn_search_show_Click_1(sender As Object, e As EventArgs) Handles btn_search_show.Click
            log.Info("Searching for files")
            installer_files_full_path = Directory.GetFiles(Environment.CurrentDirectory, "*.exe", SearchOption.TopDirectoryOnly).Except(Directory.GetFiles(Environment.CurrentDirectory, Application.ProductName & "*" & ".exe")).ToArray()
            installer_files = New String(installer_files_full_path.Length - 1) {}

            If installer_files_full_path.Length = 0 Then
                log.Warning("There are no executable files on this folder. Control : " & btn_search_show.ToString())
                notifyIcon1.Text = "Warning!"
                notifyIcon1.BalloonTipText = " No Executable files were found!. Check if the tool and the files are in the same folder"
                notifyIcon1.ShowBalloonTip(1000)
            Else
                lbl_details.Text = String.Empty
                chk_file_list.Items.Clear()

                For i = 0 To installer_files_full_path.Length - 1
                    installer_files(i) = Path.GetFileName(installer_files_full_path(i))
                    log.Trace("Found files : " & installer_files(i))
                Next

                For i = 0 To installer_files_full_path.Length - 1
                    chk_file_list.Items.Add(installer_files(i))
                    log.Trace("Adding to checked list :" & installer_files(i))
                Next

                If chk_file_list.Items.Count > 0 Then
                    btn_install.Enabled = True
                    radio_select_all.Enabled = True
                    radio_select_none.Enabled = True
                    log.Trace("Check files is " & chk_file_list.Items.Count.ToString())
                    log.Trace("Button is enabled: " & btn_install.ToString())
                Else
                    btn_install.Enabled = False
                    radio_select_all.Enabled = False
                    radio_select_none.Enabled = False
                    log.Trace("Button is disabled: " & btn_install.ToString())
                End If

                lbl_details.Text += " " & installer_files_full_path.Length.ToString()
            End If
        End Sub


        Private Sub btn_install_Click_1(sender As Object, e As EventArgs) Handles btn_install.Click
            Dim inner = 0
            Dim selected = 0
            Dim exeargs = String.Empty
            Dim infolog = String.Empty
            Dim exename = String.Empty
            Dim vcinstallers As Process = New Process()

            selected_files = New String(chk_file_list.Items.Count - 1) {}

            log.Trace("Starting the install process :")
            For i = 0 To chk_file_list.Items.Count - 1
                If chk_file_list.GetItemChecked(i) = True Then
                    selected_files(Math.Min(Threading.Interlocked.Increment(inner), inner - 1)) = chk_file_list.Items(i).ToString()
                    selected += 1
                End If
            Next
            log.Info("Installing " & selected.ToString() & " selected items")
            log.Info("Intalling packages.")

            For i = 0 To chk_file_list.Items.Count - 1

                If Equals(selected_files(i), Nothing) Then Exit For

                If selected_files(i).Contains("2005") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args2005)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args2005)
                End If

                If selected_files(i).Contains("2008") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args2008)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args2008)
                End If

                If selected_files(i).Contains("2010") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args_2010)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args_2010)
                End If

                If selected_files(i).Contains("2012") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args2012)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args2012)
                End If

                If selected_files(i).Contains("2013") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args2013)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args2013)
                End If

                If selected_files(i).Contains("2015") Then
                    exename = selected_files(i)
                    exeargs = installer_args_by_pkg(ArgumentsbyVCYear.args_2015)
                    infolog = "Package " & selected_files(i) & " with argument " & installer_args_by_pkg(ArgumentsbyVCYear.args_2015)
                End If

                Dim executed = False

                Try
                    vcinstallers.StartInfo.FileName = exename
                    vcinstallers.StartInfo.Arguments = exeargs
                    executed = vcinstallers.Start()
                    If executed = False Then log.Error("Instaler didnt work on :" & exename & " with arguments : " & exeargs)
                    vcinstallers.WaitForExit()
                Catch excp As Exception
                    log.Error("An unexepected error ocurred on installing a package :" & excp.Message)
                    MessageBox.Show("An exception ocurred while installing packages " & excp.Message, "Error on install", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                log.Info(infolog)
            Next

            log.Info("Installation process is done")
            log.Trace("Disposing of Process instance")
            vcinstallers.Dispose()
            notifyIcon1.Text = "Process is finished"
            notifyIcon1.BalloonTipText = "Process is done, check in Control Panel or Setting for all the installed packages"
            notifyIcon1.ShowBalloonTip(1000)

        End Sub

        Private Sub notifyIcon1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            notifyIcon1.Visible = False
        End Sub

        Private Sub radio_select_all_CheckedChanged(sender As Object, e As EventArgs) Handles radio_select_all.CheckedChanged
            For i = 0 To chk_file_list.Items.Count - 1
                chk_file_list.SetItemCheckState(i, CheckState.Checked)
            Next
            log.Trace("Selected files : " & chk_file_list.Items.Count.ToString())
            log.Trace("Event click :" & radio_select_all.ToString())
        End Sub

        Private Sub radio_select_none_CheckedChanged(sender As Object, e As EventArgs) Handles radio_select_none.CheckedChanged
            For i = 0 To chk_file_list.Items.Count - 1
                chk_file_list.SetItemCheckState(i, CheckState.Unchecked)
            Next
            log.Trace("Unselected all files")
            log.Trace("Event Click :" & radio_select_none.ToString())
        End Sub

        Private Sub btn__view_log_Click_1(sender As Object, e As EventArgs) Handles btn__view_log.Click
            Dim viewtextprog As Process = New Process()
            Try
                If File.Exists(Assembly.GetExecutingAssembly().GetName().Name & ".log") Then
                    log.Trace("Event log is being reviewed. Control : " & btn__view_log.ToString())
                    viewtextprog.StartInfo.FileName = "notepad"
                    viewtextprog.StartInfo.Arguments = Assembly.GetExecutingAssembly().GetName().Name & ".log"
                    viewtextprog.Start()
                End If
                viewtextprog.Dispose()
            Catch excp As Exception
                log.Debug("Exception raised :" & excp.Message)
                log.Error("Error on disposing resources " & btn__view_log.ToString())
            End Try
        End Sub

    End Class
End Namespace
