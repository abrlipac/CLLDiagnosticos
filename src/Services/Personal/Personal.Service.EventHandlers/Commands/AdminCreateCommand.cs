﻿using MediatR;

namespace Personal.Service.EventHandlers.Commands
{
    public class AdminCreateCommand : INotification
    {
        public string Usuario_Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
    }
}
