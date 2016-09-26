@echo off
SET /p _FIRST="1st file you would like to merge:"
SET /p _SECOND="2nd file:"
SET /p _THIRD="Merged file name?:
type %_FIRST%  %_SECOND% > %_THIRD%
Echo