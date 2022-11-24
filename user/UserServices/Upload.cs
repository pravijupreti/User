using Dapper;
using Microsoft.CodeAnalysis;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using user.Models;
namespace Project.UserService
{
    public class UserService : Iuser
    {
        private IConfiguration _conf;
        public UserService(IConfiguration configuration)
        {
            _conf = configuration;
        }

        public void Create(User user)
        {
            using (SqlConnection conn = new SqlConnection(_conf.GetConnectionString("new")))
            {
                conn.Open();

                var query = @"insert into Userinfo (Name,Surname,Username,Email,Phonenumber,Password,Shortbio) values('" + user.Name + "', '" + user.Surname + "','" + user.Username + "','" + user.Email + "'," + user.Phonenumber + " ,'" + user.Password + "','" + user.Shortbio + "' )";
                conn.Execute(query, commandType: System.Data.CommandType.Text);
            }
        }

        public int ByRoll(string Spget, User data)
        {
            using (SqlConnection conn = new SqlConnection(_conf.GetConnectionString("new")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", data.Username,DbType.String);
                param.Add("@Password",data.Password,DbType.String);
                var result= conn.Query<User>(Spget, param, commandType:CommandType.StoredProcedure);
                return Convert.ToInt32(result.Equals(result));
            }
        }

        public List<Upload> GetAsignment(string sp_uploadget, string Phonenumber)
        {
            using (SqlConnection conn = new SqlConnection(_conf.GetConnectionString("new")))
            { 
                conn.Open();
                var param = new DynamicParameters();
                param.Add("@Phonenumber", Phonenumber, DbType.String);
                var result = conn.Query<Upload>(sp_uploadget, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
    }
    public interface Iuser
    {
        void Create(User user);
        public int ByRoll(string Spget,User data);
        public List<Upload> GetAsignment(string sp_uploadget,string Phonenumber);
    }
}

