namespace RestApiPlayground.Services
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        Student Get(int id);
        Student[] GetAll();
        bool Remove(int id);
        Student Update(Student student);
    }
}