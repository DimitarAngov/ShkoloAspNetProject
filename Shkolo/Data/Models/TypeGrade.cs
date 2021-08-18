namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TypeGrade;

    public class TypeGrade
    {
        public TypeGrade()
        {
            this.Grades = new HashSet<Grade>();
        }
        public int TypeGradeId { get; set; }
       
        [Required]
        [MaxLength(TypeGradeNameMaxLength)]
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
