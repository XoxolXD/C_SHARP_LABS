using System.ComponentModel.DataAnnotations;

namespace NLab3.Models;

public class Operation
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Result { get; set; }
}
