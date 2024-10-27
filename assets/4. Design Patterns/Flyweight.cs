public class TreeType
{
    private string _name;
    
    public TreeType(string name)
    {
        _name = name;
    }

    public void Display() => Console.WriteLine($"Tree type: {_name}");
}

public class TreeFactory
{
    private Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

    public TreeType GetTreeType(string name)
    {
        if (!_treeTypes.ContainsKey(name))
            _treeTypes[name] = new TreeType(name);
        return _treeTypes[name];
    }
}