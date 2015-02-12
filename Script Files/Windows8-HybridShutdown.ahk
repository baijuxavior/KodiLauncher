/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\Windows8-HybridShutdown.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Windows8-HybridShutdown
File_Version=1.0.0.0
Inc_File_Version=0
Internal_Name=Windows8-HybridShutdown
Legal_Copyright=C@P Baiju Xavior
Original_Filename=Windows8-HybridShutdown
Product_Name=Windows8-HybridShutdown
Product_Version=1.0.0.0
[ICONS]
Icon_1=%In_Dir%\Windows8-HybridShutdown.ico

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

global ForceCloseKodi := GetSettings("ForceCloseKodi", 0)

GetSettings(SettingsName, DefaultValue) ;Get settings from registry 
{
	RegRead, result, HKCU, Software\Launcher4Kodi, %SettingsName%
	if (result = "")
		return %DefaultValue%
	else
		return %result%
}

if (ForceCloseKodi = 1)
	run, Shutdown.exe -s -hybrid -f -t 00, ,Hide
	;MsgBox force
else
	 ;MsgBox normal
	run, Shutdown.exe -s -hybrid -t 00, ,Hide
 