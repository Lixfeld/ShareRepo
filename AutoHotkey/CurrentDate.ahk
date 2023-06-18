#SuspendExempt
~F1:: Suspend
#SuspendExempt False
~F4:: Reload

;Date and Time Variables: https://www.autohotkey.com/docs/v2/Variables.htm#date
::today::
{
    todayFormatted := FormatTime(, "ShortDate")
    SendInput todayFormatted
}

::yesterday::
{
    yesterday := DateAdd(A_Now, -1, "days")
    yesterdayFormatted := FormatTime(yesterday, "ShortDate")
    SendInput yesterdayFormatted
}