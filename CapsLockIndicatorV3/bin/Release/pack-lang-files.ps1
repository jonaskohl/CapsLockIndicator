Get-ChildItem -Recurse -Directory | ForEach-Object {
  Compress-Archive -Path "$($_.FullName)\*.dll" -DestinationPath ".\$($_.Name).zip"
}
