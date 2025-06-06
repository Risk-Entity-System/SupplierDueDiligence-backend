using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Domain.Models;

public class ScreeningSource
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public bool Enable { get; set; }
    public ScreeningSourceCode Code { get; set; } = default!;
}
