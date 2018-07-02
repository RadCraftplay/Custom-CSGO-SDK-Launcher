$msbuild = Join-Path (Get-ItemProperty Registry::HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS\VS7 -Name "15.0")."15.0" "\MSBuild\15.0\Bin\MSBuild.exe"

#echo 'Msbuild path: ' $msbuild

if (Test-Path './Out') {
    Remove-Item -Recurse './Out'
}

if (Test-Path 'Custom SDK Launcher Setup.exe') { Remove-Item 'Custom SDK Launcher Setup.exe'}

$log = './Build.log'
(Set-Content $log '')

echo 'Building Solution...'
(& $msbuild '../Custom SDK Launcher.sln' '/p:Configuration=Release' '/p:VisualStudioVersion=15.0') | Add-Content $log

# Removing files

if (Test-Path '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe') {
    Remove-Item '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe'
}

if (Test-Path '../Distroir.CustomSDKLauncher.Associator/bin/Release/Distroir.CustomSDKLauncher.Associator.exe') {
    Remove-Item '../Distroir.CustomSDKLauncher.Associator/bin/Release/Distroir.CustomSDKLauncher.Associator.exe'
}

# Copying files

echo 'Copying files...'
if (Test-Path '../Distroir.CustomSDKLauncher/bin/release/Distroir.CustomSDKLauncher.exe') {
    Move-Item '../Distroir.CustomSDKLauncher/bin/release/Distroir.CustomSDKLauncher.exe' '../Distroir.CustomSDKLauncher/bin/release/Custom SDK Launcher.exe'
}

if (Test-Path '../Distroir.CustomSDKLauncher.Associator/bin/Release/Distroir.CustomSDKLauncher.Associator.exe') {
    Move-Item '../Distroir.CustomSDKLauncher.Associator/bin/Release/Distroir.CustomSDKLauncher.Associator.exe' '../Distroir.CustomSDKLauncher/bin/release/Distroir.CustomSDKLauncher.Associator.exe'
}

(& 'robocopy.exe' '../Distroir.CustomSDKLauncher/bin/release/' 'Out' '/XF' '*.pdb' '*.xml' '*.vshost.*') | Add-Content $log

echo 'Done!'