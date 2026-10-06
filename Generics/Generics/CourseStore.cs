namespace RefactoringLab.Part03;

public class CourseStore
{
    private readonly List<Course> _courses = new();

    public void Add(Course course) => _courses.Add(course);

    public Course? GetById(int id) => _courses.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Course> GetAll() => _courses;

    public void Remove(int id)
    {
        var course = GetById(id);
        if (course != null) _courses.Remove(course);
    }
}