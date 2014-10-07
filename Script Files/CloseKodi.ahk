/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\CloseKodi.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Custom Close for Kodi
File_Version=1.0.0.0
Inc_File_Version=0
Internal_Name=Close Kodi
Legal_Copyright=C@P Baiju Xavior
Original_Filename=Close Kodi
Product_Name=Close Kodi
Product_Version=1.0.0.0

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

Process, Exist, Kodi.exe ; check to see if Kodi.exe is running 
If (ErrorLevel > 0) ; If it is running 
	{	if (ForceCloseKodi = 1)
			Process, Close, %ErrorLevel%  
		else
			{
			WinClose, ahk_class XBMC
			WinWaitClose, ahk_class XBMC
			}
	}
   
return