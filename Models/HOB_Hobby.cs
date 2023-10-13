namespace AddEditDemo.Models
{
    public class HOB_HobbyModel
    {
        public int HID { get; set; }
        public string? Hobby { get; set;}
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class HOB_HobbyDropdownModel
    {
        public int? HID { get; set; }
        public string? Hobby { get; set; }

    }
}
