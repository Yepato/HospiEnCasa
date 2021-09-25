using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using System.Collections.Generic;


namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddPaciente();
            AddMedico();
            BuscarPaciente(1);
            MostrarPacientes();
            AsignarMedico();
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Mario",
                Apellido = "Hernández",
                NumeroTelefono = "1111111111",
                Genero = Genero.Masculino,
                Direccion = "cra 11 11-11 este",
                Ciudad = "Bogotá",
                Latitud = 5.07F,
                Longitud = -75.52F,
                FechaNacimiento = new DateTime(1990, 04 , 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine("Nombre: " + paciente.Nombre + " " + paciente.Apellido + "  Género: " + paciente.Genero);
        }
        private static void MostrarPacientes()
        {
            IEnumerable<Paciente> pacientes = _repoPaciente.GetAllPacientes();
            foreach (var paciente in pacientes)
            {
                Console.WriteLine("Nombre paciente: " + paciente.Nombre + " " + paciente.Apellido + "  Género: " + paciente.Genero);
            }
        } 
        private static void AddMedico()
        {
            var medico = new Medico
            {
                Nombre = "Gabriel",
                Apellido = "Torres",
                NumeroTelefono = "2222222222",
                Genero = Genero.Masculino,
                Especialidad = "Neurocirujano",
                Codigo = "22222222-2",
                RegistroRethus = "DEF456"
            };
            _repoMedico.AddMedico(medico);
        }
        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(2,17);
            var paciente = _repoPaciente.GetPaciente(2);
            Console.WriteLine("Médico: " + medico.Nombre + " " + medico.Apellido + " quedó asignado al Paciente: " + paciente.Nombre + " " + paciente.Apellido);
        }
    }
}
