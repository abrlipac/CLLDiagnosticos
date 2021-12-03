using System.Collections.Generic;

namespace Diagnosticos.Domain
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreClave { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public int CantidadSintomas { get; set; }
        public ICollection<PosibleEnfermedad> PosiblesEnfermedades { get; set; }
    }
}
