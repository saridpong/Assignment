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
      "Port": "[...your port (number)...]", ex. Port: 587
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
***Output***
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5166
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
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
***Output***
```
Application bundle generation complete. [1.916 seconds]
Watch mode enabled. Watching for file changes...
  ➜  Local:   http://localhost:4200/
  ➜  press h + enter to show help
```
<img width="367" alt="Screenshot 2567-03-15 at 10 43 41" src="https://github.com/saridpong/Assignment/assets/1690456/3d028274-0f76-49de-9745-5ff4f7467191">

