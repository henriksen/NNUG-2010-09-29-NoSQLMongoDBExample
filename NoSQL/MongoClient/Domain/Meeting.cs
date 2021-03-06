using System;
using System.Collections.Generic;

namespace MongoClient.Domain
{
    public class Meeting
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int PeopleCount { get; set; }
        public List<Talk> Talks { get; set; }
    }
}