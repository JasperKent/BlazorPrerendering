using BlazorPrerendering.Client.Models;

namespace BlazorPrerendering.Data;

public class DummyData
{
    public static List<Book> Books { get; } =
    [
        new () {Id = 1, Title = "Emma", Year = 1816 },
        new () {Id = 2, Title = "Mansfield Park", Year = 1814 },
        new () {Id = 3, Title = "Dr No", Year = 1958 },
        new () {Id = 4, Title = "Goldfinger", Year = 1959 }
    ];
}
