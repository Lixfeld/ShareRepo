;Always force new script instance
#SingleInstance Force
~F1::Suspend 
~F4::Reload

;Google clipboard
#g::RunBrowser("firefox", "http://www.google.com/search?q=")
;Translate clipboard
#t::RunBrowser("chrome", "http://dict.leo.org/german-english/")

RunBrowser(browserName, url)
{
    searchString := GetSearchString()
    if (searchString != "")
    {
        Run, %browserName%.exe %url%%searchString%
        WinWait, ahk_exe %browserName%.exe
        WinActivate, ahk_exe %browserName%.exe
    }
}

GetSearchString()
{
    ;Save the entire clipboard to a temporary variable
    clipSaved := ClipboardAll                                   
    clipboard := ""
    Send, ^c
    ClipWait 0.5                                            
    if ErrorLevel
    {
        searchString := ""
    }
    else
    {
        ;Remove all CR+LF's from the clipboard contents
        searchString := StrReplace(Clipboard, "`r`n")
        ;Replace all spaces with pluses       
        searchString := StrReplace(searchString, A_Space, "+")  
    }
    ;Restore the original clipboard
    Clipboard := clipSaved                                      
    return searchString
}