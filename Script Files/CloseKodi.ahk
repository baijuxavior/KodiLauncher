/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\CloseXBMC.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Custom Close for XBMC
File_Version=4.0.0.0
Inc_File_Version=0
Internal_Name=Close XBMC
Legal_Copyright=C@P Baiju Xavior
Original_Filename=Close XBMC
Product_Name=Close XBMC
Product_Version=4.0.0.0

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.


global ForceCloseXBMC := GetSettings("ForceCloseXBMC", 0)

GetSettings(SettingsName, DefaultValue) ;Get settings from registry 
{
	RegRead, result, HKCU, Software\XBMCLauncher, %SettingsName%
	if (result = "")
		return %DefaultValue%
	else
		return %result%
}

Process, Exist, xbmc.exe ; check to see if xbmc.exe is running 
If (ErrorLevel >= 1) ; If it is running 
	{
		if (ForceCloseXBMC = 1)
			Process, Close, %ErrorLevel%  
		else
			WinClose, ahk_class XBMC
			WinWaitClose, ahk_class XBMC
	}
   
return