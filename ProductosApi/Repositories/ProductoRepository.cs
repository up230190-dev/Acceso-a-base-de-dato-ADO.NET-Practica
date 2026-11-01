using MySqlConnector;
using ProductosApi.Data;
using ProductosApi.Models;

namespace ProductosApi.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly Conexion _conexion;

    public ProductoRepository(Conexion conexion)
    {
        _conexion = conexion;
    }

    // Consultas
    public List<Producto> ObtenerTodos()
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand("SELECT id, nombre, precio, stock FROM productos", cn);
        return Leer(cmd);
    }

    public Producto? ObtenerPorId(int id)
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand("SELECT id, nombre, precio, stock FROM productos WHERE id = @id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        return Leer(cmd).FirstOrDefault();
    }

    // Insert
    public int Insertar(Producto producto)
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand(
            "INSERT INTO productos (nombre, precio, stock) VALUES (@nombre, @precio, @stock); SELECT LAST_INSERT_ID();", cn);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@precio", producto.Precio);
        cmd.Parameters.AddWithValue("@stock", producto.Stock);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    // Actualizar
    public bool Actualizar(Producto producto)
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand(
            "UPDATE productos SET nombre = @nombre, precio = @precio, stock = @stock WHERE id = @id", cn);
        cmd.Parameters.AddWithValue("@id", producto.Id);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@precio", producto.Precio);
        cmd.Parameters.AddWithValue("@stock", producto.Stock);
        return cmd.ExecuteNonQuery() > 0;
    }

    // Eliminar
    public bool Eliminar(int id)
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand("DELETE FROM productos WHERE id = @id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery() > 0;
    }

    // Buscar por nombre
    public List<Producto> Buscar(string nombre)
    {
        using var cn = _conexion.Abrir();
        var cmd = new MySqlCommand("SELECT id, nombre, precio, stock FROM productos WHERE nombre LIKE @nombre", cn);
        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
        return Leer(cmd);
    }

    private static List<Producto> Leer(MySqlCommand cmd)
    {
        var lista = new List<Producto>();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Producto
            {
                Id = reader.GetInt32("id"),
                Nombre = reader.GetString("nombre"),
                Precio = reader.GetDecimal("precio"),
                Stock = reader.GetInt32("stock")
            });
        }
        return lista;
    }
}
