using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using testcontainerexample.providers;

namespace testcontainerexample.tests;

[TestFixture]
public class CustomerControllerTests : IntegrationTestsBase
{
    private WebApplicationFactory<Program> _webAppFactory;
    private HttpClient _httpClient;

    [SetUp]
    public void Setup2() {
        _webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = _webAppFactory.CreateDefaultClient();
    }
    
    [Test]
    public async Task Get_all_on_empty_database_returns_empty_result() {
        var response = await _httpClient.GetAsync("customer");
        var stringResult = await response.Content.ReadAsStringAsync();

        Assert.That(stringResult, Is.EqualTo("[]"));
    }

    [Test]
    public async Task Customers_can_be_added_to_database() {
        var content = JsonConvert.SerializeObject(TestData.Customers.Customer1);
        var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("customer", stringContent);
        var stringResult = await response.Content.ReadAsStringAsync();

        Assert.That(stringResult, Is.EqualTo("Success. Id = 0001"));
    }

    [Test]
    public async Task Added_customers_can_be_retrieved() {
        var customerProvider = new CustomerProvider();
        await customerProvider.Add(TestData.Customers.Customer1);
        await customerProvider.Add(TestData.Customers.Customer2);

        var response = await _httpClient.GetAsync("customer");
        var stringResult = await response.Content.ReadAsStringAsync();

        Assert.That(stringResult, Is.EqualTo("[{\"id\":\"0001\",\"name\":\"Peter\"},{\"id\":\"0002\",\"name\":\"Paul\"}]"));
    }
}