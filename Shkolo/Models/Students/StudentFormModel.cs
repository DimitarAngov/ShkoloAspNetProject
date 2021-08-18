namespace Shkolo.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using static Data.DataConstants.Student;
    using static Data.DataConstants.Diary;
    public class StudentFormModel
    {
            public int StudentId { get; set; }
            [Required]
            [MaxLength(NameMaxLength)]
            public string Name { get; set; }

            [Required]
            [MinLength(DateMin)]
            [MaxLength(DateMax)]
            public string DateOfBirth { get; set; }

            [Required]
            [MaxLength(StudentPlaceOfBirthMax)]
            public string PlaceOfBirth { get; set; }

            [Required]
            [MaxLength(AdressMaxLength)]
            public string Address { get; set; }
           
            [Required]
            [MinLength(PhoneNumberMinLength)]
            [MaxLength(PhoneNumberMaxLength)]
            public string Phone { get; set; }
            
            [Required]
            [Range(NumInClassMin, NumInClassMax)]
            public int NumInClass { get; set; }

            [Required]
            [Range(DiaryIdMin, DiaryIdMax)]

            [Display(Name="Diary")]
            public int DiaryId { get; set; }

            [Required]
            [Range(DiaryParentIdMin, DiaryParentIdMax)]

            [Display(Name = "Parent")]
            public int ParentId { get; set; }
            
            [Required]
            [Range(DiaryDoctorIdMin, DiaryDoctorIdMax)]

            [Display(Name = "Doctor")]
            public int DoctorId { get; set; }

            public IEnumerable<StudentDiaryModel> SDiaries { get; set; }
            public IEnumerable<StudentParentModel> SParents { get; set; }
            public IEnumerable<StudentDoctorModel> SDoctors { get; set; }

    }
}
