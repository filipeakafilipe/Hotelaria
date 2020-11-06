using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelaria.Infrastructure.Mapping;
using System.Runtime.InteropServices.ComTypes;

namespace Hotelaria.Infrastructure.Repositories
{
    public class UsuariosRepository : BaseRepository, IUsuariosRepository<UsuarioVO>
    {
        public void Adicionar(UsuarioVO entidadeVO)
        {
            var user = GetByLogin(entidadeVO.Login);

            if (user != null)
            {
                throw new Exception();
            }

            var entidade = mapper.Map<Usuario>(entidadeVO);

            db.Usuarios.Add(entidade);

            db.SaveChanges();
        }

        public void Atualizar(int id, UsuarioVO entidade)
        {
            var usuario = mapper.Map<Usuario>(Get(id));

            if (usuario != null)
            {
                usuario.Cpf = entidade.Cpf;
                usuario.Email = entidade.Email;
                usuario.Login = entidade.Login;
                usuario.Nome = entidade.Nome;
                usuario.Senha = entidade.Senha;
                usuario.Telefone = entidade.Telefone;

                db.Entry(usuario).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public UsuarioVO Get(int id)
        {
            return mapper.Map<UsuarioVO>(db.Usuarios.FirstOrDefault(u => u.Id == id));
        }

        public List<UsuarioVO> Get(string cpf)
        {
            //var a = mapper.Map<List<UsuarioVO>>(db.Usuarios.Where(u => u.Cpf == cpf).ToList());
            //return a;
            var a = db.Usuarios.Where(u => u.Cpf == cpf).ToList();
            return mapper.Map<List<UsuarioVO>>(a);
        }

        public List<UsuarioVO> GetAll()
        {
            return mapper.Map<List<UsuarioVO>>(db.Usuarios.ToList());
        }

        public UsuarioVO GetByLogin(string login)
        {
            return mapper.Map<UsuarioVO>(db.Usuarios.FirstOrDefault(u => u.Login == login));
        }

        public void Remover(int id)
        {
            var usuario = mapper.Map<Usuario>(Get(id));

            if (usuario != null)
            {
                db.Usuarios.Remove(usuario);

                db.SaveChanges();
            }
        }
    }
}
