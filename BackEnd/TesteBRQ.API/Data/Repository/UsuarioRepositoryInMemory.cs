using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBRQ.API.Data.Repository.Interface;
using TesteBRQ.API.Entities;
using System.Runtime.Caching;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace TesteBRQ.API.Data.Repository
{
    public class UsuarioRepositoryInMemory : IUsuarioRepository
    {
        ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        public void AddUsuario(Usuario usuario)
        {

            // Get the List of Entities from the Cache
            var usuarios = (List<Usuario>)cache.Get("Usuarios");

            // Add the entity
            usuarios.Add(usuario);

            //if (!cache.Contains("Usuarios"))
            //{
            //    var usuarios = new List<string>();

            //    usuarios.Add(usuario.Nome);
            //    usuarios.Add(usuario.CPF);
            //    usuarios.Add(usuario.Email);
            //    usuarios.Add(usuario.Telefone);
            //    usuarios.Add(usuario.Sexo.ToString());
            //    usuarios.Add(usuario.DataNascimento.ToString());
            //    usuarios.Add($"Cached: {DateTime.Now.ToLongTimeString()}");

            //    CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2) };

            //    cache.Add("Usuarios", usuario, policy);
            //}
        }

        public void Delete(int id)
        {
            // Get the List of Entities from the Cache
            var usuario = (List<string>)cache.Get("Usuarios");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= usuario.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }

            // Delete the Entity
            usuario.RemoveAt(id);
        }

        public Usuario GetUsuarioPorId(int id)
        {
            // Get the List of Entities from the Cache
            var usuario = (List<Usuario>)cache.Get("Usuarios");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= usuario.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }
            else
            {
                return usuario[id];
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return (IEnumerable<Usuario>)cache.Get("Usuarios");
        }

        public void Update(Usuario usuario)
        {
            var usuarios = (List<Usuario>)cache.Get("Usuarios");

            if (usuario.Id >= usuarios.Count || usuario.Id < 0)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }

            usuarios[usuario.Id] = usuario;
        }
    }
}
