$msbuild = Join-Path (Get-ItemProperty Registry::HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS\VS7 -Name "15.0")."15.0" "\MSBuild\15.0\Bin\MSBuild.exe"

#echo 'Msbuild path: ' $msbuild

echo 'Removing old files...'

if (Test-Path './Out') {
    Remove-Item -Recurse './Out'
}

if (Test-Path '../Distroir.CustomSDKLauncher/bin/Release') {
    Remove-Item -Recurse '../Distroir.CustomSDKLauncher/bin/Release'
}

if (Test-Path 'Custom SDK Launcher Setup.exe') {
    Remove-Item 'Custom SDK Launcher Setup.exe'
}

$log = './Build.log'
(Set-Content $log '')

echo 'Building Solution...'
(& $msbuild '../Custom SDK Launcher.sln' '/p:Configuration=Release' '/p:VisualStudioVersion=15.0') | Add-Content $log

if (Test-Path '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe') {
    Remove-Item '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe'
}

echo 'Copying files...'
if (Test-Path '../Distroir.CustomSDKLauncher/bin/release/Distroir.CustomSDKLauncher.exe') {
    Move-Item '../Distroir.CustomSDKLauncher/bin/release/Distroir.CustomSDKLauncher.exe' '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe'
}

(& 'robocopy.exe' '../Distroir.CustomSDKLauncher/bin/release/' 'Out' '/XF' '*.pdb' '*.xml' '*.vshost.*') | Add-Content $log

echo 'Done!'