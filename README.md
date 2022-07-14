# XafBashDeployDemo 

###### Requirements 
-a clean ubunto 18 or greater server
-dotnet is not required if you compile a self contained app
-install the gdip library (this is required by the dotnet framework) https://www.jocheojeda.com/2020/10/29/how-to-fix-the-type-initializer-for-gdip-threw-an-exception-caused-by-the-netcore-framework-depencency-when-you-run-a-xaf-blazor-app-on-ubuntu-linux-18-04/
 

 ######  How to use 
 to deploy your XAF app to a linux server do the following

- add execute permissions to the install script with the following command
```
chmod +x /XafDemo.BLazor.Server/InstallApp.sh
```

- Execute the script
```
 sudo ./ XafDemo.BLazor.Server/InstallApp.sh
 ```


