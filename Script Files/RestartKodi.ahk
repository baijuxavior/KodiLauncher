/*
 * * * Compile_AHK SETTINGS BEGIN * * *

[AHK2EXE]
Exe_File=%In_Dir%\RestartKodi.exe
Created_Date=1
[VERSION]
Set_Version_Info=1
Company_Name=baijuxavior@gmail.com
File_Description=RestartKodi
File_Version=1.0.0.0
Inc_File_Version=0
Internal_Name=RestartKodi
Legal_Copyright=C@P Baiju Xavior
Original_Filename=RestartKodi
Product_Name=RestartKodi
Product_Version=1.0.0.0

* * * Compile_AHK SETTINGS END * * *
*/

#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Recommended for catching common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

RegWrite,reg_sz,HKCU,Software\Launcher4Kodi, RestartKodi, 1




	

