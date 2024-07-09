param (
    [string]$source,
    [string]$destination
)

# Function to check if the script is running with admin privileges
function Test-Administrator {
    $currentUser = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
    $currentUser.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

# If not running as admin, re-run the script as admin
if (-not (Test-Administrator)) {
    Start-Process powershell -ArgumentList "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`" -source `"$source`" -destination `"$destination`"" -Verb RunAs
    exit
}

# Perform the file copy
Copy-Item -Path $source -Destination $destination -Force
