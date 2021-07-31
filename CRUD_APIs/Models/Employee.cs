using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APIs.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string EmpName { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string EmpTitle { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string EmpEmail { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmpPhoto { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }

        public double EmpSalary { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EmpBirthDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
