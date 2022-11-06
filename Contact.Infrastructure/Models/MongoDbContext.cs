using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contact.Infrastructure.Models
{
    public class MongoDbContext
    {  
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _mongoDatabase;
       public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetValue<string>("MongoDBConfiguration:ConnectionString");
            var db = _configuration.GetValue<string>("MongoDBConfiguration:Database");
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(db);
        }

      

        

        public IMongoCollection<Contact> Contact => _mongoDatabase.GetCollection<Contact>(nameof(Contact));
        public IMongoCollection<ContactInfo> ContactInfo => _mongoDatabase.GetCollection<ContactInfo>(nameof(ContactInfo));


    }
}
