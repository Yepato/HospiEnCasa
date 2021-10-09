using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        /*private readonly AppContext _appContext; // Recomendable por seguridad
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext; // Necesitamos definir un contexto
        }*/

        // Lo de arriba se sustituye por:

        private readonly AppContext _appContext = new AppContext();

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        { 
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges(); // Se deben guardar los cambios
            return pacienteAdicionado.Entity;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente); // p es el primero
            if(pacienteEncontrado == null)
            return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges(); // Se deben guardar los cambios
        }

        IEnumerable <Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        Paciente IRepositorioPaciente.GetPaciente (int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente); // Retorna lo que encuentra
        }

        Paciente IRepositorioPaciente.UpdatePaciente (Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            // No se busca el idPaciente, se busca el paciente.Id
            if(pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellido = paciente.Apellido;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                _appContext.SaveChanges();        
            }

            return pacienteEncontrado; // Retorna el paciente encontrado
        }
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        { 
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            { 
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                { 
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
            return medicoEncontrado;
            }
        return null;
        }
    }
}
// implementa la interfaz
