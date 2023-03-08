﻿using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repository
{
    public class UsuarioRepos : IUsuarios
    {
        private readonly Contexto contexto;

        public UsuarioRepos(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Usuarios Adicionar(Usuarios usuario)
        {
            usuario.SetaSenhaHash();
            contexto.Usuarios.Add(usuario);
            usuario.DataCadastro = DateTime.UtcNow;
            contexto.SaveChanges();
            return usuario;

        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Usuarios Atualizar(Usuarios usuarios)
        {
            Usuarios usuarioDB = BuscarUsuariosPorId(usuarios.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário.");

            usuarioDB.Nome = usuarios.Nome;
            usuarioDB.Username = usuarios.Username;
            usuarioDB.Email = usuarios.Email;
            usuarioDB.DataCadastro = usuarios.DataCadastro;
            usuarioDB.UsuariosEnum = usuarios.UsuariosEnum;

            contexto.Usuarios.Update(usuarioDB);
            contexto.SaveChanges();
            return usuarioDB;
        }

        public Usuarios BuscarPorLogin(string login)
        {
            return contexto
                .Usuarios
                .FirstOrDefault(x => x.Username.ToUpper() == login.ToUpper());
        }

        public Usuarios BuscarPorLoginEEmail(string login, string email)
        {
            return contexto
                .Usuarios
                .FirstOrDefault(x => x.Username.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public List<Usuarios> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuarios BuscarUsuariosPorId(int id)
        {
            return contexto.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
