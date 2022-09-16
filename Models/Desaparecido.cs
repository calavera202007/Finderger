using System;
using System.Collections.Generic;

namespace Findergers.Models
{
    public partial class Desaparecido
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaDesaparicion { get; set; }
        public byte[]? Imagen { get; set; }


    }
}
