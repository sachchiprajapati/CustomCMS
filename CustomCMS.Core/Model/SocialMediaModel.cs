using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomCMS.Core.Model
{
    public class UrlAttribute : RegularExpressionAttribute
    {
        public UrlAttribute() : base(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$")
        { }
    }
    public class SocialMediaModel
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Social Media")]
        public int SMId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Social URL")]
        //[DataType(DataType.Url, ErrorMessage = "Please Enter Valid URL !")]
        //[Url(ErrorMessage = "Please Enter Valid URL !")]
        //[RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Please Enter Valid URL !")]
        public string SocialURL { get; set; }

        public bool SocialStatus { get; set; }
        public List<SelectListItem> SocialMediaList { get; set; }
        public string SocialMediaName { get; set; }
    }
}
