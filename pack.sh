#!/bin/bash
rm ./nuget/Xaf.Blazor.1.0.1.nupkg
dotnet pack xafdemo.csproj --output ./nuget
dotnet new --uninstall Xaf.Blazor
#dotnet new -i ./nuget/Xaf.Blazor.1.0.1.nupkg