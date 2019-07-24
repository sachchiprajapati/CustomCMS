using CustomCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomCMS.Core.Interface
{
    public interface ISocialMediaMaster
    {
        int Add(SocialMediaModel obj);
        int Update(SocialMediaModel obj);
        int Delete(int Id);
        List<SocialMediaModel> GetSocialMediaList();
        SocialMediaModel GetSocialMediaByID(int Id);
        List<SelectListItem> GetMasterSocialMediaList();
    }
}
