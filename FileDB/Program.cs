using FileDB.Broker.StorageBrokers;
using FileDB.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        FileStorageBroker broker = new FileStorageBroker();
        Student student = new Student()
        {
            Id = 1,
            Name = "Kamron",
            Field = "DIF",
        };
        broker.Add(student);
        // broker.Delete(student);
        Student student2 = new Student();
        student2.Id = 3;
        student2.Name = "Nodirbek";
        student2.Field = "KIF";
        broker.Update(student2);

    }
}