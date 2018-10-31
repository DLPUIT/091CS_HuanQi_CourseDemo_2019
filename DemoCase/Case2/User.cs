namespace Case2
{
    using SquirrelFramework.Domain.Model;

    [Collection("User")]
    public class User : DomainModel
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public bool Gender { get; set; }
        public string ReportTo { get; set; }
        public string GitHub { get; set; }
    }
}