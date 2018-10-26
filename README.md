Passwordless Login Samples
==========================

Getting Started
---------------

First clone this repo and select a sample project and open it in Visual Studio or VS Code. Then complete the additional setup steps below.

### Database ###

1. Create a SQL Server database and initialize the schema with [this script](
https://raw.githubusercontent.com/SimpleIAM/PasswordlessLogin/master/PasswordlessLogin.Migrations/UpgradePasswordlessLogin.SqlServer.sql)

2. Update your connection string as necessary. To do this in Visual Studio, right click on the project, select *Manage User Secrets*, and add something like this to your local secrets file (adjust for your db server and database name)

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PasswordlessDemo;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### Email ###

Download and run [MailHog](https://github.com/mailhog/MailHog/releases/v1.0.0) on your local dev machine, or you can override the SMTP settings in appsettings.Development.json with another mail server in secrets.json. If using MailHog, you can check mail at http://localhost:8025/


### Debugging ###

The authentication system requires certain security cookies that must be set over a secure connection. If running locally under IIS Express and ssl is not enabled, you won't be able to sign in. So either set up SSL in IIS express, or follow the instructions below to use Kestrel.

To use the Kestrel server with SSL, edit launchSettings.json (nested under Properties in the Solution Explorer). Add a Kestrel entry to the profiles section:

```
{
  ...
  "profiles": {
    "IIS Express": {
      ...
    },
    
    "Kestrel": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
    
  }
}
```

Next to the green arrow that launches a new debug session, select the new launch profile instead of IIS Express in order to use Kestrel. The app should be available at https://localhost:5001/

### Exploring the API ###

Some projects have SwaggerUI embedded in the app. You can visit /swagger/ to explore and interact with the API.

### Other Notes ###

If things aren't working, make sure you have these installed:
* The latest version of both [the .NET Core SDK and the .NET Framework](https://www.microsoft.com/net/download)
* The Current (not LTS) version of [Node.js for Windows](https://nodejs.org/en/)

### Deployment in Azure ###

* Make sure the "DefaultConnection" connection string is set
* If targeting an environment other than Production, add an app setting for ASPNETCORE_ENVIRONMENT and set it to "Test" or whichever environment is appropriate.
* Make sure SMTP settings are configured in appsettings.Production.json or in Azure app settings. In Azure keys will be _Mail.From_, _Mail.Smtp.Password_, and so forth.
