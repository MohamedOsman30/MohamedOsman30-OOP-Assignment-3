using RefactoringLab.Part03;


var studentStore = new Store<Student>();
studentStore.Add(new Student { Id = 1, Name = "Ahmed" });
studentStore.Add(new Student { Id = 2, Name = "Mohamed" });
studentStore.Add(new Student { Id = 3, Name = "Ali" });
studentStore.Add(new Student { Id = 4, Name = "Omar" });
studentStore.Add(new Student { Id = 5, Name = "Hassan" });

var courseStore = new Store<Course>();
courseStore.Add(new Course { Id = 101, Title = "C# Basics", Price = 100m });
courseStore.Add(new Course { Id = 102, Title = "Advanced .NET", Price = 200m });
courseStore.Add(new Course { Id = 103, Title = "Web Security", Price = 150m });

var fetchedStudent = studentStore.GetById(2);
var fetchedCourse = courseStore.GetById(102);
Console.WriteLine($"Found Student: {fetchedStudent?.Name}");
Console.WriteLine($"Found Course: {fetchedCourse?.Title}");
Console.WriteLine();


try
{
    studentStore.Add(new Student { Id = 1, Name = "Duplicate Ahmed" });
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Expected Exception: {ex.Message}");
}
Console.WriteLine();


Console.WriteLine("=== Students Page 2 (Size 2) ====");
var page2Students = studentStore.GetAll().Page(2, 2);
foreach (var s in page2Students)
{
    Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
}

var plainList = new List<Student>
{
    new() { Id = 10, Name = "Test 10" },
    new() { Id = 20, Name = "Test 20" }
};
var foundPlain = plainList.FindById(20);
Console.WriteLine($"Found from plain list: {foundPlain?.Name}");

