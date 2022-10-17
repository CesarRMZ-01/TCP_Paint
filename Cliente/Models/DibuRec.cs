using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Models
{
    internal class DibuRec
    {
        public int? Ancho { get; set; } = 50;
        public int? Alto { get; set; } = 50;
        public double? X { get; set; } = 0;
        public double? Y { get; set; } = 0;
        public string? Color { get; set; } = "#9BADB7";

    }
}
