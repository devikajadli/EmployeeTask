vfusing System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class User
 {
    public int Id { get; set; }
    [Required]	
    public string Name { get; set; }
    public string Role { get; set; } // Admin, Manager, Employee
    public List<Task> AssignedTasks { get; set; }
}

}
