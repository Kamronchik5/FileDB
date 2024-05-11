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
        //broker.Add(student);
        // broker.Delete(student);
        Student student2 = new Student();
        List<Student> students = broker.ReadStudents();
        student2.Id = 3;
        student2.Name = "Nodirbek";
        student2.Field = "KIF";
        //broker.Update(student2);
        //broker.Read(students);
        Console.WriteLine("Select the desired function :");
        Console.WriteLine("1 - Add  2 - Delete 3 - Update 4- Read List ");
        string simple = Console.ReadLine();
        int func = Convert.ToInt32(simple);
        switch (func)
        {
            case 1:
                broker.Add(student);
                break;

            case 2:
                broker.Delete(student);
                break;

            case 3:
                broker.Update(student2);
                break ;

            case 4:
                broker.Read(students);
                break ;
        }
    }
}