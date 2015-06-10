/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\PinToTaskBar.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Create KodiLauncherGUI  shortcut in Taskbar
File_Version=1.0.0.0
Inc_File_Version=0
Internal_Name=PinToTaskbar
Legal_Copyright=C@P Baiju Xavior
Original_Filename=PinToTaskbar
Product_Name=PinToTaskbar
Product_Version=1.0.0.0

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

oSC := ComObjCreate("ScriptControl")

; define the Language
oSC.Language := "VBScript"

; define the VBScript
script =
(
Const CSIDL_COMMON_PROGRAMS = &H17
Set objShell = CreateObject("Shell.Application") 
Set objAllUsersProgramsFolder = objShell.NameSpace(CSIDL_COMMON_PROGRAMS) 
strAllUsersProgramsPath = objAllUsersProgramsFolder.Self.Path 
Set objFolder = objShell.Namespace(strAllUsersProgramsPath & "\KodiLauncher") 
Set objFolderItem = objFolder.ParseName("KodiLauncherGUI.lnk") 
Set colVerbs = objFolderItem.Verbs 
For Each objVerb in colVerbs 
    If Replace(objVerb.name, "&", "") = "Pin to Start Menu" Then objVerb.DoIt 
	If Replace(objVerb.name, "&", "") = "Pin to Taskbar" Then objVerb.DoIt

	
Next
)

oSC.ExecuteStatement(script)