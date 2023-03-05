$version = Read-Host '请输入版本号！'
Remove-Item nupkgs/*
dotnet pack -c Release --output nupkgs /p:Version=$version
cd nupkgs
dotnet nuget push -s http://121.196.122.107:8880/v3/index.json -k 3556213f-13ec-3b23-b60d-d5b3570eb4b2 *.nupkg

"`n按任意键退出：" ;
[Console]::Readkey() |　Out-Null ;
Exit ;