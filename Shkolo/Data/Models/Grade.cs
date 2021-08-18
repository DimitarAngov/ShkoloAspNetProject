namespace Shkolo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Grade;

    public class Grade
    {
        public int GradeId { get; set; }

        [Required]
        [Range(TermNumberMin, TermNumberMax)]
        public int Term_Number { get; set; }
        
        [Required]
        public int StudentCourseId { get; set; }

         public StudentCourse StudentCourse { get; set; }

        [Required]
        [MaxLength(GradeStudentsMaxLength)]
        public string GradeStudents { get; set; }

        [Required]
        [Range(TypeGradeIdMin, TypeGradeIdMax)]
        public int TypeGradeId { get; set; }
        public TypeGrade TypeGrade { get; set; }

        [Required]
        [MaxLength(DateMax)]
        public string Date { get; set; }

        [MaxLength(GradeDescriptionMaxLength)]
        public string Description { get; set; }
    }

}
