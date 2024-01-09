using NLab4.Models;

namespace NLab4.Repositories;

public interface IMyRepository
{
    Task<bool> Check(int year);
    Task<int> Calc(DateTime first, DateTime second);
    Task<string> Day(DateTime dateTime);
    Task<List<Operation>> ShowOperations();
    Task Add(Operation operation);
}
