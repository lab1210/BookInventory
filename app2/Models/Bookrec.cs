using System;
using System.ComponentModel.DataAnnotations;

namespace app2.Models
{
    public class Bookrec
    {
        public int id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$",ErrorMessage ="Title Should begin with a Capital Letter and contain only letters")]

        public string Title { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$",ErrorMessage ="Names should begin with a capital letter and contain only letters")]
        public string Author { get; set; }
        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN should contain 13 digits")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="ISBN should contain only digits")]
        public string ISBN { get; set; }
        public DateTime? Creation { get; set; }
        [Range(1,double.PositiveInfinity, ErrorMessage ="Page number muse be above '0'")]

        public int PageNo { get; set; }
        [StringLength(12, MinimumLength = 12, ErrorMessage = "BarCode should contain 12 digits")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="A barcode should contain only digits")]

        public string BarCode { get; set; }
        [Display(Name = "Date Of Publication")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime PublishDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$", ErrorMessage = "Should begin with a capital letter and contain only letters")]

        public string Publisher { get; set; }
        public DateTime?UpdateDate { get; set; }
    }
}