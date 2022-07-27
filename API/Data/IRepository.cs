using API.Models;

namespace API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        public Aluno[] GetAllAlunos(bool includeProfessores = false);
        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessores = false);
        public Aluno GetAlunoById(int alunoId, bool includeProfessores = false);
        public Professor[] GetAllProfessores(bool includeAlunos = false);
        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        public Professor GetProfessorById(int professsorId, bool includeAlunos = false);
    }
}