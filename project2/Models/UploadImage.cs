﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project2.Models
{
    public class UploadImage
    {

        public class FileUploadModel
        {
            [DataType(DataType.Upload)]
            [Display(Name = "Upload File")]
            [Required(ErrorMessage = "Please choose file to upload.")]
            public string file { get; set; }

        }
    }
}