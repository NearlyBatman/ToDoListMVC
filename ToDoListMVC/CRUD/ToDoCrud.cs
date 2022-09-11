using MongoDB.Driver;
using ToDoListMVC.Models;

namespace ToDoListMVC.CRUD
{
    public class ToDoCrud
    {
        private readonly IMongoCollection<ToDoList> toDoLists;

        public ToDoCrud(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("ToDoDb"));
            IMongoDatabase database = client.GetDatabase("ToDoListDb");
            toDoLists = database.GetCollection<ToDoList>("ToDoList");
        }

        public List<ToDoList> GetLists()
        {
            return toDoLists.Find(rec => true).ToList();
        }

        public ToDoList Get(string id)
        {
            return toDoLists.Find(rec => rec.Id == id).FirstOrDefault();
        }

        public ToDoList Create(ToDoList toDoList)
        {
            toDoLists.InsertOne(toDoList);
            return toDoList;
        }

        public void Update(string id, ToDoList toDoList)
        {
            toDoLists.ReplaceOne(rec => rec.Id == id, toDoList);
        }

        public void Remove(string id)
        {
            toDoLists.DeleteOne(rec => rec.Id == id);
        }



    }
}
