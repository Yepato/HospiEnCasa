using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;


namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddPaciente();
            BuscarPaciente(1);
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Carla",
                Apellido = "Mendez",
                NumeroTelefono = "6666666666",
                Genero = Genero.Femenino,
                Direccion = "cra 88 88-88 norte",
                Ciudad = "Bogotá"
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine("Nombre: " + paciente.Nombre + " " + paciente.Apellido + "  Género: " + paciente.Genero);
        }  
    }
}
