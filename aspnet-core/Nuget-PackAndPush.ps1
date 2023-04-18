$version = Read-Host '请输入版本号！'
$url = Read-Host '请输入仓库地址！'
Remove-Item nupkgs/*
dotnet pack -c Release --output nupkgs /p:Version=$version
cd nupkgs
dotnet nuget push -s $url *.nupkg

"`n按任意键退出：" ;
[Console]::Readkey() |　Out-Null ;
Exit ;