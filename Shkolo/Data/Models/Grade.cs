namespace Shkolo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Grade
    {
        public int GradeId { get; set; }

        [Required]
        [Range(1,2)]
        public int Term_Number { get; set; }
        
        [Required]
        public int StudentCourseId { get; set; }

         public StudentCourse StudentCourse { get; set; }

        [Required]
        [MaxLength(4)]
        public string GradeStudents { get; set; }

        [Required]
        [Range(1,20)]
        public int TypeGradeId { get; set; }
        public TypeGrade TypeGrade { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }

}
