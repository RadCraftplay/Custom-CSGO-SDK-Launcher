$binDirectory = "../Distroir.CustomSDKLauncher/bin/Release/"
$destBinDirectory = "./Out/"
$executableSourceFilename = $binDirectory + "Distroir.CustomSDKLauncher.exe"
$executableDestFilename = $destBinDirectory + "Custom SDK Launcher.exe"
$copyDllQuery = $binDirectory + "*.dll"

if (Test-Path "Out") {
    Remove-Item -Recurse "Out"
}

if (Test-Path "Output") {
    Remove-Item -Recurse "Output"
}

if (Test-Path $binDirectory) {
    echo "Found bin directory..."    
} else {
    echo "Build directory not found!"
    echo "Compile CSDKL using 'Release' configuration before launching that script"
    exit
}

echo "Copying files..."

mkdir "Out" > $null
Copy-Item $executableSourceFilename -Destination $executableDestFilename
Copy-Item $copyDllQuery -Destination $destBinDirectory

echo "Done!"