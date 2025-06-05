using EmpleadosApp;
using Models.Empleado;

namespace ControllerEmpleado
{
    public class empleadosController
    {
        public static List<Departamento> ObtenerDepartamento()
        {
            List<Departamento> departamentos = new List<Departamento>
            {
                new Departamento { Id = 1, Nombre = "Desarrollo" },
                new Departamento { Id = 2, Nombre = "Diseño" },
                new Departamento { Id = 3, Nombre = "Gerencia" }
            };
            return departamentos;
        }

        //Creamos la Base de datos o lista
        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>
            {
                new Empleado{Nombre="Juan",Apellido="Pérez",Puesto="Dev",Salario=20000, DepartamentoId=1},
                new Empleado{Nombre="Alan",Apellido="Flores",Puesto="Dev",Salario=25000,DepartamentoId=1},
                new Empleado{Nombre="David",Apellido="Juarez",Puesto="Dev",Salario=13000,DepartamentoId=1},
                new Empleado{Nombre="Angela",Apellido="Hernandéz",Puesto="Dev",Salario=3000,DepartamentoId=1},
                new Empleado{Nombre="Ana",Apellido="Gómez",Puesto="Diseñadora",Salario=3500, DepartamentoId=2},
                new Empleado{Nombre="Luis",Apellido="Martínez",Puesto="Gerente",Salario=1200, DepartamentoId=1}
            };
            return empleados;

        }



        //Creamos las funciones que nos ayudaran a filtrar

        //Listar todos
        public static void ListarTodo(List<Empleado> empleados)
        {
            ImprimirEmpleadosxLista(empleados);
        }
        //Filtrar por salario
        public static void FltrarXSalario(List<Empleado> empleados, double salario)
        {
            var EmpleadosXSalario = empleados.Where(q => q.Salario >= salario).ToList();
            ImprimirEmpleadosxLista(EmpleadosXSalario);
        }

        //Filtrar por puesto
        public static void FiltrarXPuesto(List<Empleado> empleados, string puesto)
        {
            var EmpleadosXPuesto = empleados.Where(q => q.Puesto == puesto).ToList();
            ImprimirEmpleadosxLista(EmpleadosXPuesto);
        }
        //Filtrar por nombre
        public static void FiltrarXNombre(List<Empleado> empleados, string nombre)
        {
            var EmpleadoXNombre = empleados.Where(q => q.Nombre == nombre).ToList();
            ImprimirEmpleadosxLista(EmpleadoXNombre);
        }
        //Calcular los promedios salariales

        public static void CalcularPromedios(List<Empleado> empleados)
        {
            //Evitamos todo esto con la clausula de LinQ
            // double suma = 0;
            // int divisor = 0;
            // foreach (var item in empleados)
            // {
            //     divisor++;
            //     suma += item.Salario;
            // }

            // var promedio = suma / divisor;
            // Console.WriteLine($"El promedio de salarios es: {promedio}");

            var promedioLinQ = empleados.Average(q => q.Salario);
            Console.WriteLine($"El promedio de salarios es: {promedioLinQ}");
        }

        public static void MostrarGruposXPuesto(List<Empleado> empleados)
        {
            var GruposXPuesto = empleados.GroupBy(q => q.Puesto);
            foreach (var grupo in GruposXPuesto)
            {
                Console.WriteLine($"\nPuesto: {grupo.Key}\n");

                foreach (var empleado in grupo)
                {
                    Console.WriteLine($"Empleado: {empleado.Nombre} {empleado.Apellido}");
                }

            }
        }

        private static void ImprimirEmpleados(Empleado item)
        {
            Console.WriteLine($"Nombre:{item.Nombre} | Apellido: {item.Apellido}| Puesto:{item.Puesto}| Salario: {item.Salario}");
        }
        public static void ImprimirEmpleadosxLista(List<Empleado> empleados)
        {
            foreach (var item in empleados)
            {
                ImprimirEmpleados(item);
            }

        }

        public static List<Empleado> OrdenarXNombre(List<Empleado> empleados)
        {
            return empleados.OrderBy(q => q.Nombre).ToList();
        }
        public static List<Empleado> OrdenarXSalario(List<Empleado> empleados)
        {
            return empleados.OrderBy(q => q.Salario).ToList();
        }

        public static List<Empleado> OrdenarXNombreYSalario(List<Empleado> empleados)
        {
            var OrdenLnQ = empleados.OrderBy(q => q.Nombre).ThenBy(q => q.Salario).ToList();
            return OrdenLnQ;
        }

        public static void SeleccionarNombreYApellido(List<Empleado> empleados)
        {
            var ListaSeleccionada = empleados.Select(q => new { q.Nombre, q.Apellido });
            foreach (var item in ListaSeleccionada)
            {
                Console.WriteLine($"Nombres:{item.Nombre} {item.Apellido}");
            }
        }

        public static void SumarTodoSalarios(List<Empleado> empleados)
        {
            var SumaTotal = empleados.Sum(q => q.Salario);
            Console.WriteLine(SumaTotal);
        }
        public static void FiltrarPorSalarioYPuesto(List<Empleado> empleados, double salario, string puesto)
        {
            var listaFiltrada = empleados.Where(q => q.Salario > salario && q.Puesto.ToLower() == puesto.ToLower()).OrderByDescending(q => q.Nombre).ToList();
            empleadosController.ImprimirEmpleadosxLista(listaFiltrada);
        }

        public static void AgruparPorPuestoYMostrarSalario(List<Empleado> empleados)
        {
            var PuestoAgrupado = empleados.GroupBy(q => q.Puesto);
            foreach (var empleadoAgrupado in PuestoAgrupado)
            {
                Console.WriteLine($"Puesto: {empleadoAgrupado.Key}");
                var SalarioPromedio = empleadoAgrupado.Average(q => q.Salario);
                Console.WriteLine($"Salario promedio:{SalarioPromedio}");
            }
        }

        public static void BuscarPorSubcadena(List<Empleado> empleados, string? subcadena)
        {
            if (string.IsNullOrEmpty(subcadena))
            {
                Console.WriteLine("No se admiten valores nulos");
                return;
            }
            var resultado = empleados
                .Where(e => e.Nombre.ToLower().Contains(subcadena.ToLower())
                || e.Apellido.ToLower().Contains(subcadena.ToLower()))
                .ToList();
            ImprimirEmpleadosxLista(resultado);
        }
        public static void SeleccionarPorPuestoYPorSalario(List<Empleado> empleados)
        {
            var empleadosOrdenados = empleados.OrderBy(q => q.Puesto).ThenByDescending(q => q.Salario).ToList();
            ImprimirEmpleadosxLista(empleadosOrdenados);
        }

        public static void UnirEmpleadosYDepartamentos(List<Empleado> empleados, List<Departamento> departamentos)
        {
            var join = from emp in empleados
                    join depto in departamentos on emp.DepartamentoId equals depto.Id
                    select new
                    {
                        NombreCompleto = $"{emp.Nombre} {emp.Apellido}",
                        emp.Puesto,
                        emp.Salario,
                        Departamento = depto.Nombre
                    };
            foreach (var item in join)
            {
                Console.WriteLine($"Nombre:{item.NombreCompleto}| Puesto: {item.Puesto} | Salario: {item.Salario} | Departamento: {item.Departamento}");
            }
        }
    }
}