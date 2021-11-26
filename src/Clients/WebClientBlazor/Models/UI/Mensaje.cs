using System.Collections.Generic;

namespace Models
{
    public class Mensaje
    {
        public string Contenido { get; set; }
        public bool EsPregunta { get; set; }
        public List<string> Opciones { get; set; }
        public string OpcionElegida { get; set; }
    }
}
