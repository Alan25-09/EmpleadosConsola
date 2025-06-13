using System.Reflection.Metadata;
using ControllerEmpleado;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
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
            EmpleadosController.ImprimirEmpleadosxLista(lista);
            Pausa(tiempo: tiempo);
        }
    }
    //creación de función lectora de txt
    public void ImprimirTxt(string ruta)
    {
        if (!File.Exists(ruta))
        {
            MostrarMensaje(1);
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
    private readonly Dictionary<int, string> _mensajes = new Dictionary<int, string>
    {
        {1, "Error, el archivo o ruta no existe"},
        {2, "No se admiten valores nulos"},
        {3, "Formato incorrecto"},
        {4, "Por favor ingrese una opción valida"}
    };

    public void MostrarMensaje(int tipoDeMensaje = 0)
    {
        if (_mensajes.TryGetValue(tipoDeMensaje, out string? mensaje))
        {
            Console.WriteLine(mensaje);
        }
        else
        {
            Console.WriteLine("Mensaje no definido"); // Opcional: manejo de errores
        }
    }
    // ...existing code...
    public (double ValorDouble, string ValorString) EvaluarDato(string? Dato)
    {
        if (string.IsNullOrEmpty(Dato))
        {
            MostrarMensaje(2);
            return (0, string.Empty);
        }

        // Check if Dato contains any digit
        if (Dato.Any(char.IsDigit))
        {
            if (double.TryParse(Dato, out double DatoParseadoDouble))
            {
                return (DatoParseadoDouble, string.Empty);
            }
            else
            {
                MostrarMensaje(3); // Formato incorrecto
                return (0, string.Empty);
            }
        }
        else
        {
            // No digits found, treat as string
            return (0, Dato);
        }
    }

}
