namespace Shkolo.Services.Subjects
{
    using Shkolo.Models.Subjects;
    using System.Collections.Generic;
    public interface ISubjectsService
    {
        public ICollection<SubjectFormModel> GetAllSubjects();
        public void AddSubject(SubjectFormModel student);
        public void Delete(int id);
        public SubjectFormModel FindById(int id);
        public void Edit(int id, SubjectFormModel subject);

    }
}
