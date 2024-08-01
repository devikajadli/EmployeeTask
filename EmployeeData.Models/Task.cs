using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class Task
	{
    public int Id { get; set; }
    [Required]	
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } // Open, In Progress, Completed
    public int Priority { get; set; }
    public int AssignedUserId { get; set; }
    public User AssignedUser { get; set; }
    public List<Document> Documents { get; set; }
    public List<Note> Notes { get; set; }
    }
}
