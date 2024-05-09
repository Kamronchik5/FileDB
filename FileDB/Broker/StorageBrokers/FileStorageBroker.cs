using FileDB.Models;

namespace FileDB.Broker.StorageBrokers
{
    internal class FileStorageBroker : IStorageBroker
    {
        private string path = "C:/Users/Kamronbek/source/repos/FileDB/FileDB/Assests/database.txt";
        public FileStorageBroker()
        {   
            if(File.Exists(path) == false)
            {
                File.Create(path).Close();
            }
        }
        public Student Add(Student student)
        {
            string studnetString = $"{student.Id}*{student.Name}*{student.Field}";
            File.WriteAllText(path, studnetString);
            return student;
        }

        public Student Delete(Student student)
        {
            File.Delete(path);
            return student;
        }

        public List<Student> Get(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student newstudent)
        {
            string Newstudnet = $"{newstudent.Id}*{newstudent.Name}*{newstudent.Field}";
            File.AppendAllText(path, Newstudnet);
            return newstudent;
        }
    }
}
