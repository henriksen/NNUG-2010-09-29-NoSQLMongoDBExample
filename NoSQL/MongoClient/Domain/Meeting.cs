using System;
using System.Collections.Generic;

namespace MongoClient.Domain
{
    public class Meeting
    {
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Talk> Talks { get; set; }
    }
}