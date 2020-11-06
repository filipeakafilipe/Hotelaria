using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotelaria.Infrastructure.Mapping
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Login { get; set; }
        [MaxLength(20)]
        public string Senha { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(15)]
        public string Telefone { get; set; }
        [MaxLength(14)]
        public string Cpf { get; set; }

        public static implicit operator Usuario(Application.Models.Usuario usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Login = usuario.Login,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone
            };
        }
    }
}
