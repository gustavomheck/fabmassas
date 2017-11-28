;Constantes do sistema: http://www.jrsoftware.org/ishelp/index.php?topic=consts

#define use_msi31   
#define MyAppName "Martin Massas"
#define MyAppVersion "2017.12.1"
#define MyAppPublisher "UNISC"
#define MyAppExeName "Unisc.Massas.Client.exe"
#define Caminho "C:\Users\heck_\Source\Workspaces\SCInfo GDE\Gerenciador para Mecânicas\"
#define Desktop "C:\Users\heck_\Desktop"
#define Desktop "D:\Users\heck_\Documents\Programas"

[Setup]
AppId={{9158A1D6-DE22-4A14-B26C-F38AB2250BC1}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppCopyright=Copyright © UNISC 2017
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\Martin Massas
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir={#Desktop}
OutputBaseFilename=Martin Massas {#MyAppVersion}
;SetupIconFile={#Caminho}src\Unisc.Massas.Client\Resources\icone.ico
Compression=lzma
SolidCompression=yes
WizardImageFile={#Caminho}Solution Items\Instalador\SetupModern11.bmp
WizardSmallImageFile={#Caminho}Solution Items\Instalador\SetupModernSmall11.bmp     
ArchitecturesAllowed=x86 x64 ia64
ArchitecturesInstallIn64BitMode=x64 ia64
WizardImageBackColor=clBtnHighlight
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany=UNISC
ShowTasksTreeLines=True
AlwaysShowGroupOnReadyPage=True
AlwaysShowDirOnReadyPage=True
VersionInfoDescription=Gerenciador Hoesel
VersionInfoCopyright=Copyright © UNISC 2017
VersionInfoProductName=Martin Massas
UninstallDisplayName=Martin Massas
UninstallDisplaySize=20
MinVersion=0,6.0

[Languages]
Name: br; MessagesFile: compiler:Languages\BrazilianPortuguese.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\LiveCharts.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\LiveCharts.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MahApps.Metro.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MaterialDesignColors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MaterialDesignThemes.MahApps.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Microsoft.Expression.Interactions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Microsoft.Practices.ServiceLocation.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Microsoft.Practices.Unity.Configuration.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Microsoft.Practices.Unity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Microsoft.Practices.Unity.RegistrationByConvention.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\MySql.Data.Entity.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\System.Windows.Interactivity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Client.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Client.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Data.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Domain.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Caminho}src\Unisc.Massas.Client\bin\Release\Unisc.Massas.Domain.dll.config"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon
Name: "{group}\{cm:UninstallProgram, {#MyAppName}}"; Filename: "{uninstallexe}"

#include "scripts\products.iss"
#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"

#ifdef use_msi31
#include "scripts\products\msi31.iss"
#endif

[CustomMessages]
win_sp_title=Windows %1 Service Pack %2

[Dirs]
Name: "{app}\nl"
Name: "{app}\x64"
Name: "{app}\x86"
Name: "{userappdata}\Martin Massas\Logs"

[Code]
function InitializeSetup(): boolean;
begin
	initwinversion();

#ifdef use_msi31
	msi31('3.1');
#endif
 
	Result := true;
end;
