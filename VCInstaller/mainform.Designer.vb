Namespace VCInstaller
	Partial Public Class frm_installer
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
            Me.tabControl1 = New System.Windows.Forms.TabControl()
            Me.tabPage1 = New System.Windows.Forms.TabPage()
            Me.btn__view_log = New System.Windows.Forms.Button()
            Me.chk_file_list = New System.Windows.Forms.CheckedListBox()
            Me.btn_install = New System.Windows.Forms.Button()
            Me.grp_options = New System.Windows.Forms.GroupBox()
            Me.radio_select_none = New System.Windows.Forms.RadioButton()
            Me.radio_select_all = New System.Windows.Forms.RadioButton()
            Me.lbl_details = New System.Windows.Forms.Label()
            Me.btn_search_show = New System.Windows.Forms.Button()
            Me.tabPage2 = New System.Windows.Forms.TabPage()
            Me.txt_info = New System.Windows.Forms.TextBox()
            Me.btn_exit = New System.Windows.Forms.Button()
            Me.tabControl1.SuspendLayout()
            Me.tabPage1.SuspendLayout()
            Me.grp_options.SuspendLayout()
            Me.tabPage2.SuspendLayout()
            Me.SuspendLayout()
            '
            'notifyIcon1
            '
            Me.notifyIcon1.Text = "notifyIcon1"
            Me.notifyIcon1.Visible = True
            '
            'tabControl1
            '
            Me.tabControl1.Controls.Add(Me.tabPage1)
            Me.tabControl1.Controls.Add(Me.tabPage2)
            Me.tabControl1.Location = New System.Drawing.Point(1, 2)
            Me.tabControl1.Name = "tabControl1"
            Me.tabControl1.SelectedIndex = 0
            Me.tabControl1.Size = New System.Drawing.Size(498, 297)
            Me.tabControl1.TabIndex = 5
            '
            'tabPage1
            '
            Me.tabPage1.Controls.Add(Me.btn__view_log)
            Me.tabPage1.Controls.Add(Me.chk_file_list)
            Me.tabPage1.Controls.Add(Me.btn_install)
            Me.tabPage1.Controls.Add(Me.grp_options)
            Me.tabPage1.Controls.Add(Me.lbl_details)
            Me.tabPage1.Controls.Add(Me.btn_search_show)
            Me.tabPage1.Location = New System.Drawing.Point(4, 22)
            Me.tabPage1.Name = "tabPage1"
            Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPage1.Size = New System.Drawing.Size(490, 271)
            Me.tabPage1.TabIndex = 0
            Me.tabPage1.Text = "Main"
            Me.tabPage1.UseVisualStyleBackColor = True
            '
            'btn__view_log
            '
            Me.btn__view_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn__view_log.Location = New System.Drawing.Point(351, 229)
            Me.btn__view_log.Name = "btn__view_log"
            Me.btn__view_log.Size = New System.Drawing.Size(129, 23)
            Me.btn__view_log.TabIndex = 11
            Me.btn__view_log.Text = "View log"
            Me.btn__view_log.UseVisualStyleBackColor = True
            '
            'chk_file_list
            '
            Me.chk_file_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chk_file_list.CheckOnClick = True
            Me.chk_file_list.Cursor = System.Windows.Forms.Cursors.Hand
            Me.chk_file_list.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chk_file_list.FormattingEnabled = True
            Me.chk_file_list.Location = New System.Drawing.Point(8, 6)
            Me.chk_file_list.Name = "chk_file_list"
            Me.chk_file_list.Size = New System.Drawing.Size(318, 197)
            Me.chk_file_list.TabIndex = 10
            '
            'btn_install
            '
            Me.btn_install.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn_install.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_install.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btn_install.Location = New System.Drawing.Point(352, 175)
            Me.btn_install.Name = "btn_install"
            Me.btn_install.Size = New System.Drawing.Size(128, 23)
            Me.btn_install.TabIndex = 9
            Me.btn_install.Text = "Start Install"
            Me.btn_install.UseVisualStyleBackColor = True
            '
            'grp_options
            '
            Me.grp_options.Controls.Add(Me.radio_select_none)
            Me.grp_options.Controls.Add(Me.radio_select_all)
            Me.grp_options.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grp_options.Location = New System.Drawing.Point(351, 68)
            Me.grp_options.Name = "grp_options"
            Me.grp_options.Size = New System.Drawing.Size(130, 90)
            Me.grp_options.TabIndex = 8
            Me.grp_options.TabStop = False
            Me.grp_options.Text = "Options"
            '
            'radio_select_none
            '
            Me.radio_select_none.AutoSize = True
            Me.radio_select_none.Location = New System.Drawing.Point(21, 56)
            Me.radio_select_none.Name = "radio_select_none"
            Me.radio_select_none.Size = New System.Drawing.Size(84, 17)
            Me.radio_select_none.TabIndex = 1
            Me.radio_select_none.TabStop = True
            Me.radio_select_none.Text = "Select None"
            Me.radio_select_none.UseVisualStyleBackColor = True
            '
            'radio_select_all
            '
            Me.radio_select_all.AutoSize = True
            Me.radio_select_all.Location = New System.Drawing.Point(21, 33)
            Me.radio_select_all.Name = "radio_select_all"
            Me.radio_select_all.Size = New System.Drawing.Size(69, 17)
            Me.radio_select_all.TabIndex = 0
            Me.radio_select_all.TabStop = True
            Me.radio_select_all.Text = "Select All"
            Me.radio_select_all.UseVisualStyleBackColor = True
            '
            'lbl_details
            '
            Me.lbl_details.AutoSize = True
            Me.lbl_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_details.Location = New System.Drawing.Point(348, 40)
            Me.lbl_details.Name = "lbl_details"
            Me.lbl_details.Size = New System.Drawing.Size(43, 13)
            Me.lbl_details.TabIndex = 6
            Me.lbl_details.Text = "Found :"
            '
            'btn_search_show
            '
            Me.btn_search_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn_search_show.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_search_show.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btn_search_show.Location = New System.Drawing.Point(351, 6)
            Me.btn_search_show.Name = "btn_search_show"
            Me.btn_search_show.Size = New System.Drawing.Size(130, 23)
            Me.btn_search_show.TabIndex = 5
            Me.btn_search_show.Text = "Show Files"
            Me.btn_search_show.UseVisualStyleBackColor = True
            '
            'tabPage2
            '
            Me.tabPage2.Controls.Add(Me.txt_info)
            Me.tabPage2.Location = New System.Drawing.Point(4, 22)
            Me.tabPage2.Name = "tabPage2"
            Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPage2.Size = New System.Drawing.Size(490, 271)
            Me.tabPage2.TabIndex = 1
            Me.tabPage2.Text = "About"
            Me.tabPage2.UseVisualStyleBackColor = True
            '
            'txt_info
            '
            Me.txt_info.BackColor = System.Drawing.Color.LightYellow
            Me.txt_info.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txt_info.Location = New System.Drawing.Point(61, 25)
            Me.txt_info.Multiline = True
            Me.txt_info.Name = "txt_info"
            Me.txt_info.ReadOnly = True
            Me.txt_info.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txt_info.Size = New System.Drawing.Size(423, 231)
            Me.txt_info.TabIndex = 0
            '
            'btn_exit
            '
            Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn_exit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btn_exit.Location = New System.Drawing.Point(369, 305)
            Me.btn_exit.Name = "btn_exit"
            Me.btn_exit.Size = New System.Drawing.Size(130, 23)
            Me.btn_exit.TabIndex = 7
            Me.btn_exit.Text = "Exit"
            Me.btn_exit.UseVisualStyleBackColor = True
            '
            'frm_installer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(509, 341)
            Me.Controls.Add(Me.tabControl1)
            Me.Controls.Add(Me.btn_exit)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MaximizeBox = False
            Me.Name = "frm_installer"
            Me.Text = "VC Installer"
            Me.tabControl1.ResumeLayout(False)
            Me.tabPage1.ResumeLayout(False)
            Me.tabPage1.PerformLayout()
            Me.grp_options.ResumeLayout(False)
            Me.grp_options.PerformLayout()
            Me.tabPage2.ResumeLayout(False)
            Me.tabPage2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private WithEvents notifyIcon1 As System.Windows.Forms.NotifyIcon
		Private tabControl1 As System.Windows.Forms.TabControl
		Private tabPage1 As System.Windows.Forms.TabPage
		Private chk_file_list As System.Windows.Forms.CheckedListBox
		Private WithEvents btn_install As System.Windows.Forms.Button
		Private WithEvents btn_exit As System.Windows.Forms.Button
		Private grp_options As System.Windows.Forms.GroupBox
		Private WithEvents radio_select_none As System.Windows.Forms.RadioButton
		Private WithEvents radio_select_all As System.Windows.Forms.RadioButton
		Private lbl_details As System.Windows.Forms.Label
		Private WithEvents btn_search_show As System.Windows.Forms.Button
		Private tabPage2 As System.Windows.Forms.TabPage
		Private txt_info As System.Windows.Forms.TextBox
		Private WithEvents btn__view_log As System.Windows.Forms.Button
	End Class
End Namespace

