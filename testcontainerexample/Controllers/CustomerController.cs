using Microsoft.AspNetCore.Mvc;
using testcontainerexample.contracts;
using testcontainerexample.domain;

namespace testcontainerexample.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly Interactors _interactors;

    public CustomerController(ILogger<CustomerController> logger, Interactors interactors) {
        _logger = logger;
        _interactors = interactors;
    }
    
    [HttpGet]
    public Task<List<Customer>> Get() {
        return _interactors.GetAllCustomers();
    }

    [HttpPost]
    public async Task<string> Post([FromBody] Customer customer) {
        _logger.LogDebug("Get {Type}", GetType());
        var customerId = await _interactors.AddCustomer(customer);
        return $"Success. Id = {customerId}";
    }
}