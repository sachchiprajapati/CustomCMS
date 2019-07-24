using CustomCMS.Core.Interface;
using CustomCMS.Core.Model;
using CustomCMS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomCMS.Controllers
{
    [Authorize]
    [HandleError]
    public class SocialMediaController : Controller
    {
        #region "Declaration"
        string _Success, _Error;
        ISocialMediaMaster db;
        public SocialMediaController(ISocialMediaMaster db)
        {
            this.db = db;
        }
        #endregion

        #region Slider Add - Update
        [HttpGet]
        public ActionResult Index(int? Id)
        {
            SocialMediaModel model = new SocialMediaModel();
            if (Id != null && Id > 0)
            {
                model = db.GetSocialMediaByID(Id ?? 0);
            }
            model.SocialMediaList = db.GetMasterSocialMediaList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SocialMediaModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    #region Update
                    int Id = db.Update(model);
                    if (Id > 0)
                    {
                        _Success = "Data Updated successfully";
                    }
                    else
                    {
                        _Error = "Error in Update Data";
                    }
                    #endregion
                }
                else
                {
                    #region Insert
                    int Id = db.Add(model);
                    if (Id > 0)
                    {
                        _Success = "Data Added successfully";
                    }
                    else
                    {
                        _Error = "Error in Add Data";
                    }
                    #endregion
                }
                return RedirectToAction("SocialMediaList").Success(_Success);
            }
            else
            {
                model.SocialMediaList = db.GetMasterSocialMediaList();
                return View(model).Warning(_Error);
            }
        }
        #endregion

        #region Slider List
        public ActionResult SocialMediaList()
        {
            return View(db.GetSocialMediaList());
        }
        #endregion

        #region Delete Slider
        public ActionResult DeleteSocialMedia(int Id)
        {
            int SId = db.Delete(Id);
            if (SId > 0)
            {
                _Success = "Data Deleted successfully";
            }
            return RedirectToAction("SocialMediaList").Success(_Success);
        }
        #endregion
    }
}