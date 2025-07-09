This is a full-stack web application using **Angular 20.0** for the frontend and **.NET 8** for the backend API.

---

## 🛠 Technologies Used

### Frontend
- [Angular 20.0](https://angular.io/)
- [primeng@20.0.0-rc.1](https://primeng.org/)
  

### Backend
- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core

---
### Prerequisites

- Node.js
- Angular cli
- .NET 8 SDK
- NSwag.ConsoleCore
- Visual Studio 2022+ and VS Code

  
## 📁 Project Structure

This solution follows the principles of Clean Architecture, organizing code into concentric layers:

```
┌─────────────────────────────────────────────────────────────┐
│ LaundryManager.Client (Angular 20)                           │
│   └─→ Communicates with LaundryManager.API                   │
└─────────────────────────────────────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────────────────────────┐
│ LaundryManager.API (.NET 8 ASP.NET Core Web API)             │
│   ├─→ Handles HTTP requests                                  │
│   └─→ Routes calls to LaundryManager.Application             │
└─────────────────────────────────────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────────────────────────┐
│ LaundryManager.Application                                   │
│   ├─→ Contains business rules                                │
│   └─→ Defines DTOs for data transfer                         │
└─────────────────────────────────────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────────────────────────┐
│ LaundryManager.Domain                                         │
│   └─→ entities , interfaces (Core business rules)             │
└─────────────────────────────────────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────────────────────────┐
│ LaundryManager.Infrastructure                                │
│   └─→ Implements data access (EF Core), repositories,        │
│       and 3rd-party integrations
|         (Technical implementations (e.g. DbContext) )         │
└─────────────────────────────────────────────────────────────┘
```






