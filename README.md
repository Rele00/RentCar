# Documentación y estructura — **Rent Car (Blazor + EF Core + Identity)**

Este documento describe la arquitectura y estructura actual del proyecto **Rent Car**, desarrollado con **Blazor Server**, **Entity Framework Core** (.NET 8) e integración de **ASP.NET Identity**. Incluye la estructura real de archivos, ejemplos de entidades, configuración de `DbContext`, servicios, y buenas prácticas.

---

## Tabla de contenidos
1. Objetivo
2. Estructura de archivos y carpetas actual
3. Entidades principales (modelos)
4. DbContext y configuración EF Core
5. Servicios y patrón Repository
6. Integración con Blazor Server
7. Seguridad e Identity
8. Migraciones y pruebas
9. Buenas prácticas

---

## 1. Objetivo

- Modelar el dominio de un sistema de alquiler de vehículos (vehículos, clientes, usuarios, categorías, tipos de vehículo).
- Persistir datos con EF Core y SQL Server.
- Integrar autenticación y autorización con ASP.NET Identity.
- Consumir servicios y datos desde componentes Blazor Server.
- Mantener una arquitectura limpia y escalable.

---

## 2. Estructura de archivos y carpetas actual

```
-- 📁 Estructura del proyecto RentCar

RentCar/
│
├── Data/                                  -- Capa de acceso a datos
│   │
│   ├── Context/                           -- Contextos de base de datos y configuración de Identity
│   │   ├── ApplicationDbContext.cs        -- Contexto principal de Entity Framework Core
│   │   └── ApplicationUser.cs             -- Clase personalizada para Identity (extiende IdentityUser)
│   │
│   ├── Models/                            -- Entidades del dominio (tablas del sistema)
│   │   ├── Categoria.cs                   -- Define las categorías de vehículos
│   │   ├── Cliente.cs                     -- Representa los datos de los clientes
│   │   ├── TipoVehiculo.cs                -- Define los tipos de vehículos (SUV, Sedan, etc.)
│   │   ├── Usuario.cs                     -- Representa a los empleados/usuarios internos
│   │   └── Vehiculo.cs                    -- Entidad principal que gestiona los vehículos
│   │
│   └── Services/                          -- Servicios o lógica de negocio
│       ├── IVehiculoService.cs            -- Interfaz para servicio de vehículos
│       ├── IClienteService.cs             -- Interfaz para servicio de clientes
│       ├── IUsuarioService.cs             -- Interfaz para servicio de usuarios
│       ├── VehiculoService.cs             -- Servicio para manejar operaciones de vehículos
│       ├── ClienteService.cs              -- Servicio para manejar operaciones de clientes
│       └── UsuarioService.cs              -- Servicio para manejar operaciones de usuarios
│
├── Web/                                   -- Capa de interfaz de usuario (Blazor)
│   ├── Components/                        -- Componentes reutilizables
│   │   ├── _Imports.razor                 -- Importaciones globales de Razor
│   │   ├── App.razor                      -- Componente raíz de la aplicación
│   │   ├── Routes.razor                   -- Define las rutas de navegación
│   │   │
│   │   ├── Pages/                         -- Páginas principales del sistema
│   │   │   └── Auth.razor                 -- Página de autenticación/login
│   │   │
│   │   ├── Account/                       -- Sección de cuentas (login, registro, perfil)
│   │   │
│   │   └── Layout/                        -- Plantillas de diseño (navbar, sidebar, etc.)
│
├── Program.cs                             -- Punto de entrada de la aplicación (configuración principal)
├── appsettings.json                       -- Archivo de configuración (cadena de conexión, entorno, etc.)
├── Comentarios.md                         -- Notas o documentación adicional del proyecto
└── README.md                              -- Documentación principal del proyecto



```

---

## 3. Entidades principales (modelos)
Ejemplos de entidades del dominio, como `Vehiculo`, `Cliente`, `Reserva`, con sus propiedades y relaciones.

---

## 4. DbContext y configuración EF Core
Configuración de `DbContext` usando Fluent API, definición de DbSets para las entidades principales y configuración de la cadena de conexión a la base de datos.

---

## 5. Servicios y patrón Repository
Definición de interfaces y clases para los repositorios y servicios, incluyendo `IVehiculoRepository`, `IClienteService`, etc. Implementación del patrón Unit of Work opcional.

---

## 6. Integración con Blazor Server

- Los servicios se inyectan en los componentes Blazor.
- Consumo de APIs de la aplicación a través de `HttpClient` y servicios personalizados.
- Manejo del estado de la aplicación utilizando `CascadingAuthenticationState` y `AuthorizeView`.

---

## 7. Seguridad e Identity

- Configuración de **ASP.NET Identity** para gestión de usuarios y roles en `Program.cs`.
- Páginas y componentes Blazor para registro, inicio de sesión y gestión de usuarios.
- Políticas de autorización y autenticación basadas en roles y requisitos personalizados.

---

## 8. Migraciones y pruebas

- Uso de `dotnet ef migrations` para gestionar cambios en el modelo de datos.
- Pruebas automatizadas con pruebas unitarias y de integración, usando una base de datos en memoria para pruebas.

---

## 9. Buenas prácticas

- Separación clara entre las capas de presentación, aplicación y acceso a datos.
- Uso de DTOs y AutoMapper para la transferencia de datos entre capas.
- Validación de datos en el servidor y cliente.
- Documentación del código y uso de comentarios claros y concisos.

---

## Conclusión

Esta documentación proporciona una visión general de la arquitectura y estructura del proyecto **Rent Car**, sirviendo como guía para el desarrollo, integración y mantenimiento del sistema.
