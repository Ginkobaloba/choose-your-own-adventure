@echo off
SET /p _FIRST="Enter Username:"
Pause
SET /p _SECOND="Enter Password:"
Pause
NET user %_FIRST% %_SECOND% /add
Echo on