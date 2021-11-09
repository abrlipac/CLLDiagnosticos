using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class Usuario : IdentityUser
    {
        public int Empleado_Id { get; set; }
        public string NombreCompleto { get; set; }
        public ICollection<RolUsuario> Roles { get; set; }
    }
}
