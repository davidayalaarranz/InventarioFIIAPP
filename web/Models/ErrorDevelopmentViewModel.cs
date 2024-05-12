namespace InventarioFIIAPP.Models;

public class ErrorDevelopmentViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
