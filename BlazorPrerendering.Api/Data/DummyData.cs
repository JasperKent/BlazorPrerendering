using BlazorPrerendering.Data.Models;

namespace BlazorPrerendering.Api.Data;

public class DummyData
{
    public static List<Book> Books { get; } =
    [
        new () { Title = "Emma", Year = 1816 },
        new () { Title = "Mansfield Park", Year = 1814 },
        new () { Title = "Dr No", Year = 1958 },
        new () { Title = "Goldfinger", Year = 1959 }
    ];

    public static List<Author> Authors { get; } =
    [
        new () { FirstName = "Jane", Surname = "Austen" },
        new () { FirstName = "Ian", Surname = "Fleming" }
    ];
}
