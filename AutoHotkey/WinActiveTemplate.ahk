;Always force new script instance
#SingleInstance Force
~F1::Suspend 
~F4::Reload

#IfWinActive ahk_exe notepad.exe
LButton::j
RButton::k
XButton1::l
#IfWinActive ;End of WinActive scope
