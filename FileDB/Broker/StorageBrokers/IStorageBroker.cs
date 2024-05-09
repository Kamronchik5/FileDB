using FileDB.Models;

namespace FileDB.Broker.StorageBrokers
{
    internal interface IStorageBroker
    {
        Student Add(Student student);
        Student Update(Student newstudent);
        Student Delete(Student student);
        List <Student> Get(Student student);   
    }
}
