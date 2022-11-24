using Dapper;
using System.Data.SqlClient;
using user.Models;

namespace user.UserServices
{
    public class UploadServices : Iup
    {
        private IConfiguration _conf;
        public UploadServices(IConfiguration configuration)
        {
            _conf = configuration;
        }
        public void UP(string sp_assignment,Upload upload,string uploadpath)
        {
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(_conf.GetConnectionString("new")))
            {
                conn.Open();
                var Para = new DynamicParameters();
                Para.Add("@name", upload.Name);
                Para.Add("@Phonenumber", upload.Phonenumber);
                Para.Add("@Imageinfo", uploadpath);
                conn.Execute(sp_assignment, Para, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
    public interface Iup
    {
        void UP(string sp_assignment, Upload upload, string uploadpath);
    }
}