namespace RefactoringLab.Part03;

public class StudentStore
{
    private readonly List<Student> _students = new();

    public void Add(Student student) => _students.Add(student);

    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    public IEnumerable<Student> GetAll() => _students;

    public void Remove(int id)
    {
        var student = GetById(id);
        if (student != null) _students.Remove(student);
    }
}