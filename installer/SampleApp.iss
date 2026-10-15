; Inno Setup script for SampleApp
; Build: ISCC.exe /DAppVersion=1.2.3 installer\SampleApp.iss
; Expects published files in ..\publish (created by dotnet publish -o publish)

#ifndef AppVersion
  #define AppVersion "0.0.1"
#endif

[Setup]
AppName=SampleApp
AppVersion={#AppVersion}
AppPublisher=SampleApp Test
DefaultDirName={autopf}\SampleApp
DefaultGroupName=SampleApp
OutputDir=..\installer-out
OutputBaseFilename=SampleAppSetup-{#AppVersion}
Compression=lzma2
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=lowest
UninstallDisplayIcon={app}\SampleApp.exe

[Files]
Source: "..\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\SampleApp"; Filename: "{app}\SampleApp.exe"
Name: "{autodesktop}\SampleApp"; Filename: "{app}\SampleApp.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a desktop shortcut"; Flags: unchecked

[Run]
Filename: "{app}\SampleApp.exe"; Description: "Launch SampleApp"; Flags: nowait postinstall skipifsilent
