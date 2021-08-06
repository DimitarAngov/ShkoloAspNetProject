namespace Shkolo.Services.Subjects
{
    using Shkolo.Models.Subjects;
    using System.Collections.Generic;
    public interface ISubjectsService
    {
        public ICollection<AddSubjectFormModel> GetAllSubjects();
        public void AddSubject(AddSubjectFormModel student);
      
    }
}
