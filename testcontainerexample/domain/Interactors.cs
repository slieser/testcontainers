using testcontainerexample.contracts;
using testcontainerexample.providers;

namespace testcontainerexample.domain;

public class Interactors
{
    private readonly CustomerProvider _customerProvider;

    public Interactors(CustomerProvider customerProvider) {
        _customerProvider = customerProvider;
    }

    public Task<List<Customer>> GetAllCustomers() {
        return _customerProvider.GetAll();
    }

    public async Task<string> AddCustomer(Customer customer) {
        return await _customerProvider.Add(customer);
    }
}