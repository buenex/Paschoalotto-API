using System.Data.SqlClient;
using System.Data;
using System;

namespace Paschoalotto_API.Infra
{
    public class DbConnection
    {
        SqlConnection connection= new SqlConnection();
        SqlCommand command = new SqlCommand();
        const string server="localhost";
        const string user="sa";
        const string password="123456";
        const string database = "Paschoalotto";

        string connectionString="Server="+server+";Database="+database+";User Id="+user+";Password="+password+";";

        bool connect(){
            connection.ConnectionString = connectionString;
            try{
                connection.Open();
                return true;
            }catch(Exception e){
                throw new Exception("Erro de sql: "+e.Message);
            }            
        }

        public bool executeNonQuery(string query,SqlParameter[] parameters){
            try{
                if(connect()){
                    command.Connection=connection;
                    command.CommandText=query;
                    if(parameters.Length>0){
                        for (int i=0; i<parameters.Length; i++){
                            command.Parameters.Add(parameters[i]);
                        }
                    }
                    command.ExecuteNonQuery();
                }
                return true;
            }catch{
                return false;
            }
        }

        public bool executeQuery(string query,SqlParameter[] parameters = null){
            try{
                if(connect()){
                     
                    command.Connection=connection;
                    command.CommandText=query;
                    if(parameters.Length>0){
                        for (int i=0; i<parameters.Length; i++){
                            command.Parameters.Add(parameters[i]);
                        }
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read()){
                        if(reader.HasRows){
                            return true;
                        }else{
                            return false;
                        }
                     throw new Exception("Ocorreu um erro ao executar o comando");
                    }
                }                
            }catch(Exception e){
                throw new Exception("Erro de sql: "+e.Message);
            }
            return false;
        }
    }
}