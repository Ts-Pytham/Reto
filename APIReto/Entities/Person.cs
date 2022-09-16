namespace APIReto.Entities
{
    public class Person : Entity
    {
        public int DNI { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
