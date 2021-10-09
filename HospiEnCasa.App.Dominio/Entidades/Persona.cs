using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        [Display(Name = "Número telefónico")]
        public string NumeroTelefono {get;set;}
        public Genero Genero {get;set;}
    }
}
