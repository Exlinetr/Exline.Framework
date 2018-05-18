
$packFolder = (Get-Item -Path "../" -Verbose).FullName
$slnPath = Join-Path $packFolder "/"
$srcPath = Join-Path $slnPath "./src"
$nugetPath = Join-Path $packFolder "./nupkg"
$cliParh = Join-Path $packFolder "./cli-windows"


$projects = (
    "Exline.Framework",
    "Exline.Framework.Data.InMemory",
    "Exline.Framework.Data.MongoDB",
    "Exline.Framework.Data.Sql",
    "Exline.Framework.Data.Sql.Dapper",
    "Exline.Framework.DependencyInjection",
    "Exline.Framework.Web"
)

Remove-Item -Recurse ($nugetPath) 
 & mkdir $nugetPath

Set-Location $slnPath
& dotnet restore

foreach($project in $projects) {
    
    echo $project " project build";
    $projectFolder = Join-Path $srcPath $project

    Set-Location $projectFolder
    Remove-Item -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet build -c Release

    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $project + ".*.nupkg")
    Move-Item $projectPackPath $nugetPath

}

Set-Location $cliParh