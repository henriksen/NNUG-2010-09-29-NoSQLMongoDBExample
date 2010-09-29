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
                db.Database.DropCollection("Meeting");

                var meetings = db.GetCollection<Meeting>();

                //insert into collection
                meetings.Insert(new Meeting
                {
                    ID = 1,
                    Location = "ErgoGroup",
                    Description = "ASP.NET MVC, Bing Maps og Silverlight, NoSQL. Og pizza!",
                    StartTime = new DateTime(2010, 9, 29, 16, 30, 00),
                    Talks = new List<Talk> { new Talk
                                                 {
                                                     Speaker = new Person() { Firstname = "Fredrik", Lastname = "Kalseth"},
                                                     Topic = "ASP.NET MVC 3"
                                                 }, 
                                            new Talk
                                                 {
                                                     Speaker = new Person { Firstname = "Niall", Lastname = "Merrigan"},
                                                     Topic = "Bing maps and YR.no mashup"
                                                 }, 
                                            new Talk
                                                 {
                                                     Speaker = new Person { Firstname = "Glenn", Lastname = "Henriksen"},
                                                     Topic = "NoSQL"
                                                 }, 
                    }
                });


                var query = db.GetCollection<Meeting>().AsQueryable();
                //find a post by id
                var meeting = query.FirstOrDefault(p => p.ID == 1);

                //update the post.
                meeting.Location = "ErgoGroup, Maskinveien 32";
                meetings.Save(meeting);

                Console.ReadLine();
            }
        }


    }
}
