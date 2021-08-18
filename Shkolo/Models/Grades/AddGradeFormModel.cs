namespace Shkolo.Models.Grades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using static Data.DataConstants.Grade;
    public class AddGradeFormModel
    {
        public int GradeId { get; set; }
        
        [Required]
        [Range(TermNumberMin, TermNumberMax)]
        public int Term_Number { get; set; }
        
        [Required]
        public int StudentCourseId { get; set; }

        [Required]
        [MaxLength(GradeStudentsMaxLength)]
        public string GradeStudents { get; set; }

        [Required]
        [Range(TypeGradeIdMin, TypeGradeIdMax)]
        public int TypeGradeId { get; set; }

        [Required]
        [MaxLength(DateMax)]
        public string Date { get; set; }

        [MaxLength(GradeDescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<StudentCourseModel> GStudentCourses { get; set; }
        public IEnumerable<TypeGradeModel> GTypeGrade { get; set; }
    }
}
