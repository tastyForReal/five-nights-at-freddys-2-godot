$images = Get-ChildItem -Filter *.png -Recurse -Path .\Resources

$json = $images | ForEach-Object {
    $hash = Get-FileHash -Path $_.FullName -Algorithm MD5
    $path = $_.FullName
    $path = $path.Substring($path.IndexOf("Resources"))
    $path = $path.TrimStart("\")
    @{
        "Hash" = $hash.Hash
        "Path" = $path
    }
} | ConvertTo-Json

$json | Out-File -Force hashes.json