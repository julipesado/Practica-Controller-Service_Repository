# ABM Productos - Web API con base de datos

API REST en ASP.NET Core (.NET 10) para dar de alta, baja, modificar y consultar productos.
Usa arquitectura en capas (Controller - Service - Repository) y guarda los datos en una base **SQLite** con **Entity Framework Core**.

## Estructura

- `Controllers/` → endpoints de la API
- `Services/` → lógica de negocio (validaciones, nombre duplicado, estadísticas)
- `Repositories/` → acceso a datos con EF Core
- `Data/ApplicationContext.cs` → DbContext, configuración de la entidad y datos iniciales (seed)
- `Entities/` → entidad `Product`
- `Models/DTOs/` → DTOs de entrada y salida
- `Migrations/` → migraciones de EF Core

## Cómo correr el proyecto

1. Clonar el repositorio y abrir `WebApplication1/WebApplication1.slnx` en Visual Studio.
2. Restaurar los paquetes NuGet (Visual Studio lo hace solo al compilar).
3. Crear la base de datos aplicando las migraciones. En **Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes**:

   ```
   Update-Database
   ```

   O desde una terminal, parados en la carpeta del proyecto:

   ```
   dotnet ef database update
   ```

   Esto crea el archivo `Products.db` con la tabla `Products` y 10 productos de ejemplo.
4. Ejecutar el proyecto (F5) y entrar a Swagger: `https://localhost:<puerto>/swagger`

La cadena de conexión está en `appsettings.json` (`ConnectionStrings:ProductsDBConnectionString`).

## Endpoints

| Método | Ruta | Descripción |
|---|---|---|
| GET | `/api/products` | Lista todos los productos |
| GET | `/api/products/{id}` | Trae un producto por Id (404 si no existe) |
| POST | `/api/products` | Crea un producto (409 si el nombre ya existe) |
| PUT | `/api/products/{id}` | Modifica un producto (404 si no existe) |
| DELETE | `/api/products/{id}` | Elimina un producto (404 si no existe) |
| GET | `/api/products/search?name=texto` | Busca productos por nombre |
| GET | `/api/products/stats` | Total, precio promedio y producto más caro |

Ejemplo de body para POST / PUT:

```json
{
  "name": "Parlante Bluetooth",
  "price": 25999.99
}
```
