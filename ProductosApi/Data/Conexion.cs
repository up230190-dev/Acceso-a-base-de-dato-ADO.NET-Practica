using MySqlConnector;

namespace ProductosApi.Data;

// Conexión a MySQL usando la cadena de appsettings.json
public class Conexion
{
    private readonly string _cadena;

    public Conexion(IConfiguration configuration)
    {
        _cadena = configuration.GetConnectionString("MySql")!;
    }

    public MySqlConnection Abrir()
    {
        var conexion = new MySqlConnection(_cadena);
        conexion.Open();
        return conexion;
    }
}
