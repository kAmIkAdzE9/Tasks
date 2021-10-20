namespace InternshipTest.Person
{
    class Student
    {
        string name;
        Knowledge knowledge;

        public string GetStudentName()
        {
            return name;
        }

        public void SetKnowledge(Knowledge knowledge)
        {
            this.knowledge = knowledge;
        }

        public Knowledge GetKnowledge()
        {
            return knowledge;
        }
        
        public Student(string name, Knowledge knowledge)
        {
            this.name = name;
            this.knowledge = knowledge;
        }
    }
}