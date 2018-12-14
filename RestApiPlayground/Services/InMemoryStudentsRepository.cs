using System.Collections.Generic;
using System.Linq;

namespace RestApiPlayground.Services
{

    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>() {
            { 1, new Student {Id = 1, Lastname= "Bertschi", Firstname = "Corina", special = "hungrig" } },
            { 2, new Student {Id = 2, Lastname= "Ristic", Firstname = "Kristijan", special = "ergeizig" } },
            { 3, new Student {Id = 3, Lastname= "Fischer", Firstname = "Liz", special = "treibend" } },
            { 4, new Student {Id = 4, Lastname= "Kellenberger", Firstname = "Natalie", special = "nerdig" } },
        };

        public Student[] GetAll()
        {
            return studentDictionary.Select(element => element.Value).ToArray();
        }

        public Student Get(int id)
        {
            if (!studentDictionary.ContainsKey(id))
            {
                return null;
            }
            return studentDictionary[id];
        }

        public Student Add(Student student)
        {
            var newId = GetNextId();
            student.Id = newId;
            studentDictionary.Add(newId, student);
            return student;
        }

        public Student Update(Student student)
        {
            if (!studentDictionary.ContainsKey(student.Id))
            {
                return null;
            }
            studentDictionary[student.Id] = student;
            return student;
        }

        public bool Remove(int id)
        {
            if (!studentDictionary.ContainsKey(id))
            {
                return false;
            }
            studentDictionary.Remove(id);
            return true;
        }

        private int GetNextId()
        {
            return studentDictionary.Max((p) => p.Key) + 1;
        }
    }
}
