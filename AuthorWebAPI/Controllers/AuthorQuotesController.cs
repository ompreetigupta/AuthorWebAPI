using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AuthorWebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthorQuotesController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthorQuotesController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        [HttpGet("get_tasks")]

        public JsonResult get_tasks()
        {
            string query = "select * from AuthorQuotes";
            DataTable table = new DataTable();
            string SqlDatasource = _configuration.GetConnectionString("mydata");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDatasource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) 
                {
                myReader=myCommand.ExecuteReader();
                table.Load(myReader);
                }
            }
            return new JsonResult(table);
        }


    }
}
