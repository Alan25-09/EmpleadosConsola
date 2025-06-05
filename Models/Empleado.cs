namespace Models.Empleado
{
    public class Empleado
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Puesto { get; set; }
        public required double Salario { get; set; }
        public required int DepartamentoId { get; set; }
    }
}
