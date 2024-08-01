using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
{
    public int Id { get; set; }
    [Required]		
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
}

}
