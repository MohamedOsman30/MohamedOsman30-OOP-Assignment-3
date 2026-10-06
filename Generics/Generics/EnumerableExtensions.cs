namespace RefactoringLab.Part03;

public static class EnumerableExtensions
{
    // R1: Page method
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            throw new ArgumentException("Page number and page size must be greater than zero.");

        int skipCount = (pageNumber - 1) * pageSize;
        int currentCount = 0;

        foreach (var item in source)
        {
            if (currentCount >= skipCount && currentCount < skipCount + pageSize)
            {
                yield return item;
            }
            currentCount++;

            if (currentCount >= skipCount + pageSize)
                break;
        }
    }

    // R2: FindById method
    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        foreach (var item in source)
        {
            if (item.Id == id)
                return item;
        }
        return default;
    }

    // R3: ToIdDictionary method
    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        var dictionary = new Dictionary<int, T>();
        foreach (var item in source)
        {
            dictionary[item.Id] = item;
        }
        return dictionary;
    }
}