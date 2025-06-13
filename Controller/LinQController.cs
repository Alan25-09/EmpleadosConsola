using Models.Empleado;
using ControllerEmpleado;
using Controller.Utils;
using Microsoft.VisualBasic;

namespace MenuLinQ;

public class LinQController
{
    private static UtilsController Utils = new UtilsController();

    public static void Menu()
    {
        var rutas = Utils.ObtenerRutas();
        string? rutaMenu = rutas["SecondMenu"];
        if (string.IsNullOrEmpty(rutaMenu))
        {
            Console.WriteLine("Ruta nula o vacia");
            return;
        }
        string? RutaMenu = Path.Combine(Directory.GetCurrentDirectory(), rutaMenu);
        Utils.ImprimirTxt(RutaMenu);
    }
    public static void AnalizarOpcion( List<Empleado> empleados)
    {
        double Opcion=0;
        do
        {
            Menu();
            Console.Write("opcion: ");
            string? entrada = Console.ReadLine();
            Opcion = Utils.EvaluarDato(entrada).ValorDouble;
                if (Opcion == 0)
            {
                Utils.MostrarMensaje(4); // "Por favor ingrese una opción valida"
                Utils.FinMenu();
                continue;
            }
            switch ((int)Opcion)
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
                    EmpleadosController.FiltrarPorSalarioYPuesto(empleados, salario, puesto);
                    Utils.FinMenu();
                    break;
                case 2:
                    EmpleadosController.AgruparPorPuestoYMostrarSalario(empleados);
                    Utils.FinMenu();
                    break;
                case 3:
                    Console.Write("Ingrese la subcadena");
                    string? subcadena = Console.ReadLine();
                    if (string.IsNullOrEmpty(subcadena))
                    {
                        Console.WriteLine("No se admiten valores nulos");
                        return;
                    }
                    EmpleadosController.BuscarPorSubcadena(empleados, subcadena);
                    Utils.FinMenu();
                    break;
                case 4:
                    EmpleadosController.SeleccionarPorPuestoYPorSalario(empleados);
                    Utils.FinMenu();
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
        } while (Opcion!=6);

    }
}
