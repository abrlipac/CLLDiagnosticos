using System.Collections.Generic;

namespace Diagnosticos.Domain
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
    }
}
