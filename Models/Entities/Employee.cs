using System.ComponentModel.DataAnnotations;

namespace CRUD_OPERATION_UI.Models.Entities
{
  public class Employee
{
    public int ID { get; set; }
        [Required(ErrorMessage = "Employee Name is required.")]
        [RegularExpression(@"^[a-zA-Z.]*$", ErrorMessage = "Only letters and periods are allowed.")]

    public string EmployeeName { get; set; }
    public string Designation { get; set; }
    public string Post { get; set; }
    public string Place { get; set; }
    public string Phone { get; set; }
}

}
