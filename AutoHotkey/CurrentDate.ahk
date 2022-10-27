;Always force new script instance
#SingleInstance Force
~F1::Suspend 
~F4::Reload

;Date and Time Variables: https://www.autohotkey.com/docs/Variables.htm#date
::today:: 
FormatTime, todayFormatted,, dd.MM.yyyy
SendInput %todayFormatted%
return

::yesterday::
now = %a_now%
yesterday += -1, days
FormatTime, yesterdayFormatted, %yesterday%, dd.MM.yyyy
SendInput %yesterdayFormatted%
return
