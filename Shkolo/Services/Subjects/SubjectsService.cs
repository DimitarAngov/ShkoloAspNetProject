namespace Shkolo.Services.Subjects
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Subjects;
    using System.Collections.Generic;
    using System.Linq;

    public class SubjectsService : ISubjectsService
    {
        private readonly ShkoloDbContext db;
        public SubjectsService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddSubject(AddSubjectFormModel subject)
        {
            var subjectData = new Subject
            {
                Name = subject.Name,
            };

            db.Subjects.Add(subjectData);
            db.SaveChanges();
        }
        public ICollection<AddSubjectFormModel> GetAllSubjects()
        {
            var subjects = this.db
            .Subjects
            .OrderBy(x => x.SubjectId)
            .Select(x => new AddSubjectFormModel
            {
                SubjectId = x.SubjectId,
                Name = x.Name,
            }).ToList();

            return subjects;
        }
    }
}
