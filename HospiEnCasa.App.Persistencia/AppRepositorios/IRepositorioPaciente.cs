using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes(); // Método que me retorna todos los pacientes
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente);
        Medico AsignarMedico(int idPaciente, int idMedico);
    }
}
