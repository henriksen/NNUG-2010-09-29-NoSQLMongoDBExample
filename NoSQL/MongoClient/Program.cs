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
                meetings.Insert(new Meeting
                {
                    ID = 2,
                    Location = "Capgemeni",
                    Description = "TDD, BDD and pizza!",
                    StartTime = new DateTime(2009, 8, 12, 16, 30, 00),
                    Talks = new List<Talk> { new Talk
                                                 {
                                                     Speaker = new Person() { Firstname = "Fredrik", Lastname = "Kalseth"},
                                                     Topic = "Test driven development"
                                                 }, 
                                            new Talk
                                                 {
                                                     Speaker = new Person { Firstname = "Glenn", Lastname = "Henriksen"},
                                                     Topic = "Behaviour driven development"
                                                 }, 
                    }
                });


                var query = db.GetCollection<Meeting>().AsQueryable();
                //find a post by id
                var glennsMeetings = query.Where(p => p.Talks.Any( t => t.Speaker.Firstname == "Glenn") );

                foreach (var meeting in glennsMeetings)
                {
                    Console.WriteLine(meeting.Location);
                }

                Console.ReadLine();
            }
        }


    }
}
