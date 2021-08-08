namespace Shkolo.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class StudentFormModel
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
            [Range(1,100)]
            public int NumInClass { get; set; }

            [Required]
            [Range(1, 12)]

            [Display(Name="Diary")]
            public int DiaryId { get; set; }

            [Required]
            [Range(1, 100)]

        [Display(Name = "Parent")]
            public int ParentId { get; set; }
            
            [Required]
            [Range(1, 100)]

        [Display(Name = "Doctor")]
            public int DoctorId { get; set; }

            public IEnumerable<StudentDiaryModel> SDiaries { get; set; }
            public IEnumerable<StudentParentModel> SParents { get; set; }
            public IEnumerable<StudentDoctorModel> SDoctors { get; set; }

    }
}
