; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Custom CSGO SDK Launcher"
#define MyAppVersion "4"
#define MyAppPublisher "Distroir"
#define MyAppExeName "Custom SDK Launcher.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{6599D896-DE71-4685-A291-9A04AEF24FEC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
LicenseFile=License.txt
OutputDir=C:\Users\x\Documents\Visual Studio 2017\Projects\Custom SDK Launcher\Installer
OutputBaseFilename=Custom SDK Launcher Setup
Compression=lzma2
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Out\Custom SDK Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Out\Distroir.CustomSDKLauncher.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Out\Distroir.CustomSDKLauncher.Core.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Out\Distroir.CustomSDKLauncher.UI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Out\Distroir.CustomSDKLauncher.Shared.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\Users\x\Documents\Visual Studio 2017\Projects\Custom SDK Launcher\Distroir.CustomSDKLauncher\bin\Release\en\Distroir.CustomSDKLauncher.UI.resources.dll"; DestDir: "{app}\en"; Flags: ignoreversion
;Source: "C:\Users\x\Documents\Visual Studio 2017\Projects\Custom SDK Launcher\Distroir.CustomSDKLauncher\bin\Release\pl\Distroir.CustomSDKLauncher.UI.resources.dll"; DestDir: "{app}\pl"; Flags: ignoreversion
Source: "gpl3.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "License.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "FUGUE-README.txt"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function UninstallNeedRestart(): Boolean;
begin
  Result := true
end;