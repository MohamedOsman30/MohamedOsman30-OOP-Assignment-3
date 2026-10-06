namespace RefactoringLab.Part03;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"Item with Id {item.Id} already exists.");
        }
        _items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        return _items.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items.Values.ToList().AsReadOnly();
    }

    public void Remove(int id)
    {
        _items.Remove(id);
    }
}