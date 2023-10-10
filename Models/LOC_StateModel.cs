namespace AddEditDemo.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class Statedropdown
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
    }
}
