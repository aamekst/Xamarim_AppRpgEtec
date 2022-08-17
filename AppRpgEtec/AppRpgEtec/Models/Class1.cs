using System;
using System.Collections.Generic;
using System.Text;

namespace AppRpgEtec.Models
{
    public class Usuario
    {
        public string Username { get; set; }    
        public int Id { get; set; }

        public string Perfil { get; set; }

        public string Token { get; set; }

        public byte[] Foto { get; set; }

        public string PasswordString{ get; set; }

    }
}
