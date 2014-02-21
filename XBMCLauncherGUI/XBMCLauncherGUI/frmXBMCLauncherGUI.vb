Public Class frmXBMCLauncherGUI

    Dim RegistrySettingsPath As String = "HKEY_CURRENT_USER\Software\XBMCLauncher"


#Region "FORM LOAD EVENTS"

    Private Sub frmXBMCLauncherGUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err

        'Startup Settings
        Me.chkStartXBMCatWinLogon.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartXBMCatWinLogon", "1")
        Me.chkStartXBMCatWinResume.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartXBMCatWinResume", "0")
        Me.chkStartXBMCPortable.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartXBMCPortable", "0")
        Me.txtStartupDelay.Text = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartupDelay", "0") / 1000

        'Focus Settings
        Me.chkDisableFocus.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "DisableFocusPermanently", "0")
        Me.chkFocusOnce.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "FocusOnce", "0")
        Me.txtFocusDelay.Text = My.Computer.Registry.GetValue(RegistrySettingsPath, "FocusDelay", "10000") / 1000 'focus delay in sec
        Me.chkFocusExternalPlayer.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "FocusExternalPlayer", "0")

        'Exit Settings
        Me.chkCloseXBMCatSleep.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "CloseXBMCatSleep", "0")
        Me.chkForceCloseXBMC.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "ForceCloseXBMC", "0")
        Me.chkStartExplorer.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartExplorer", "1")
        Me.chkStartMetroUI.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartMetroUI", "1")
        If My.Computer.Info.OSVersion >= "6.2" Then Me.chkStartMetroUI.Visible = True 'if windows 8
        Me.GroupBox1.Visible = My.Computer.Registry.GetValue(RegistrySettingsPath, "ShowCustomShutdownMenu", "0")
        Dim ShutdownAction = My.Computer.Registry.GetValue(RegistrySettingsPath, "ShutdownAction", "u")

        If ShutdownAction = "u" Then
            Me.rdShutDown.Checked = True
        End If

        If ShutdownAction = "s" Then
            Me.rdSleep.Checked = True
        End If

        If ShutdownAction = "h" Then
            Me.rdHibernate.Checked = True
        End If

        'XBMC Path Settings

        Me.lblXBMCPath.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "XBMC_Path", ""), lblXBMCPath)
        Me.lblXBMConIMONPath.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "XBMConiMON_Path", ""), lblXBMConIMONPath)
        Me.lbliMONManagerPath.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "iMON_Path", ""), lbliMONManagerPath)

        'External Players

        Me.lblExtPlayer1.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer1_Path", ""), lblExtPlayer1)
        Me.lblExtPlayer2.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer2_Path", ""), lblExtPlayer2)
        Me.lblExtPlayer3.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer3_Path", ""), lblExtPlayer3)
        Me.lblExtPlayer4.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer4_Path", ""), lblExtPlayer4)

        Me.chkFocusExternalPlayer.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "FocusExternalPlayer", "0")


        'EXTERNAL APPS

        Me.lblApp1.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App1_Path", ""), lblApp1)
        Me.lblApp2.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App2_Path", ""), lblApp2)
        Me.lblApp3.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App3_Path", ""), lblApp3)
        Me.lblApp4.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App4_Path", ""), lblApp4)
        Me.lblApp5.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App5_Path", ""), lblApp5)
        Me.lblApp6.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App6_Path", ""), lblApp6)
        Me.lblApp7.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App7_Path", ""), lblApp7)
        Me.lblApp8.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App8_Path", ""), lblApp8)
        Me.lblApp9.Text = ShrinkPathText(My.Computer.Registry.GetValue(RegistrySettingsPath, "App9_Path", ""), lblApp9)

        Me.chkStartExternalApps1.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartApps1", "0")
        Me.chkStartExternalApps2.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartApps2", "0")
        Me.chkStartExternalApps3.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "StartApps3", "0")

        Me.chkPreventFocusExternalApps1.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "PreventFocusApps1", "0")
        Me.chkPreventFocusExternalApps2.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "PreventFocusApps2", "0")
        Me.chkPreventFocusExternalApps3.Checked = My.Computer.Registry.GetValue(RegistrySettingsPath, "PreventFocusApps3", "0")



        'Shell Settings
        Me.lblShell.Text = ""
        Dim Shell As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", "Explorer.exe")
        If Shell.ToLower.Contains("explorer") Then
            Me.rdShellWindowsExplorer.Checked = True
        ElseIf Shell.Contains("XBMCLauncher.exe") Then
            Me.rdShellXBMCLauncher.Checked = True
        Else
            Me.rdShellOthers.Checked = True
            Me.lblShell.Text = Shell
        End If
        Exit Sub
err:
        MsgBox(Err.Description, vbOK + vbInformation)
    End Sub

#End Region


#Region "STATRUP SETTINGS"

    Private Sub chkStartAtWinLogon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartXBMCatWinLogon.Click
        Dim chk As Integer
        If Me.chkStartXBMCatWinLogon.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartXBMCatWinLogon", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub


    Private Sub chkStartAtWinResume_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartXBMCatWinResume.Click
        Dim chk As Integer
        If Me.chkStartXBMCatWinResume.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartXBMCatWinResume", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkStartPortable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartXBMCPortable.Click
        Dim chk As Integer
        If Me.chkStartXBMCPortable.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartXBMCPortable", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub txtStartupDelay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartupDelay.TextChanged
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartupDelay", Val(Me.txtStartupDelay.Text) * 1000, Microsoft.Win32.RegistryValueKind.String)
    End Sub

#End Region



#Region "FOCUS SETTINGS"

    Private Sub txtFocusDelay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFocusDelay.TextChanged
        My.Computer.Registry.SetValue(RegistrySettingsPath, "FocusDelay", Me.txtFocusDelay.Text * 1000, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkDisableFocus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisableFocus.Click
        Dim chk As Integer
        If Me.chkDisableFocus.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "DisableFocusPermanently", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkFocusOnce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFocusOnce.Click
        Dim chk As Integer
        If Me.chkFocusOnce.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "FocusOnce", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub


#End Region


#Region "EXIT SETTINGS"

    Private Sub chkCloseXBMC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCloseXBMCatSleep.Click
        Dim chk As Integer
        If Me.chkCloseXBMCatSleep.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "CloseXBMCatSleep", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub


    Private Sub chkForceCloseXBMC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkForceCloseXBMC.Click
        Dim chk As Integer
        If Me.chkForceCloseXBMC.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ForceCloseXBMC", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkStartExplorer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartExplorer.Click
        Dim chk As Integer
        If Me.chkStartExplorer.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartExplorer", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkStartMetroUI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartMetroUI.Click
        Dim chk As Integer
        If Me.chkStartMetroUI.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartMetroUI", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub rdShutDown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdShutDown.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ShutdownAction", "u", Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub rdSleep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSleep.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ShutdownAction", "s", Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub rdHibernate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdHibernate.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ShutdownAction", "h", Microsoft.Win32.RegistryValueKind.String)
    End Sub

#End Region


#Region " XBMC PATH SETTINGS"

    Private Sub btnSelectXBMCPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectXBMCPath.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select XBMC Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim xbmcpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "XBMC_Path", "")
        If xbmcpath = "" Then xbmcpath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\XBMC\XBMC.exe"
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(xbmcpath)
        OpenFileDialog1.FileName = "XBMC.exe"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            xbmcpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "XBMC_Path", xbmcpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblXBMCPath.Text = ShrinkPathText(xbmcpath, Me.lblXBMCPath)
        End If
    End Sub

    Private Sub btnSelectXBMConIMONPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectXBMConIMONPath.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select XBMC on iMON Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim xbmconimonpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "XBMConiMON_Path", "")
        If xbmconimonpath = "" Then xbmconimonpath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\XBMC\XBMC.exe"
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(xbmconimonpath)
        OpenFileDialog1.FileName = "xbmconimon.exe"

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            xbmconimonpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "XBMConiMON_Path", xbmconimonpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblXBMConIMONPath.Text = ShrinkPathText(xbmconimonpath, Me.lblXBMConIMONPath)
        End If
    End Sub

    Private Sub btnSelectiMONManagerPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectiMONManagerPath.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select iMON Manager Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim imonpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "iMON_Path", "")
        If imonpath = "" Then imonpath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\SoundGraph\iMON\iMON.exe"
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(imonpath)
        OpenFileDialog1.FileName = "iMON.exe"

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            imonpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "iMON_Path", imonpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lbliMONManagerPath.Text = ShrinkPathText(imonpath, lbliMONManagerPath)
        End If
    End Sub


    Private Sub btnClearXBMCPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearXBMCPath.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "XBMC_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblXBMCPath.Text = ""
    End Sub

    Private Sub btnClearXBMConIMONPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearXBMConIMONPath.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "XBMConiMON_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblXBMConIMONPath.Text = ""
    End Sub

    Private Sub btnCleariMONManagerPOath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleariMONManagerPOath.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "iMON_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lbliMONManagerPath.Text = ""
    End Sub

   

#End Region

#Region "EXTERNAL PLAYERS"


    Private Sub chkFocusExternalPlayer_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFocusExternalPlayer.Click
        Dim chk As Integer
        If Me.chkFocusExternalPlayer.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "FocusExternalPlayer", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub
   

    Private Sub btnSelectExtPlayer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectExtPlayer1.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Player Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim externalplayerpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer1_Path", "")
        If externalplayerpath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(externalplayerpath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(externalplayerpath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            externalplayerpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer1_Path", externalplayerpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblExtPlayer1.Text = ShrinkPathText(externalplayerpath, lblExtPlayer1)
        End If
    End Sub

    Private Sub btnSelectExtPlayer2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectExtPlayer2.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Player Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim externalplayerpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer2_Path", "")
        If externalplayerpath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(externalplayerpath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(externalplayerpath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            externalplayerpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer2_Path", externalplayerpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblExtPlayer2.Text = ShrinkPathText(externalplayerpath, lblExtPlayer2)
        End If
    End Sub

    Private Sub btnSelectExtPlayer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectExtPlayer3.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Player Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim externalplayerpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer3_Path", "")
        If externalplayerpath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(externalplayerpath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(externalplayerpath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            externalplayerpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer3_Path", externalplayerpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblExtPlayer3.Text = ShrinkPathText(externalplayerpath, lblExtPlayer3)
        End If
    End Sub

    Private Sub btnSelectExtPlayer4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectExtPlayer4.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Player Path"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim externalplayerpath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "ExternalPlayer4_Path", "")
        If externalplayerpath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(externalplayerpath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(externalplayerpath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            externalplayerpath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer4_Path", externalplayerpath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblExtPlayer4.Text = ShrinkPathText(externalplayerpath, lblExtPlayer4)
        End If
    End Sub


    Private Sub btnClearExtPlayer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearExtPlayer1.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer1_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblExtPlayer1.Text = ""
    End Sub

    Private Sub btnClearExtPlayer2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearExtPlayer2.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer2_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblExtPlayer2.Text = ""
    End Sub

    Private Sub btnClearExtPlayer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearExtPlayer3.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer3_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblExtPlayer3.Text = ""
    End Sub

    Private Sub btnClearExtPlayer4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearExtPlayer4.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ExternalPlayer4_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblExtPlayer4.Text = ""
    End Sub

#End Region

#Region "EXTERNAL APPS SETTINGS"

    Private Sub btnSelectApp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp1.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App1_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If

        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App1_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp1.Text = ShrinkPathText(AppPath, lblApp1)
        End If
    End Sub

    Private Sub btnSelectApp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp2.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App2_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App2_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp2.Text = ShrinkPathText(AppPath, lblApp2)
        End If
    End Sub

    Private Sub btnSelectApp3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp3.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App3_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App3_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp3.Text = ShrinkPathText(AppPath, lblApp3)
        End If
    End Sub

    Private Sub btnSelectApp4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp4.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App4_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App4_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp4.Text = ShrinkPathText(AppPath, lblApp4)
        End If
    End Sub

    Private Sub btnSelectApp5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp5.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App5_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App5_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp5.Text = ShrinkPathText(AppPath, lblApp5)
        End If
    End Sub

    Private Sub btnSelectApp6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp6.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App6_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App6_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp6.Text = ShrinkPathText(AppPath, lblApp6)
        End If
    End Sub


    Private Sub btnSelectApp7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp7.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App7_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App7_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp7.Text = ShrinkPathText(AppPath, lblApp7)
        End If
    End Sub

    Private Sub btnSelectApp8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp8.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App8_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App8_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp8.Text = ShrinkPathText(AppPath, lblApp8)
        End If
    End Sub

    Private Sub btnSelectApp9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectApp9.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select External Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim AppPath As String = My.Computer.Registry.GetValue(RegistrySettingsPath, "App9_Path", "")
        If AppPath = "" Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(AppPath)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(AppPath)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            AppPath = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue(RegistrySettingsPath, "App9_Path", AppPath, Microsoft.Win32.RegistryValueKind.String)
            Me.lblApp9.Text = ShrinkPathText(AppPath, lblApp9)
        End If
    End Sub

    Private Sub chkStartExternalApps1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartExternalApps1.Click
        Dim chk As Integer
        If Me.chkStartExternalApps1.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartApps1", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkPreventFocusExternalApps1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreventFocusExternalApps1.Click
        Dim chk As Integer
        If Me.chkPreventFocusExternalApps1.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "PreventFocusApps1", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkStartExternalApps2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartExternalApps2.Click
        Dim chk As Integer
        If Me.chkStartExternalApps2.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartApps2", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkPreventFocusExternalApps2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreventFocusExternalApps2.Click
        Dim chk As Integer
        If Me.chkPreventFocusExternalApps2.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "PreventFocusApps2", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub


    Private Sub chkStartExternalApps3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartExternalApps3.Click
        Dim chk As Integer
        If Me.chkStartExternalApps3.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "StartApps3", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub

    Private Sub chkPreventFocusExternalApps3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreventFocusExternalApps3.Click
        Dim chk As Integer
        If Me.chkPreventFocusExternalApps3.Checked Then chk = 1 Else chk = 0
        My.Computer.Registry.SetValue(RegistrySettingsPath, "PreventFocusApps3", chk, Microsoft.Win32.RegistryValueKind.String)
    End Sub


    ' --------------------------------------        CLEAR EXTERNAL APPS --------------------------------------------------------





    Private Sub btnClearApp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp1.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App1_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp1.Text = ""
    End Sub

    Private Sub btnClearApp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp2.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App2_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp2.Text = ""
    End Sub

    Private Sub btnClearApp3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp3.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App3_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp3.Text = ""
    End Sub

    Private Sub btnClearApp4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp4.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App4_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp4.Text = ""
    End Sub

    Private Sub btnClearApp5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp5.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App5_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp5.Text = ""
    End Sub

    Private Sub btnClearApp6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp6.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App6_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp6.Text = ""
    End Sub

    Private Sub btnClearApp7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp7.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App7_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp7.Text = ""
    End Sub

    Private Sub btnClearApp8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp8.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App8_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp8.Text = ""
    End Sub

    Private Sub btnClearApp9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearApp9.Click
        My.Computer.Registry.SetValue(RegistrySettingsPath, "App9_Path", "", Microsoft.Win32.RegistryValueKind.String)
        Me.lblApp9.Text = ""
    End Sub
#End Region


#Region "SHELL SETTINGS"

    Private Sub rdShellExplorer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdShellWindowsExplorer.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", "Explorer.exe", Microsoft.Win32.RegistryValueKind.String)
        Me.lblShell.Text = ""
    End Sub

    Private Sub rdShellLauncher_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdShellXBMCLauncher.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", My.Application.Info.DirectoryPath & "\XBMCLauncher.exe", Microsoft.Win32.RegistryValueKind.String)
        Me.lblShell.Text = ""
    End Sub

    Private Sub btnSelectShell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectShell.Click
        OpenFileDialog1.Filter = "Executable File|*.exe"
        OpenFileDialog1.Title = "Select Shell Application"
        OpenFileDialog1.AutoUpgradeEnabled = True
        Dim Shell As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", "Explorer.exe")
        If Shell = "" Or Shell.ToLower.Contains("explorer") Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Else
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(Shell)
        End If
        OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(Shell)

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'if ok button clicked
            Application.DoEvents() 'first close the selection window
            Shell = OpenFileDialog1.FileName
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", Shell, Microsoft.Win32.RegistryValueKind.String)
            Me.lblShell.Text = Shell
            Me.rdShellOthers.Checked = True
        End If
    End Sub
#End Region

    Private Sub EndApplication() Handles MyBase.FormClosed
        On Error Resume Next
        My.Computer.Registry.SetValue(RegistrySettingsPath, "ReloadXBMCLauncher", 1, Microsoft.Win32.RegistryValueKind.String)
        Shell(My.Application.Info.DirectoryPath & "\XBMCLauncher.exe /r", AppWinStyle.Hide) 'Reload XBMCLauncher script.
    End Sub

    Public Function ShrinkPathText(ByVal sString As String, ByVal lbl As Label) As String

        Dim strWorking As String = String.Copy(sString)
        Dim strResult As String = ""
        Dim charResult As Char = ""
        Me.ToolTip1.SetToolTip(lbl, sString)

        TextRenderer.MeasureText(strWorking, lbl.Font, New Drawing.Size(lbl.Width, 0), TextFormatFlags.PathEllipsis Or TextFormatFlags.ModifyString)

        For Each charResult In strWorking
            If charResult = Nothing Then
                Exit For
            End If
            strResult &= charResult
        Next

        Return strResult

    End Function



    Private Sub lblXBMCPath_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblXBMCPath.TextChanged, lbliMONManagerPath.TextChanged, lblXBMConIMONPath.TextChanged, lblApp1.TextChanged, lblApp2.TextChanged, lblApp3.TextChanged, lblApp4.TextChanged, lblApp5.TextChanged, lblApp6.TextChanged, lblApp7.TextChanged, lblApp8.TextChanged, lblApp9.TextChanged, lblExtPlayer1.TextChanged, lblExtPlayer2.TextChanged, lblExtPlayer3.TextChanged, lblExtPlayer4.TextChanged
        If DirectCast(sender, Label).Text = "" Then
            Me.ToolTip1.SetToolTip(DirectCast(sender, Label), "")
        End If

    End Sub



    
End Class
