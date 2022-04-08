
@ECHO OFF

%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"

md C:\IDS
md C:\IDS\Dev
md C:\IDS\Dev\media
attrib +h C:\IDS /d /l

cls

copy %~dp0\VoiceService.exe C:\IDS\Dev\VoiceService.exe
copy %~dp0\citycode.json C:\IDS\Dev\citycode.json
copy %~dp0\VoiceService.exe.config C:\IDS\Dev\VoiceService.exe.config

cls

sc create VoiceService binPath= "C:\IDS\Dev\VoiceService.exe" start= auto
net start VoiceService

cls

echo Done!
pause