#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs.Models
{
   public class Plato
{
    public int PlatoId { get; set; }
    [Required(ErrorMessage = "El nombre del plato es obligatorio")]
    public string Nombre { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Las calorías deben ser mayores que cero")]
    public int Calorias { get; set; }
    [Range(1, 5, ErrorMessage = "El sabor debe estar entre 1 y 5")]
    public int Sabor { get; set; }
    public int ChefId { get; set; }
    public Chef Chef { get; set; }
}
}
