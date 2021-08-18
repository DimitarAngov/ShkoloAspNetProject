namespace Shkolo.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using static Data.DataConstants.Student;
    public class AddStudentFormModel
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
            [MinLength(StudentMinLength)]
            [MaxLength(StudentMaxLength)]
            public int NumInClass { get; set; }

            [Required]
            [MinLength(StudentMinLength)]
            [MaxLength(StudentMaxLength)]

            [Display(Name="Diary")]
            public string DiaryId { get; set; }

            [Required]
            [MinLength(StudentMinLength)]
            [MaxLength(StudentMaxLength)]
            
            [Display(Name = "Parent")]
            public string ParentId { get; set; }
            
            [Required]
            [MinLength(StudentMinLength)]
            [MaxLength(StudentMaxLength)]

            [Display(Name = "Doctor")]
            public string DoctorId { get; set; }

            public IEnumerable<StudentDiaryModel> SDiaries { get; set; }
            public IEnumerable<StudentParentModel> SParents { get; set; }
            public IEnumerable<StudentDoctorModel> SDoctors { get; set; }

    }
}
