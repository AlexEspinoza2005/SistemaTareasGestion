# 📋 TaskFlow — Enterprise Project & Task Management Solution

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![REST API](https://img.shields.io/badge/REST-Web_API-green?style=for-the-badge)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-blue.svg?style=for-the-badge)

<p align="center">
  <strong>Multi-tier enterprise workflow system built with ASP.NET Core. Features decoupled RESTful Web API services, reactive MVC administrative portal, programmatic HTTP consumer integration, and relational task tracking across projects, teams, and priority states.</strong>
</p>

</div>

---

## 📋 System Overview

**TaskFlow (SistemaTareasGestion)** is an enterprise task tracking and project workflow solution designed to coordinate cross-functional software teams. The solution implements a decoupled 3-tier architecture:
1. **Core Web API (`GestionTareas.API`)**: Exposes RESTful endpoints for projects, tasks, and users with HTTP payload validation and status code contracts.
2. **Web Portal (`GestionTareas.MVC`)**: User-friendly responsive dashboard for project managers and developers to organize sprint backlogs, assign deadlines, and update progress states.
3. **API Consumer (`GestionTareas.API.Consumer`)**: Demonstrates robust consumption of the REST API via asynchronous C# `HttpClient` workflows.

---

## 🏛️ System Architecture

```
 ┌─────────────────────────────────────────────────────────────┐
 │                     User Interfaces                         │
 │ ┌─────────────────────────┐   ┌───────────────────────────┐ │
 │ │ ASP.NET Core MVC Portal │   │ Programmatic API Consumer │ │
 │ └────────────┬────────────┘   └─────────────┬─────────────┘ │
 └──────────────┼──────────────────────────────┼───────────────┘
                │ HTTP / REST                  │ Asynchronous HTTP
                ▼                              ▼
 ┌─────────────────────────────────────────────────────────────┐
 │                  GestionTareas.API (.NET 8)                 │
 │ ┌─────────────────────────────────────────────────────────┐ │
 │ │ Controllers: Proyectos, Tareas, Usuarios                │ │
 │ ├─────────────────────────────────────────────────────────┤ │
 │ │ Entity Models & Relational Data Validation              │ │
 │ ├─────────────────────────────────────────────────────────┤ │
 │ │ Persistence Context (SQL Relational Mapping)            │ │
 │ └────────────────────────────┬────────────────────────────┘ │
 └──────────────────────────────┼──────────────────────────────┘
                                │ ADO.NET / Relational Engine
                                ▼
 ┌─────────────────────────────────────────────────────────────┐
 │                     Relational Database                     │
 └─────────────────────────────────────────────────────────────┘
```

---

## 🧩 Modules & Capabilities

- **Project Tracking (`ProyectosController`)**: Create, inspect, edit, and close projects with target milestones, budget hours, and delivery timelines.
- **Task Orchestration (`TareasController`)**: Assign granular tasks to team members, set priority levels (High, Medium, Low), manage execution states (Pending, In Progress, Completed), and monitor deadlines.
- **Team Management (`UsuariosController`)**: Maintain user directories, roles, contact metadata, and active task workloads.
- **Consumer Harness (`GestionTareas.API.Consumer`)**: Automated verification scripts executing CRUD operations via standard HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`).

---

## 🛠️ Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or VS Code

### Installation & Run

1. **Clone the repository**:
   ```bash
   git clone https://github.com/AlexEspinoza2005/SistemaTareasGestion.git
   cd SistemaTareasGestion/GestionTareas
   ```

2. **Run the Backend API**:
   ```bash
   dotnet run --project GestionTareas.API
   ```
   Interactive Swagger documentation will be available at: `https://localhost:7080/swagger`

3. **Run the MVC Web Portal**:
   ```bash
   dotnet run --project GestionTareas.MVC
   ```
   Navigate to `https://localhost:7198` to access the web application.

---

## 👨‍💻 Author

**Alex Espinoza**  
- GitHub: [@AlexEspinoza2005](https://github.com/AlexEspinoza2005)  
- Email: [alexespinozacangas2018@gmail.com](mailto:alexespinozacangas2018@gmail.com)  
- Education: Software Engineering Student — Universidad Técnica del Norte (UTN, Ibarra - Ecuador)
