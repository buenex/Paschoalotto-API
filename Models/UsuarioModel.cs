using System;
using System.Reflection;

namespace Paschoalotto_API.Models
{
    public class UsuarioModel
    {
        public int Codigo {get;set;}
        public string usuario {get;set;}
        public string Senha{get;set;}
        public string Nome{get;set;}
        public string Email{get;set;}

        public UsuarioModel(int codigo,string usuario,string senha,string nome, string email)
        {
            this.Codigo=codigo;
            this.usuario = usuario;
            this.Senha=senha;
            this.Nome = nome;
            this.Email = email;
        }

        public UsuarioModel(){
            
        }
    }
}