using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace testcontainerexample.tests;

public class IntegrationTestsBase
{
    protected MongoDbTestcontainer _testcontainers;

    [SetUp]
    public async Task Setup() {
        var testcontainersBuilder = new TestcontainersBuilder<MongoDbTestcontainer>()
            .WithImage("mongo")
            .WithPortBinding(27017);

        _testcontainers = testcontainersBuilder.Build();
        await _testcontainers.StartAsync();
    }

    [TearDown]
    public async Task Teardown() {
        await _testcontainers.StopAsync();
    }
}