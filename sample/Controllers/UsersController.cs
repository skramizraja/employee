using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //private readonly IMongoCollection<ProductModel> _product;
        //public ProductService(IConfiguration config)
        //{
        //    var Client = new MongoClient(config.GetConnectionString("MongoDBHost")/*"mongodb://localhost:27017"*/);
        //    var Database = Client.GetDatabase(config.GetConnectionString("DataBaseName"));
        //    _product = Database.GetCollection<ProductModel>(config.GetConnectionString("CollectionName"));
        //}

        // private readonly IMongoCollection<Employees> employees;

        public UsersController()
        {
            //var client = new MongoClient(dbSettings.ConnectionString);
            //var db = client.GetDatabase(dbSettings.DatabaseName);
        }

        
        //public IActionResult GetEmployee()
        //{

        //}
    }
}
