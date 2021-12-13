using Api.Gateway.Models.Diagnosticos.DTOs;
using System.Collections.Generic;

namespace WebClientBlazor.Models
{
    public class PreguntaRespuesta
    {
        public PreguntaRespuesta()
        {

        }

        public PreguntaRespuesta(string pregunta, List<OpcionDto> opciones, string respuesta)
        {
            Pregunta = pregunta;
            Opciones = opciones;
            Respuesta = respuesta;
        }

        public int IdPregunta { get; set; }
        public int IdEspecialidad { get; set; }
        public string Pregunta { get; set; }
        public List<OpcionDto> Opciones { get; set; }
        public string Respuesta { get; set; }
    }

}
