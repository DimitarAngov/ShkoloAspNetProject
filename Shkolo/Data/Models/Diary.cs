namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Diary
    {        
        public int DiaryId { get; set; }
        public string SchoolName { get; set; }
        public int NumberClassName { get; set; }
       
        [Required]
        [MaxLength(1)]
        public string ClassName { get; set; }

        //[DisplayName("ClassTeacher")] 
        public int TeacherId{ get; set; }
        public Teacher Teacher { get; set; }
        public string SchoolYear { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
