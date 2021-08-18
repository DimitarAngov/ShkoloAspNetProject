namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Diary;

    public class Diary
    {        
        public int DiaryId { get; set; }
        public string SchoolName { get; set; }
        
        [Range(NumInClassMin, NumInClassMax)]
        public int NumberClassName { get; set; }
       
        [Required]
        [MaxLength(DiaryClassNameMaxLength)]
        public string ClassName { get; set; }

        [DisplayName("ClassTeacher")] 
        public int TeacherId{ get; set; }
        public Teacher Teacher { get; set; }
        public string SchoolYear { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
