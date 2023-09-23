[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)][string]$StoredHashes,
    [Parameter(Mandatory = $true)][string]$DumpedImages,
    [Parameter(Mandatory = $true)][string]$OutputDir
)

$jsonData = Get-Content -LiteralPath $StoredHashes | ConvertFrom-Json
$hashTable = @{}

foreach ($jsonItem in $jsonData) {
    $jsonHash = $jsonItem.Hash
    $jsonPath = $jsonItem.Path

    if (-not $hashTable.ContainsKey($jsonHash)) {
        $hashTable[$jsonHash] = $jsonPath
    }
}

$newImages = Get-ChildItem -LiteralPath $DumpedImages -Filter *.png -Recurse

foreach ($newImage in $newImages) {
    $newHash = (Get-FileHash -LiteralPath $newImage.FullName -Algorithm MD5).Hash

    if ($hashTable.ContainsKey($newHash)) {
        $matchingPath = $hashTable[$newHash]
        Write-Host "`"$($newImage.FullName)`" == `"$matchingPath`""

        $destinationPath = [System.IO.Path]::Combine($OutputDir, $matchingPath)

        $destinationDirectory = [System.IO.Path]::GetDirectoryName($destinationPath)
        if (-not (Test-Path -LiteralPath $destinationDirectory -PathType Container)) {
            New-Item -Path $destinationDirectory -ItemType Directory -Force
        }

        Copy-Item -LiteralPath $newImage.FullName -Destination $destinationPath -Force
    }
}