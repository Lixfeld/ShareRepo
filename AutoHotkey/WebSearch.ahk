#SuspendExempt
~F1:: Suspend
#SuspendExempt False
~F4:: Reload

;Google clipboard
#g:: RunBrowser("firefox.exe", "http://www.google.com/search?q=")
;Translate clipboard
#t:: RunBrowser("chrome.exe", "http://dict.leo.org/german-english/")

RunBrowser(browserName, url)
{
    searchString := GetSearchString()
    if (searchString != "")
    {
        Run browserName " " url searchString
        WinWait "ahk_exe" browserName
        WinActivate "ahk_exe" browserName
    }
}

GetSearchString()
{
    ;Save the entire clipboard to a temporary variable
    clipSaved := ClipboardAll()
    A_Clipboard := ""
    Send "^c"
    ClipWait 0.5
    ;Remove all CR+LF's from the clipboard contents
    searchString := StrReplace(A_Clipboard, "`r`n")
    ;Replace all spaces with pluses
    searchString := StrReplace(searchString, A_Space, "+")
    ;Restore the original clipboard
    A_Clipboard := clipSaved
    return searchString
}