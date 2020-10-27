# Merta Backend Api Project





## Appsetting.json Example

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "",
      "Microsoft": "",
      "Microsoft.Hosting.Lifetime": ""
    }
  },
  "AllowedHosts": "Hosts",
  "ConnectionStrings": {
    "NpgSql": "PostgreSql Connection String"
  }
```

## Property/launchSettings Example

```json
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:56746",
      "sslPort": "SSL PORT"
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "project",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "BackendApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "project",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
```
