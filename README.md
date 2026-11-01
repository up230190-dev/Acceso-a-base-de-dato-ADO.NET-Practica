# Productos API (.NET 10 + MySQL)

CRUD básico de productos que implementa `IProductoRepository` y se prueba con Swagger.

| Punto | Dónde | Endpoint |
|---|---|---|
| Conexión | `Data/Conexion.cs` | — |
| Consultas | `ObtenerTodos`, `ObtenerPorId` | `GET /api/productos`, `GET /api/productos/{id}` |
| Insert | `Insertar` | `POST /api/productos` |
| Actualizar | `Actualizar` | `PUT /api/productos/{id}` |
| Eliminar | `Eliminar` | `DELETE /api/productos/{id}` |
| Buscar | `Buscar` | `GET /api/productos/buscar?nombre=` |

## Cómo ejecutar

1. Crear la base de datos con `database/productos_db.sql`:

   ```bash
   mysql -u root -p < database/productos_db.sql
   ```

2. Ajustar usuario y contraseña en `ProductosApi/appsettings.json`.

3. Ejecutar:

   ```bash
   dotnet run --project ProductosApi
   ```

4. Abrir Swagger: http://localhost:5000/swagger
