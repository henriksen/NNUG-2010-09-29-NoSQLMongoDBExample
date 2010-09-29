namespace MongoClient.Domain
{
    public class Talk   
    {
        public int ID { get; set; }
        public string Topic { get; set; }
        public Person Speaker { get; set; }

    }
}