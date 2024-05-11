using FileDB.Models;
using System.Text.RegularExpressions;

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
        public List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { Id=1,Field="DIF",Name="Kamron"});
            students.Add(new Student() { Id=2,Field="DIF",Name="Azizbek"});
            students.Add(new Student() { Id=3,Field="KIF",Name="Nodirbek"});

            return students;
        }

        public void Read(List<Student> students)
        {
            foreach (var item in students)
            {
               Console.WriteLine(item.Id+" "+item.Name+" "+item.Field);
            }

        }
        public List<Student> Get(Student student)
        {
            return new List<Student>();
        }

        public Student Update(Student newstudent)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The 'path' variable cannot be null or empty.");
            }

            try
            {
                // Read the existing student data
                string readstr = File.ReadAllText(path);

                // Efficiently update student data using string manipulation
                string updatedLine = FindAndReplaceStudentData(readstr, newstudent);

                // Only write if the data actually changed
                if (updatedLine != readstr)
                {
                    File.WriteAllText(path, updatedLine);
                }

                return newstudent;
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception($"File not found: {path}", ex); // Provide user-friendly error message
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student data: {ex.Message}"); // Generic error handling
            }
        }
        private string FindAndReplaceStudentData(string data, Student newstudent)
        {
            // Regular expression for matching student data (consider error handling)
            string pattern = @"(\d+)\*(.+?)\*(\w+)";
            Match match = Regex.Match(data, pattern);

            if (match.Success)
            {
                // Construct the updated line with proper formatting
                return $"{newstudent.Id}*{newstudent.Name}*{newstudent.Field}";
            }
            else
            {
                // Handle case where student data not found in the file (optional)
                // Consider logging or returning an indication (e.g., null)
                return data; // Or throw an exception if expected
            }
        }
    }
}
