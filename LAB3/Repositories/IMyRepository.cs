using NLab3.Models;

namespace NLab3.Repositories;

public interface IMyRepository
{
    void DbSave(List<Operation> operations);
    List<Operation> DbLoad();
    void JsonSave(List<Operation> operations);
    List<Operation> JsonLoad();
}
