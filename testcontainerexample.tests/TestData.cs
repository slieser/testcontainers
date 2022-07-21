using testcontainerexample.contracts;

namespace testcontainerexample.tests;

public static class TestData
{
    public static class Customers
    {
        public static Customer Customer1 => new("0001", "Peter");

        public static Customer Customer2 => new("0002", "Paul");
    }
}