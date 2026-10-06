namespace RefactoringLab.Part03;

public class Student : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}