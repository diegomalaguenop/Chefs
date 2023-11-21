using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs.Models
{
  public class Chef
{
    public int ChefId { get; set; }
    [Required(ErrorMessage = "El nombre del chef es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Nacimiento")]
    public DateTime FechaNacimiento { get; set; }
    public ICollection<Plato> Platos { get; set; }
}
}
