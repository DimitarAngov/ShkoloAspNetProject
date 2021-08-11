using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shkolo.Models.Grades
{
    public class GradeFormModel
    {
        public int GradeId { get; set; }
        
        [Required]
        [Range(1,2)]
        public int Term_Number { get; set; }
        
        [Required]
        public int StudentCourseId { get; set; }

        [Required]
        [MaxLength(4)]
        public string GradeStudents { get; set; }

        [Required]
        [Range(1,20)]
        public int TypeGradeId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public IEnumerable<StudentCourseModel> GStudentCourses { get; set; }
        public IEnumerable<TypeGradeModel> GTypeGrade { get; set; }
    }
}
