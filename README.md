# File Upload

## System Requirement
- Angular/Cli version 17.2.3
- .Net 8
- Node version 20

## How to run 
### Back-End
1. Change configuration value in ***appsettings.json***
```jsonc
{
  "DestinationPath": "[...your destination path...]",
    "MailSettings": {
      "Server": "[... your server...]",
      "Port": "[...your port (number)...]",
      "SenderName": "[...sender name...]",
      "SenderEmail": "[...sender email...]",
      "UserName": "[...username...]",
      "Password": "[...password...]"
    }
}
```
2. Ensure URL in "WithOrigin" in ***Program.cs***  matches your web URL.
```cs
 options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
```

3. Run
```cs
  dotnet run --project FileUpload.API
```

### Front End
1. Install
```node
  npm install
```
2. Ensure the URL in ***environment/environment.ts*** matches your API Endpoint
```ts
export const environment = {
  production: true,
  apiUrl: 'http://localhost:5166/api/',
};

```
3. Run the project
```node
ng serve
```
