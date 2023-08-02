## [C# Collection Types][30]

### Passing collections into methods (Arguments)
- Use `IEnumerable<T>` where possible
- Use `IReadOnlyCollection<T>` or `IReadOnlyList` for in-memory lists (e.g. multiple iterations)

### Returning collections from methods
- For in-memory lists use `IReadOnlyList` or `IReadOnlyCollection<T>`
    - Use the `AsReadOnly()` extension method for the `ReadOnlyCollection<T>` wrapper
- To allow partial enumerations use `IEnumerable<T>`


[30]:https://markheath.net/post/passing-collections-csharp