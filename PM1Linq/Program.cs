using PM1Linq;

#region data
Team[] teams =
{
    new Team(Id: 0, Name: "Barcelona", Country: "Spain", City: "Barcelona", Price: 100),
    new Team(Id: 1, Name: "Real", Country: "Spain", City: "Madrid", Price: 100),
    new Team(Id: 2, Name: "Bayern", Country: "Germany", City: "Munich", Price: 100),
    new Team(Id: 3, Name: "Borussia", Country: "Germany", City: "Dortmund", Price: 100),
    new Team(Id: 4, Name: "Schalke 04", Country: "Germany", City: "Gelsenkirchen", Price: 100),
    new Team(Id: 5, Name: "Baltika", Country: "Russia", City: "Kaliningrad", Price: 100),
    new Team(Id: 6, Name: "Spartak", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 7, Name: "Zenit", Country: "Russia", City: "Saint-Petersburg", Price: 100),
    new Team(Id: 8, Name: "Manchester United", Country: "England", City: "Manchester", Price: 100),
    new Team(Id: 9, Name: "Manchester City", Country: "England", City: "Manchester", Price: 100),
    new Team(Id: 10, Name: "Chelsea", Country: "England", City: "London", Price: 100),
    new Team(Id: 11, Name: "Arsenal", Country: "England", City: "London", Price: 100),
    new Team(Id: 12, Name: "Totenham", Country: "England", City: "London", Price: 100),
    new Team(Id: 13, Name: "West Ham", Country: "England", City: "London", Price: 100),
    new Team(Id: 14, Name: "Lokomotiv", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 15, Name: "CSKA", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 16, Name: "Dinamo", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 17, Name: "Dinamo", Country: "Ukraine", City: "Kiev", Price: 100),
    new Team(Id: 18, Name: "Dinamo", Country: "Belarus", City: "Minsk", Price: 100),
    new Team(Id: 19, Name: "Dinamo", Country: "Croatia", City: "Zagreb", Price: 100),
};

Player[] players =
{
    new Player(Id: 10, Name: "Messi", Country: "Argentina", Price: 1000, TeamId: 1),
    new Player(Id: 1, Name: "Cristiano Ronaldo", Country: "Protugal", Price: 800, TeamId: 5),
    new Player(Id: 2, Name: "Luca Modric", Country: "Croatia", Price: 700, TeamId: 0),
    new Player(Id: 3, Name: "Dzyuba", Country: "Russia", Price: 3000, TeamId: 10),
    new Player(Id: 4, Name: "Mbappe", Country: "France", Price: 900, TeamId: 3),
    new Player(Id: 5, Name: "Van der sar", Country: "Netherlands", Price: 100, TeamId: 15),
    new Player(Id: 6, Name: "Maradonna", Country: "Argentina", Price: 0, TeamId: 5),
    new Player(Id: 7, Name: "Pirogov", Country: "Russia", Price: 50, TeamId: 5),
    new Player(Id: 8, Name: "Zidane", Country: "France", Price: 600, TeamId: 1),
    new Player(Id: 9, Name: "Ronaldo", Country: "Brasil", Price: 500, TeamId: 5),
    new Player(Id: 11, Name: "Ignashevich", Country: "Russia", Price: 800, TeamId: 5),
    new Player(Id: 12, Name: "Onopko", Country: "Russia", Price: 500, TeamId: 0),
    new Player(Id: 13, Name: "Grizman", Country: "France", Price: 500, TeamId: 1),
    new Player(Id: 14, Name: "Akinfeev", Country: "Russia", Price: 20, TeamId: 5),
    new Player(Id: 15, Name: "Yashin", Country: "Russia", Price: 7000, TeamId: 0),
};

Team[] teams2 =
{
    new Team(Id: 0, Name: "Bayern", Country: "Germany", City: "Munich", Price: 100),
    new Team(Id: 0, Name: "Borussia", Country: "Germany", City: "Dortmund", Price: 100),
    new Team(Id: 0, Name: "Schalke 04", Country: "Germany", City: "Gelsenkirchen", Price: 100),
    new Team(Id: 0, Name: "Baltika", Country: "Russia", City: "Kaliningrad", Price: 100),
    new Team(Id: 0, Name: "Spartak", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 0, Name: "Zenit", Country: "Russia", City: "Saint-Petersburg", Price: 100),
    new Team(Id: 0, Name: "Arsenal", Country: "England", City: "London", Price: 100),
    new Team(Id: 0, Name: "West Ham", Country: "England", City: "London", Price: 100),
    new Team(Id: 0, Name: "Lokomotiv", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 0, Name: "CSKA", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 0, Name: "Dinamo", Country: "Russia", City: "Moscow", Price: 100),
    new Team(Id: 0, Name: "Dinamo", Country: "Ukraine", City: "Kiev", Price: 100),
    new Team(Id: 0, Name: "Dinamo", Country: "Russia", City: "Barnaul", Price: 100),
    new Team(Id: 0, Name: "Dinamo", Country: "Russia", City: "Mahachkala", Price: 100),
    new Team(Id: 0, Name: "Leister", Country: "England", City: "Leister"),
    new Team(Id: 0, Name: "Ajax", Country: "Netherlands", City: "Amsterdam"),
    new Team(Id: 0, Name: "Liverpool", Country: "England", City: "Liverpool"),
    new Team(Id: 0, Name: "Eintracht", Country: "Germany", City: "Frankfurt"),
    new Team(Id: 0, Name: "Crvena Zvazda", Country: "Serbia", City: "Belgrad"),
};
#endregion

#region auxiliary functions
void FilterAndPrint(string caption, Func<IEnumerable<Team>, IEnumerable<object>> filter)
{
    var resTeams = filter(teams);

    Console.WriteLine("");
    Console.WriteLine("===============================");
    Console.WriteLine(caption);
    Console.WriteLine("===============================");

    foreach (var team in resTeams)
        Console.WriteLine(team);
}
#endregion

#region queries

FilterAndPrint("Classic filter and sort", (teams) =>
{
    List<Team> resTeams = new List<Team>();
    foreach (var team in teams)
    {
        if (team.City == "London")
            resTeams.Add(team);
    }
    resTeams.Sort((team1, team2) =>
    {
        return team1.Name.CompareTo(team2.Name);
    });

    return resTeams;
});

FilterAndPrint("LINQ filter and sort", (teams) =>
{
    return
        from team in teams
            // where team.City is "London" && team.Country is "England"
        where team is (_, _, _, "London", _)
        orderby team.Name, team.Country descending
        select team;
});

FilterAndPrint("LINQ functional filter and sort", (teams) =>
{
    return teams.Where(x => x.City == "London").OrderBy(x => x.Name);
});

FilterAndPrint("LINQ filter and sort all dinamos", (teams) =>
{
    return
        from team in teams
        where team.Name is "Dinamo"
        orderby team.Country ascending, team.City ascending
        select team;
});

FilterAndPrint("LINQ Property", (teams) =>
{
    return
        from team in teams
        select team.Name;
});

FilterAndPrint("LINQ Projection", (teams) =>
{
    return
        from team in teams
        select new
        {
            TeamName = team.Name,
            Place = $"{team.City}, {team.Country}",
        };
});

FilterAndPrint("LINQ new var", (teams) =>
{
    return
        from team in teams
        let place = $"{team.City}, {team.Country}"
        select new
        {
            TeamName = team.Name,
            Place = place,
        };
});

FilterAndPrint("LINQ intersect", (teams) =>
{
    return teams.Intersect(teams2);
});

FilterAndPrint("LINQ Union", (teams) =>
{
    return teams.Union(teams2);
});

FilterAndPrint("LINQ Except", (teams) =>
{
    return teams.Except(teams2);
});

FilterAndPrint("LINQ pagination 0", (teams) => GetTeamsByPageNumber(0));
FilterAndPrint("LINQ pagination 1", (teams) => GetTeamsByPageNumber(1));

Team? FinById(int id)
{
    return (
        from team in teams
        where team.Id == id
        select team
        )
        // .Single(); возращает единственны элемент коллекции. Если коллекия пуста => исключение.
        // Если в коллекции > 1 элемента => тоже исключение
        .SingleOrDefault(); 
        // .First();
        // .FirstOrDefault();
}

IEnumerable<Team> GetTeamsByPageNumber(int pageNumber, int itemsOnPage = 10)
{
    return teams.Skip(pageNumber * itemsOnPage).Take(itemsOnPage);
}

AggregateFunctions();

void AggregateFunctions()
{
    int count = teams.Count();
    var sum = teams.Sum(x => x.Price);
    var avg = teams.Average(x => x.Price);
    var max = teams.Max(x => x.Id);
    var min = teams.Min(x => x.Id);

    int[] numbers = { 2, 4, 6, 7, 9};

    var multiply = numbers.Aggregate((x, y) => x * y);

    Console.WriteLine($"count = {count}; sum = {sum}; avg = {avg}; max = {max}; min = {min}; multiply = {multiply}");

    var names = teams
        .Select(x => x.Name)
        .Aggregate((x, y) => $"{x}, {y}");
    Console.WriteLine(names);
}

FilterAndPrint("LINQ grouping", (teams) =>
{
    return
        from team in teams
        group team by team.Country into g
        let countyName = g.Key
        orderby countyName
        select new
        {
            County = countyName,
            Names = g.Select(x => x.Name).Aggregate((x, y) => $"{x}, {y}"),
            TotalPrice = g.Select(x => x.Price).Sum(),
            Ids = g.Select(x => x.Id.ToString()).Aggregate((x, y) => $"{x}, {y}")
        };
});

FilterAndPrint("LINQ grouping with embed query", (teams) =>
{
    return
        from team in teams
        group team by team.Country into g
        let countyName = g.Key
        orderby countyName
        select new
        {
            County = countyName,
            Names = (from t in g select t.Name).Aggregate((x, y) => $"{x}, {y}"),
            TotalPrice = g.Select(x => x.Price).Sum(),
            Ids = from t in g select t.Id,
        };
});

FilterAndPrint("join", (teams) =>
{
    return
        from team in teams
        join player in players on team.Id equals player.Id
        select new
        {
            Team = team.Name,
            Name = player.Name,
        };
});

void Test()
{
    var filteredTeams =
        (from team in teams
        where team.Country is "Russia"
        select team).ToList();

    
}

#endregion





