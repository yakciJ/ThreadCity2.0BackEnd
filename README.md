# Thread City 2.0 BackEnd
# Thread City 2.0 Frontend: 
https://github.com/nguyenhbtrung/thread-city-2.0-frontend

## Setup

### 1. Add appsettings.json
Create a file **appsettings.json** in the project root directory.

### 2. Add the following content to the appsettings.json
```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultSQLConnection": "Server=Your-Server;Database=ThreadCity2.0;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
    },
    "JWT": {
        "Issuer": "https://localhost:7135",
        "Audience": "https://localhost:7135",
        "SigningKey": "Your-Key"
    }
}
```

### 3. Customize the "DefaultSQLConnection", "SigningKey" configurations


