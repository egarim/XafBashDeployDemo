# Xaf Bash Deploy Demo 

###### Requirements 
- a clean ubunto 18 or greater server
- dotnet is not required if you compile a self contained app
- install the gdip library (this is required by the dotnet framework) https://www.jocheojeda.com/2020/10/29/how-to-fix-the-type-initializer-for-gdip-threw-an-exception-caused-by-the-netcore-framework-depencency-when-you-run-a-xaf-blazor-app-on-ubuntu-linux-18-04/
- to have installed the devexpress nuget feed for the current user and the sudo user.You can read how to install a nuget feed in the CLI here https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-add-source

 ######  How to use 
 to deploy your XAF app to a linux server do the following

- add execute permissions to the install script with the following command
```
cd XafDemo.Blazor.Server
chmod +x InstallApp.sh

```

- Execute the script

You shoul replace the following parameters
- replace 192.168.122.154 for the ip of your server
- replace joche for the username of your server
- replace /home/joche/ for the path where you want to install the app in your server


```

sudo ./InstallApp.sh 192.168.122.154 joche /home/joche/ XafDemo.Blazor.Server

 ```




For this demo I have set the application to always update the database you can see here [GitHub Pages](https://github.com/egarim/XafBashDeployDemo/blob/1ccc97f755300d3a9052b6175739152794efc985/XafDemo.Blazor.Server/BlazorApplication.cs#L41)


###### Install the app
after the application is deploy you need to ssh to your server and install it

```

sudo ./install_XafDemo.Blazor.Server.sh

```
To check the service status you should run the following command
```

sudo ./status_XafDemo.Blazor.Server.sh

```



