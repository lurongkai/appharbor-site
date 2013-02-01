using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Ninja.WebSite.Models
{
    public interface IUsersContext
    {
        MongoCollection<UserProfile> UserProfiles { get; }
    }
}
