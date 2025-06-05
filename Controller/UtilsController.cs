using System.Reflection.Metadata;
using ControllerEmpleado;
using Microsoft.Extensions.Configuration;
using Models.Empleado;
namespace Controller.Utils;

public class UtilsController
{
    private static void SaltosDlinea()
    {
        Console.WriteLine("\n\n\n\n");
    }
    private static void Pausa(string mensaje = "Presione cualquier tecla para continuar...", int tiempo = 0)
    {
        if (tiempo > 0)
        {
            Thread.Sleep(tiempo);
        }
        else
        {
            Console.WriteLine(mensaje);
            Console.ReadKey();
        }
    }

    public void FinMenu(List<Empleado>? lista = null, int tiempo = 0)
    {
        if (lista == null)
        {
            Pausa(tiempo: tiempo);
            Console.Clear();
            return;
        }
        else
        {
            Console.Clear();
            empleadosController.ImprimirEmpleadosxLista(lista);
            Pausa(tiempo: tiempo);
        }
    }
    //creación de función lectora de txt
    public void ImprimirTxt(string ruta)
    {
        if (!File.Exists(ruta))
        {
            Console.WriteLine("Error, el archivo no existe");
        }
        else
        {
            string contenido = File.ReadAllText(ruta);
            Console.WriteLine(contenido);
        }
    }
    public Dictionary<string, string?> ObtenerRutas()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var rutas = new Dictionary<string, string?>
        {
            { "MainMenu", config["AppPaths:MainMenu"] },
            { "SecondMenu", config["AppPaths:SecondMenu"] }
        };

        return rutas;
    }

}
