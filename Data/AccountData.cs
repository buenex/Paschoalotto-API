using Paschoalotto_API.Infra;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Paschoalotto_API.Models;

namespace Paschoalotto_API.Data
{
    public class AccountData
    {
        DbConnection db = new DbConnection();
        public bool hasAccount(){
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM usuario");

            return db.executeQuery(str.ToString());
        }

        public bool hasAccountUser(Usuario user){
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM usuario ");
            str.Append("WHERE usuario=@usuario");

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@usuario",SqlDbType.VarChar,50,user.usuario);

            return db.executeQuery(str.ToString(),parameters);
        }

        public bool updateUser(Usuario user)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE usuario ");
            str.Append("SET usuario=@usuario, ");
            str.Append("    senha=@senha, ");
            str.Append("    nome=@nome, ");
            str.Append("    email=@email ");
            str.Append("WHERE usuario = @usuario");

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@usuario",SqlDbType.VarChar,50,user.usuario);
            parameters[1] = new SqlParameter("@senha",SqlDbType.VarChar,50,user.senha);
            parameters[2] = new SqlParameter("@nome",SqlDbType.VarChar,50,user.nome);
            parameters[3] = new SqlParameter("@email",SqlDbType.VarChar,100,user.email);

            return db.executeNonQuery(str.ToString(),parameters);
        }

        public bool deleteUser(Usuario user){
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM usuario ");
            str.Append("WHERE usuario = @usuario");

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@usuario",SqlDbType.VarChar,50,user.usuario);

            return db.executeNonQuery(str.ToString(),parameters);
        }

        public bool insertUser(Usuario user){
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO usuario ");
            str.Append("VALUES(@usuario, ");
            str.Append("       @senha, ");
            str.Append("       @nome, ");
            str.Append("       @email) ");

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@usuario",SqlDbType.VarChar,50,user.usuario);
            parameters[1] = new SqlParameter("@senha",SqlDbType.VarChar,50,user.senha);
            parameters[2] = new SqlParameter("@nome",SqlDbType.VarChar,50,user.nome);
            parameters[3] = new SqlParameter("@email",SqlDbType.VarChar,100,user.email);

            return db.executeNonQuery(str.ToString(),parameters);
        }
    }
}