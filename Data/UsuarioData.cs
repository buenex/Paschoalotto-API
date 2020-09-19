using Paschoalotto_API.Infra;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Paschoalotto_API.Models;
using System.Collections.Generic;

namespace Paschoalotto_API.Data
{
    public class UsuarioData:DbConnection
    {
        DbConnection db = new DbConnection();
        public List<UsuarioModel> hasAccount(){
            List<UsuarioModel> lista = new List<UsuarioModel>();
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * FROM usuario");

                command.CommandText = str.ToString();

                SqlDataReader reader;
                reader = command.ExecuteReader();
                
                while(reader.Read())
                {
                    lista.Add(new UsuarioModel(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4)));
                }
                disconnect();                              
            }      
            return lista;  
        }

        public List<UsuarioModel> getAll(){
            List<UsuarioModel> lista = new List<UsuarioModel>();
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * FROM usuario ");

                command.CommandText = str.ToString();

                SqlDataReader reader;
                reader = command.ExecuteReader();                
                while(reader.Read())
                {
                    lista.Add(new UsuarioModel(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4)));
                }                                                        
            }     
            disconnect(); 
            return lista;  
        }

        public bool login(string usuario,string senha){
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * FROM usuario ");
                str.Append("WHERE usuario=@usuario ");
                str.Append("AND   senha=@senha");

                command.Parameters.Add(new SqlParameter("@usuario",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@senha",SqlDbType.VarChar,50));
                command.Parameters[0].Value = usuario;
                command.Parameters[1].Value = senha;

                command.CommandText = str.ToString();

                SqlDataReader reader;
                reader = command.ExecuteReader();
                
                if(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        disconnect(); 
                        return true;
                    }else
                    {
                        disconnect(); 
                        return false;
                    }
                }                                                        
            }     
            disconnect(); 
            return false;  
        }

        public UsuarioModel hasAccountUser(string user)
        {
            UsuarioModel usuario = new UsuarioModel();
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * FROM usuario ");
                str.Append("WHERE usuario = @usuario");

                command.Parameters.Add(new SqlParameter("@usuario",SqlDbType.VarChar,50));
                command.Parameters[0].Value = user;
                
                command.CommandText = str.ToString();

                SqlDataReader reader;
                reader = command.ExecuteReader();
                
                while(reader.Read())
                {
                    usuario = new UsuarioModel(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4));
                }
                disconnect();                              
            }      
            return usuario;     
        }

        public void updateUser(string user,UsuarioModel usuario)
        {
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("UPDATE usuario ");
                str.Append("SET usuario=@usuario, senha=@senha,nome=@nome,email=@email ");
                str.Append("WHERE usuario = @user");    

                command.Parameters.Add(new SqlParameter("@usuario",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@senha",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@nome",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@email",SqlDbType.VarChar,150));
                command.Parameters.Add(new SqlParameter("@user",SqlDbType.VarChar,50));
                command.Parameters[0].Value = usuario.usuario;
                command.Parameters[1].Value = usuario.Senha;
                command.Parameters[2].Value = usuario.Nome;
                command.Parameters[3].Value = usuario.Email;
                command.Parameters[4].Value = user;
                
                command.CommandText = str.ToString();
                command.ExecuteNonQuery();                
                
                disconnect();                              
            }
        }

        public void deleteUser(UsuarioModel user){
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("DELETE FROM usuario ");
                str.Append("WHERE usuario=@usuario");

                command.Parameters.Add(new SqlParameter("@usuario",SqlDbType.VarChar,50));
                command.Parameters[0].Value = user.usuario;
                
                command.CommandText = str.ToString();
                command.ExecuteNonQuery();                
                
                disconnect();                              
            }
        }

        public void insertUser(UsuarioModel user){
            if(connect())
            {
                StringBuilder str = new StringBuilder();
                str.Append("INSERT INTO usuario ");
                str.Append("VALUES(@usuario,@senha,@nome,@email)");

                command.Parameters.Add(new SqlParameter("@usuario",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@senha",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@nome",SqlDbType.VarChar,50));
                command.Parameters.Add(new SqlParameter("@email",SqlDbType.VarChar,150));
                command.Parameters[0].Value = user.usuario;
                command.Parameters[1].Value = user.Senha;
                command.Parameters[2].Value = user.Nome;
                command.Parameters[3].Value = user.Email;
                
                command.CommandText = str.ToString();
                command.ExecuteNonQuery();                
                
                disconnect();                              
            }
        }
    }
}