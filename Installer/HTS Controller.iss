; -- sync.iss --

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!
#define SemanticVersion() \
   GetVersionComponents("..\HTS Controller\bin\x64\Release\HTSController.exe", Local[0], Local[1], Local[2], Local[3]), \
   Str(Local[0]) + "." + Str(Local[1]) + ((Local[2]>0) ? "." + Str(Local[2]) : "")
    
#define verStr_ StringChange(SemanticVersion(), '.', '-')
#define DevRoot GetEnv("DEVROOT")
#if DevRoot == ""
    #error "DEVROOT environment variable is not set"
#endif

[Setup]
AppName=Hearing Test Suite Controller
AppVerName=Hearing Test Suite Controller V{#SemanticVersion()}
DefaultDirName={commonpf}\EPL\C462\Hearing Test Suite Controller\V{#SemanticVersion()}
OutputDir=Output
DefaultGroupName=EPL
AllowNoIcons=yes
OutputBaseFilename=HTS_Controller_{#verStr_}
UsePreviousAppDir=no
UsePreviousGroup=no
UsePreviousSetupType=no
DisableProgramGroupPage=yes
PrivilegesRequired=admin

[Dirs]
Name: "{commonappdata}\EPL";

[Files]
Source: "{#DevRoot}\C462\c462-shared\Installer\Output\C462SharedResearcherSetup.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "..\HTS Controller\Images\HTS.ico"; DestDir: "{app}"; Flags: replacesameversion;
Source: "..\HTS Controller\bin\x64\Release\*.*"; DestDir: "{app}"; Flags: replacesameversion;
Source: "..\CHANGELOG.md"; DestDir: "{app}"; Flags: replacesameversion;

[Icons]
Name: "{commondesktop}\HTS Controller"; Filename: "{app}\HTSController.exe"; IconFilename: "{app}\HTS.ico"; IconIndex: 0;

[Run]
Filename: "{tmp}\C462SharedResearchSetup.exe"; Parameters: "/SILENT"; Description: "Installing shared components"; Flags: waituntilterminated


