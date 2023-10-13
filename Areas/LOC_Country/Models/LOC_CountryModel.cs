﻿namespace AddEditDemo.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int StateCount { get; set; }
        public int CityCount { get; set; }
    }
    public class Countrydropdown
    {
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
