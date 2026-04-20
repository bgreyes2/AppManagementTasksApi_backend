# Prueba Técnica Fullstack - Backend API

Este proyecto corresponde al backend de una aplicación de gestión de tareas desarrollada en:

- .NET Web API
- SQL Server

---

## 🎯 Objetivo

Proveer una API REST para la gestión de usuarios y tareas, permitiendo:

- Crear y listar usuarios
- Crear y listar tareas
- Asignar tareas a usuarios
- Gestionar el estado de las tareas
- Aplicar reglas de negocio definidas

---

## 🧱 Arquitectura del proyecto

El proyecto está organizado en una arquitectura en capas:


/Controllers -> Endpoints de la API
/Services -> Lógica de negocio
/Repositories -> Acceso a datos
/Models -> Entidades
/DTOs -> Objetos de transferencia de datos
/Data -> DbContext
/Database -> Scripts de base de datos


---

## ⚙️ Configuración del proyecto

Antes de ejecutar el backend, es necesario configurar la conexión a la base de datos en el archivo:


appsettings.json


### Configuración requerida:

```json id="n7v2kp"
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ConnectionStrings": {
    "DefaultConnections": "Server=LAPTOP-ESVUNNQO\\BUHOSQL2019; User Id=sa; Database=AppManagementTasks; Password=123456"
  }
}

⚠️ Importante:

Debes configurar correctamente el Server, User Id y Password según tu entorno local.
Sin esta configuración la API no podrá conectarse a la base de datos.
🗄️ Base de datos

Dentro del proyecto existe una carpeta llamada:

/Database
``` id="q1z9hh"

Allí se encuentran los scripts necesarios para la creación de la base de datos.
SQL 2019

### Orden de ejecución:

1. Primero ejecutar el script de creación de **Tasks**
2. Luego ejecutar el script de creación de **Users**

⚠️ Es importante respetar este orden para evitar errores de relación de claves foráneas.

---

## 🧾 Reglas de negocio implementadas

- El título de la tarea es obligatorio
- Toda tarea debe estar asignada a un usuario
- Estados válidos:
  - Pending
  - InProgress
  - Done
- No se permite transición directa de:
  - `Pending → Done`

---

## 🔌 Endpoints principales

### Usuarios


POST /api/users
GET /api/users


### Tareas


POST /api/tasks
GET /api/tasks
PUT /api/tasks/{id}/status


---

## ⚙️ Características del backend

- Arquitectura en capas
- Uso de DTOs
- Validaciones en backend
- Separación de responsabilidades
- Manejo básico de errores
- API REST con verbos HTTP correctos

---

## 🚀 Ejecución del proyecto

```bash id="v6kq8m"
dotnet restore
dotnet run
📌 Notas importantes
La conexión a base de datos debe configurarse manualmente en appsettings.json
La base de datos debe crearse ejecutando los scripts dentro de /Database
El orden correcto de creación es obligatorio (Tasks → Users)
👨‍💻 Autor

Brayan Reyes
Proyecto desarrollado como prueba técnica Fullstack (.NET + Angular + SQL Server)
