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
        public void AddSubject(SubjectFormModel subject)
        {
            var subjectData = new Subject
            {
                Name = subject.Name,
            };

            db.Subjects.Add(subjectData);
            db.SaveChanges();
        }
        public ICollection<SubjectFormModel> GetAllSubjects()
        {
            var subjects = this.db
            .Subjects
            .OrderBy(x => x.SubjectId)
            .Select(x => new SubjectFormModel
            {
                SubjectId = x.SubjectId,
                Name = x.Name,
            }).ToList();

            return subjects;
        }
        public void Delete(int id)
        {
            var SubjectDel = this.db.Subjects.FirstOrDefault(x => x.SubjectId == id);
            this.db.Subjects.Remove(SubjectDel);
            db.SaveChanges();
        }

        public SubjectFormModel FindById(int id)
         => this.db
                    .Subjects
                    .Where(x => x.SubjectId == id)
                    .Select(x => new SubjectFormModel
                    {
                        SubjectId = x.SubjectId,
                        Name = x.Name
                    })
                    .FirstOrDefault();

        public void Edit(int id, SubjectFormModel subject)
        {
            var subjectData = new Subject
            {
                SubjectId = id,
                Name = subject.Name,
            };

            db.Subjects.Update(subjectData);
            db.SaveChanges();
        }
    }
}
