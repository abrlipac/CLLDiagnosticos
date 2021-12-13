using Api.Gateway.Models.Clientes.Common;
using Api.Gateway.Models.Diagnosticos.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebClientCore.Models
{
    public class EditarDiagnosticoViewModel
    {
        public DiagnosticoDto Diagnostico { get; set; }
        public DiagnosticoDto DiagnosticoViewData { get; set; }
    }

    public class DiagnosticoViewData
    {

    }
}
