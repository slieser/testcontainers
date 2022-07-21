using MongoDB.Driver;

namespace testcontainerexample.providers;

public class MongoDbProviderBase
{
    protected const string SeminarsCollection = "seminars";
    protected const string BlocksCollection = "blocks";
    protected readonly IMongoDatabase _database;

    protected MongoDbProviderBase() {
        var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        _database = dbClient.GetDatabase("curriculumPlaner");
    }
}