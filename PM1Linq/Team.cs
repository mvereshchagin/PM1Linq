namespace PM1Linq;

internal record Team(int Id, string Name, string Country, string City, decimal Price = 100);

internal record Player(int Id, string Name, string Country, int TeamId, decimal Price = 10);
