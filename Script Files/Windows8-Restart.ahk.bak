/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\Windows8-Restart.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Windows8-Restart PC
File_Version=1.0.0.0
Inc_File_Version=0
Internal_Name=Windows8-Restart
Legal_Copyright=C@P Baiju Xavior
Original_Filename=Windows8-Restart
Product_Name=Windows8-Restart
Product_Version=1.0.0.0
[ICONS]
Icon_1=%In_Dir%\Windows8-Restart.ico

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

global ForceCloseKodi := GetSettings("ForceCloseKodi", 0)

GetSettings(SettingsName, DefaultValue) ;Get settings from registry 
{
	RegRead, result, HKCU, Software\KodiLauncher, %SettingsName%
	if (result = "")
		return %DefaultValue%
	else
		return %result%
}

if (ForceCloseKodi = 1)
	Shutdown, 6 ; reboot = 2, force = 4
	;MsgBox force
else
	Shutdown, 2
	;MsgBox normal

