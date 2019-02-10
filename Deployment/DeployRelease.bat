@echo off

if "%1"=="" (
	echo Path is not specified.
	GOTO end
)

echo Specified path is '%1'.

if exist "%1" (
	RMDIR /S /Q "%1"
	echo Folder '%1' was deleted.
)

if not exist "%1" (
	MKDIR "%1"
	echo Folder '%1' was created.
)

"%WinDir%\Microsoft.NET\Framework64\v4.0.30319\MsBuild.exe" ..\USClothesWebSite\USClothesWebSite.Web\USClothesWebSite.Web.csproj /nologo /t:Rebuild /p:Configuration=Release /p:Platform=AnyCPU

if not exist "%1\bin" (
	MKDIR "%1\bin"
	echo Folder '%1\bin' was created.
)

XCOPY "..\USClothesWebSite\USClothesWebSite.Web\bin\*.dll" "%1\bin\"

XCOPY "..\USClothesWebSite\USClothesWebSite.Web\Global.asax" "%1\"

XCOPY "..\USClothesWebSite\USClothesWebSite.Web\Web.config" "%1\"

XCOPY /E /I "..\USClothesWebSite\USClothesWebSite.Web\Views" "%1\Views"

XCOPY /E /I "..\USClothesWebSite\USClothesWebSite.Web\Images" "%1\Images"

XCOPY "..\USClothesWebSite\USClothesWebSite.Web\WebServices\*.svc" "%1\WebServices\"

:end
pause