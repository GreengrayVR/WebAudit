using System.ComponentModel.DataAnnotations;

namespace Web.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
    public class Url
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public ICollection<Check> Check { get; set; }
    }
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Url> URLS { get; set; }
    }
    public class Check
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CriticalLevel { get; set; }
    }

    public class ParserOptions
    {
        [Required]
        public string? URL { get; set; }
    }
}
