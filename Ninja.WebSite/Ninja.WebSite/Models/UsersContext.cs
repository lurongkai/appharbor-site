using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Driver;

namespace Ninja.WebSite.Models
{
    public class UsersContext : IUsersContext, IDisposable
    {
        private MongoUrl _mongoUrl;
        private MongoClient _mongoClient;
        private MongoServer _mongoServer;
        private MongoDatabase _mongoDatabase;

        public UsersContext() {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            _mongoUrl = new MongoUrl(connectionstring);
            _mongoClient = new MongoClient(_mongoUrl);
            _mongoServer = _mongoClient.GetServer();
            _mongoDatabase = _mongoServer.GetDatabase(_mongoUrl.DatabaseName);
        }

        public MongoCollection<UserProfile> UserProfiles {
            get { return _mongoDatabase.GetCollection<UserProfile>(typeof (UserProfile).Name); }
        }

        public void Dispose() {
        }
    }
}