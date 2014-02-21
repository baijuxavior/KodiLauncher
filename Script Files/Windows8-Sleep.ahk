/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\Windows8-Sleep.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=Windows8-Sleep PC
File_Version=4.0.0.0
Inc_File_Version=0
Internal_Name=Windows8-Sleep
Legal_Copyright=C@P Baiju Xavior
Original_Filename=Windows8-Sleep
Product_Name=Windows8-Sleep
Product_Version=4.0.0.0
[ICONS]
Icon_1=%In_Dir%\Windows8-Sleep.ico

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

DllCall("PowrProf\SetSuspendState", "int", 0)