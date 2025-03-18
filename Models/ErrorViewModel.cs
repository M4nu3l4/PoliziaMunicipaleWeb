using System.ComponentModel.DataAnnotations;

public class ErrorViewModel
{
    [Key]
    public int Id { get; set; }

    public required string RequestId { get; set; }

    
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
