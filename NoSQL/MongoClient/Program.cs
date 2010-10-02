using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoClient.Domain;
using Norm;

namespace MongoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = Mongo.Create("mongodb://localhost/NNUG"))
            {
                //db.Database.DropCollection("Meeting");

                var meetings = db.GetCollection<Meeting>();

                //insert into collection
                meetings.Insert(new Meeting
                {
                    ID = 4,
                    Location = "ErgoGroup",
                    Description = "ASP.NET MVC, Bing Maps og Silverlight, NoSQL. Og pizza!",
                    StartTime = new DateTime(2010, 9, 29, 16, 30, 00),
                    EndTime = new DateTime(2010, 9, 29, 19, 30, 00),
                    PeopleCount = 27
                });
            }
        }


    }
}
