using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext; // Recomendable por seguridad
        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext; // Necesitamos definir un contexto
        }
        Medico IRepositorioMedico.AddMedico(Medico medico)
        { 
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges(); // Se deben guardar los cambios
            return medicoAdicionado.Entity;
        }

        void IRepositorioMedico.DeleteMedico(int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idMedico); // p es el primero
            if(pacienteEncontrado == null)
            return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges(); // Se deben guardar los cambios
        }

        IEnumerable <Medico> IRepositorioMedico.GetAllMedicos()
        {
            return _appContext.Medicos;
        }

        Medico IRepositorioMedico.GetMedico (int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico); // Retorna lo que encuentra
        }

        Medico IRepositorioMedico.UpdateMedico (Medico medico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(p => p.Id == medico.Id);
            // No se busca el idMedico, se busca el medico.Id
            if(medicoEncontrado != null)
            {
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellido = medico.Apellido;
                medicoEncontrado.NumeroTelefono = medico.NumeroTelefono;
                medicoEncontrado.Genero = medico.Genero;
                medicoEncontrado.Especialidad = medico.Especialidad;

                _appContext.SaveChanges();        
            }

            return medicoEncontrado; // Retorna el medico encontrado
        }
    }
}
// implementa la interfaz
