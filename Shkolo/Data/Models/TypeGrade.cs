namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TypeGrade
    {
        public TypeGrade()
        {
            this.Grades = new HashSet<Grade>();
        }
        public int TypeGradeId { get; set; }
       
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
