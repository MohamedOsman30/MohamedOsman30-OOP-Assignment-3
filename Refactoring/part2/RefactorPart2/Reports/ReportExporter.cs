namespace RefactoringLab.Part02.Reports;

public abstract class ReportExporter
{
    public void Export(string path)
    {
        var rows = Load();
        if (!Validate(rows))
            throw new InvalidOperationException("Invalid data");
        var content = Format(rows);
        Save(path, content);
    }

    protected virtual List<string[]> Load() =>
    [
        ["Id", "Name"],
        ["1", "Keyboard"],
        ["2", "Mouse"]
    ];

    protected virtual bool Validate(List<string[]> rows) =>
        rows.Count > 1 && rows[0].Length > 0;

    protected abstract string Format(List<string[]> rows);

    protected virtual void Save(string path, string content) =>
        File.WriteAllText(path, content);
}