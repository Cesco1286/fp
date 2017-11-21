﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [RegularExpression(@"[a-zA-Z''-'\s]*$")]
        [Column("FirstName")] // makes so that the column, in the db, will be name "FirstName", and not "FirstMidName"
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Full Name")]
        public DateTime EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + "," + FirstMidName;
            }

        }


        public ICollection<Enrollment> Enrollments { get; set; }
}

}
