using Newtonsoft.Json;
using NLab3.Database;
using NLab3.Models;

namespace NLab3.Repositories;

public class MyRepository:IMyRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "calendar.json");

    private readonly MyContext _context = new ();

    public MyRepository()
    {
        _context.Database.EnsureCreated();
    }
    public void DbSave(List<Operation> operations)
    {
        _context.Operations?.RemoveRange(_context.Operations);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Operations?.AddRange(operations);
        _context.SaveChanges();
    }

    public List<Operation> DbLoad()
    {
        return _context.Operations!.ToList();
    }

    public void JsonSave(List<Operation> operations)
    {
        var jsonData = JsonConvert.SerializeObject(operations, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<Operation> JsonLoad()
    {
        var temp = new List<Operation>();
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<Operation>>(jsonData) ??
                   new List<Operation>();
        foreach (var operation in data)
        {
            temp.Add(new Operation
            {
                Name = operation.Name,
                Result = operation.Result
            });
        }

        return temp;
    }
}
