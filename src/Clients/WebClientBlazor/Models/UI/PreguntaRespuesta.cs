using System.Collections.Generic;

namespace Models
{
    public class PreguntaRespuesta
    {
        public PreguntaRespuesta(string pregunta, List<string> opciones, string respuesta)
        {
            Pregunta = pregunta;
            Opciones = opciones;
            Respuesta = respuesta;
        }

        public int IdPregunta { get; set; }
        public int IdEspecialidad { get; set; }
        public string Pregunta { get; set; }
        public List<string> Opciones { get; set; }
        public string Respuesta { get; set; }
    }

}
