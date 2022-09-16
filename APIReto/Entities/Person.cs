namespace APIReto.Entities
{
    public class Person : Entity
    {
        public int DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
