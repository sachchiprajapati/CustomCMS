using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CustomCMS.Core.Model
{
    //Customized data annotation validator for uploading file
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 3; //3 MB
            string[] AllowedFileExtensions = new string[] { ".jpg", ".JPG", ".gif", ".png", ".PNG", "jpeg", "JPEG" };

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Image of type: " + string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Your Image is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }

    public class SliderModel
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        [Required(ErrorMessage = "Please Select File.")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [ValidateFile]
        public HttpPostedFileBase File { get; set; }

        //public DateTime EnterDate { get; set; }
    }
}
