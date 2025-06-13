using ControllerEmpleado;
using Models.Empleado;
using MenuLinQ;
using Controller.Utils;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
// ...otros using...
class Program
{
    static void Main(string[] args)
    {
        double Opcion = 0;
        UtilsController Utils = new UtilsController();
        do
        {
            #region Obtención de rutas

            var empleados = EmpleadosController.ObtenerEmpleados(); //Se puede obtener de una bd
            var Rutas = Utils.ObtenerRutas();
            string? rutaMainMenu = Rutas["MainMenu"];
            var rutaMain = Utils.EvaluarDato(rutaMainMenu).ValorString;
            var RutaMainMenu = Path.Combine(Directory.GetCurrentDirectory(), rutaMain);
            #endregion
            #region Comienzo de menu
            Utils.ImprimirTxt(RutaMainMenu);
            Console.Write("Opcion:");
            string? entrada = Console.ReadLine();
            Opcion = Utils.EvaluarDato(entrada).ValorDouble;
            //Tal vez una función con mensajes y un return?
            #endregion
            //Switch para las opciones
            if (Opcion == 0)
            {
                Utils.MostrarMensaje(4); // "Por favor ingrese una opción valida"
                Utils.FinMenu();
                continue;
            }
            switch (Opcion)
            {
                case 1:
                    EmpleadosController.ListarTodo(empleados);
                    break;
                case 2:
                    Console.Write("\nIngrese la cantidad:");
                    string? entradaSalario = Console.ReadLine();
                    var salario = Utils.EvaluarDato(entradaSalario).ValorDouble;
                    EmpleadosController.FltrarXSalario(empleados, salario);
                    break;
                case 3:
                    Console.Write("\nIngrese el puesto:");
                    string? puesto = Console.ReadLine();
                    var Puesto = Utils.EvaluarDato(puesto).ValorString;
                    EmpleadosController.FiltrarXPuesto(empleados, Puesto);
                    break;

                case 4:
                    Console.Write("\nIngrese el nombre del empleado que desea buscar:");
                    string? nombreEmpleado = Console.ReadLine();
                    var NombreEmpleado = Utils.EvaluarDato(nombreEmpleado).ValorString;
                    EmpleadosController.FiltrarXNombre(empleados, NombreEmpleado);
                    break;

                case 5:
                    EmpleadosController.CalcularPromedios(empleados);
                    break;

                case 6:
                    EmpleadosController.MostrarGruposXPuesto(empleados);
                    break;

                case 7:
                    var OrdenarXNombre = EmpleadosController.OrdenarXNombre(empleados);
                    EmpleadosController.ImprimirEmpleadosxLista(OrdenarXNombre);
                    break;

                case 8:
                    var OrdenarXSalario = EmpleadosController.OrdenarXSalario(empleados);
                    EmpleadosController.ImprimirEmpleadosxLista(OrdenarXSalario);
                    break;

                case 9:
                    var OrdenarXN = EmpleadosController.OrdenarXNombreYSalario(empleados);
                    EmpleadosController.ImprimirEmpleadosxLista(OrdenarXN);
                    break;
                //Casos por modificar
                case 10:
                    EmpleadosController.SeleccionarNombreYApellido(empleados);
                    break;
                case 11:
                    EmpleadosController.SumarTodoSalarios(empleados);
                    break;
                //opciones combinadas de linQ
                case 12:
                    Utils.FinMenu(tiempo: 2000);
                    //LinQController.Menu();
                    LinQController.AnalizarOpcion(empleados);
                    break;
                //Salida del programa
                case 13:
                    var departamentos = EmpleadosController.ObtenerDepartamento();
                    EmpleadosController.UnirEmpleadosYDepartamentos(empleados, departamentos);
                    break;

                case 14:
                    Console.WriteLine("Saliendo del programa....");
                    Utils.FinMenu(tiempo: 3000);
                    break;

                default:
                    Utils.MostrarMensaje(4);
                    break;
            }
            Utils.FinMenu();

        }
        while (Opcion != 14);
    }
}