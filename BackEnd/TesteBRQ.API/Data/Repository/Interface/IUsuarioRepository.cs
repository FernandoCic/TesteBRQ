using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBRQ.API.Entities;

namespace TesteBRQ.API.Data.Repository.Interface
{
    public interface IUsuarioRepository
    {
        void AddUsuario(Usuario usuario);
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioPorId(int id);
        void Update(Usuario usuario);
        void  Delete(int id);
    }
}
