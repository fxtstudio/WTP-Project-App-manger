cd %cd%\\config\\data
del /f /s /q %cd%\\config\\data\\*.*
cd config\\data
rd /s /q  %cd%\\config\\data
cd ..
mkdir data
pause