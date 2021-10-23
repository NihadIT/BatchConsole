@echo of
SETLOCAL EnableDelayedExpansion
for /f "Tokens=* Delims=" %%x in (file.txt) do set Build=!Build! %%x
start "start.exe" "bin\Debug\ConsoleApp.exe" %Build%  
exit