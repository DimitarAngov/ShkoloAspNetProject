namespace Shkolo.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddStudentFormModel
    {
            public int StudentId { get; set; }
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }

            [Required]
            [MinLength(10)]
            [MaxLength(10)]
            public string DateOfBirth { get; set; }

            [Required]
            [MaxLength(20)]
            public string PlaceOfBirth { get; set; }

            [Required]
            [MaxLength(100)]
            public string Address { get; set; }
           
            [Required]
            [MinLength(13)]
            [MaxLength(13)]
            public string Phone { get; set; }
            
            [Required]
            [MinLength(1)]
            [MaxLength(2)]
            public int NumInClass { get; set; }

            [Required]
            [MinLength(1)]
            [MaxLength(2)]

            [Display(Name="Diary")]
            public string DiaryId { get; set; }

            [Required]
            [MinLength(1)]
            [MaxLength(2)]
            
            [Display(Name = "Parent")]
            public string ParentId { get; set; }
            
            [Required]
            [MinLength(1)]
            [MaxLength(2)]

            [Display(Name = "Doctor")]
            public string DoctorId { get; set; }

            public IEnumerable<StudentDiaryModel> SDiaries { get; set; }
            public IEnumerable<StudentParentModel> SParents { get; set; }
            public IEnumerable<StudentDoctorModel> SDoctors { get; set; }

    }
}
