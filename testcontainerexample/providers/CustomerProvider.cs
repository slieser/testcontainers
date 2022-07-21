using MongoDB.Driver;
using testcontainerexample.contracts;

namespace testcontainerexample.providers;

public class CustomerProvider : MongoDbProviderBase
{
    private const string CustomersCollection = "customers";

    public async Task<List<Customer>> GetAll() {
        var seminars = _database.GetCollection<Customer>(CustomersCollection);
        var asyncCursor = await seminars.FindAsync(_ => true);
        var result = await asyncCursor.ToListAsync();
        return result;
    }

    public async Task<string> Add(Customer customer) {
        var customers = _database.GetCollection<Customer>(CustomersCollection);
        await customers.InsertOneAsync(customer);
        return customer.Id;
    }
}