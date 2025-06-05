using ControllerEmpleado;
using Models.Empleado;
using MenuLinQ;
using Controller.Utils;
using Microsoft.Extensions.Configuration;
// ...otros using...
class Program
{
    static void Main(string[] args)
    {
        UtilsController utils = new UtilsController();
        int opcion;
        do
        {
            var empleados = ControllerEmpleado.empleadosController.ObtenerEmpleados();
            var Rutas = utils.ObtenerRutas();
            string? rutaMainMenu = Rutas["MainMenu"];
            if (string.IsNullOrEmpty(rutaMainMenu))
            {
                Console.WriteLine("Ruta nula o vacia");
                return;
            }
            var RutaMainMenu = Path.Combine(Directory.GetCurrentDirectory() ,rutaMainMenu);
            utils.ImprimirTxt(RutaMainMenu);
            Console.Write("Opcion:");
            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Por favor, ingresa una opción válida.");
                return;
            }

            //Switch para las opciones
            switch (opcion)
            {
                case 1:
                    ControllerEmpleado.empleadosController.ListarTodo(empleados);
                    utils.FinMenu();
                    break;
                case 2:
                    Console.WriteLine("\nIngrese la cantidad a filtrar:");
                    string? entradaSalario = Console.ReadLine();
                    double salario;
                    if (!double.TryParse(entradaSalario, out salario))
                    {
                        Console.WriteLine("Ingrese un monto valido");
                        return;
                    }
                    ControllerEmpleado.empleadosController.FltrarXSalario(empleados, salario);
                    utils.FinMenu();
                    break;
                case 3:
                    Console.WriteLine("\nIngrese el puesto el cual filtrara la lista:");
                    string? entradaPuesto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(entradaPuesto))
                    {
                        Console.WriteLine("Debe ingresar un puesto válido.");
                        return;
                    }
                    ControllerEmpleado.empleadosController.FiltrarXPuesto(empleados, entradaPuesto);
                    utils.FinMenu();
                    break;

                case 4:
                    Console.WriteLine("\nIngrese el nombre del empleado que desea buscar:");
                    string? NombreEmpleado = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(NombreEmpleado))
                    {
                        Console.WriteLine("Ingrese un nombre valido");
                        return;
                    }
                    ControllerEmpleado.empleadosController.FiltrarXNombre(empleados, NombreEmpleado);
                    utils.FinMenu();
                    break;

                case 5:
                    ControllerEmpleado.empleadosController.CalcularPromedios(empleados);
                    utils.FinMenu();
                    break;

                case 6:
                    ControllerEmpleado.empleadosController.MostrarGruposXPuesto(empleados);
                    utils.FinMenu();
                    break;

                case 7:
                    var OrdenarXNombre = ControllerEmpleado.empleadosController.OrdenarXNombre(empleados);
                    empleadosController.ImprimirEmpleadosxLista(OrdenarXNombre);
                    utils.FinMenu();
                    break;

                case 8:
                    var OrdenarXSalario = ControllerEmpleado.empleadosController.OrdenarXSalario(empleados);
                    empleadosController.ImprimirEmpleadosxLista(OrdenarXSalario);
                    utils.FinMenu();
                    break;

                case 9:
                    var OrdenarXN = ControllerEmpleado.empleadosController.OrdenarXNombreYSalario(empleados);
                    empleadosController.ImprimirEmpleadosxLista(OrdenarXN);
                    utils.FinMenu();
                    break;
                //Casos por modificar
                case 10:
                    empleadosController.SeleccionarNombreYApellido(empleados);
                    utils.FinMenu();
                    break;
                case 11:
                    empleadosController.SumarTodoSalarios(empleados);
                    utils.FinMenu();
                    break;
                //opciones combinadas de linQ
                case 12:
                    utils.FinMenu(tiempo: 2000);
                    //LinQController.Menu();
                    LinQController.AnalizarOpcion(empleados);
                    utils.FinMenu();
                    break;
                //Salida del programa
                case 13:
                    var departamentos= empleadosController.ObtenerDepartamento();
                    empleadosController.UnirEmpleadosYDepartamentos(empleados, departamentos);
                    utils.FinMenu();
                    break;

                case 14:
                    Console.WriteLine("Saliendo del programa....");
                    utils.FinMenu(tiempo: 3000);
                    break;

                default:
                    Console.WriteLine("Ingrese una opción valida");
                    utils.FinMenu();
                    break;
            }
        }
        while (opcion != 14);
    }
}