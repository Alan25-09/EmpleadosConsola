using Models.Empleado;
using ControllerEmpleado;
using Controller.Utils;
using Microsoft.VisualBasic;

namespace MenuLinQ;

public class LinQController
{
    private static UtilsController utils = new UtilsController();

    public static void Menu()
    {
        var rutas = utils.ObtenerRutas();
        string? rutaMenu = rutas["SecondMenu"];
        if (string.IsNullOrEmpty(rutaMenu))
        {
            Console.WriteLine("Ruta nula o vacia");
            return;
        }
        string? RutaMenu = Path.Combine(Directory.GetCurrentDirectory(), rutaMenu);
        utils.ImprimirTxt(RutaMenu);
    }
    public static void AnalizarOpcion( List<Empleado> empleados)
    {
        do
        {
            Menu();
            Console.Write("opcion: ");
            string? entrada = Console.ReadLine();
            int opcion;
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Seleccione una opción valida, no puede ser nula");
            }
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el salario y el puesto");
                    Console.Write("Salario: ");
                    string? EntradaSalario = Console.ReadLine();
                    double salario;
                    if (!double.TryParse(EntradaSalario, out salario))
                    {
                        Console.WriteLine("Ingrese un valor valido");
                        return;
                    }
                    Console.Write("Puesto: ");
                    string? puesto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(puesto))
                    {
                        Console.WriteLine("El puesto no puede ser nulo");
                        return;
                    }
                    empleadosController.FiltrarPorSalarioYPuesto(empleados, salario, puesto);
                    utils.FinMenu();
                    break;
                case 2:
                    empleadosController.AgruparPorPuestoYMostrarSalario(empleados);
                    utils.FinMenu();
                    break;
                case 3:
                    Console.Write("Ingrese la subcadena");
                    string? subcadena = Console.ReadLine();
                    if (string.IsNullOrEmpty(subcadena))
                    {
                        Console.WriteLine("No se admiten valores nulos");
                        return;
                    }
                    empleadosController.BuscarPorSubcadena(empleados, subcadena);
                    utils.FinMenu();
                    break;
                case 4:
                    empleadosController.SeleccionarPorPuestoYPorSalario(empleados);
                    utils.FinMenu();
                    break;
                case 5:
                    return;
                case 6:
                    Console.WriteLine("Saliendo del programa.....");
                    Environment.Exit(0);
                    return;

                default:
                    break;
            }
            } while (true);

    }
}
