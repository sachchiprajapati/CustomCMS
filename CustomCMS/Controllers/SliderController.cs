using CustomCMS.Core.Interface;
using CustomCMS.Core.Model;
using CustomCMS.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomCMS.Controllers
{
    [Authorize]
    [HandleError]
    public class SliderController : Controller
    {
        #region "Declaration"
        string _FileName, _Success, _Error;
        ISliderMaster db;
        public SliderController(ISliderMaster db)
        {
            this.db = db;
        }
        #endregion

        #region Slider Add - Update
        [HttpGet]
        public ActionResult Index(int? Id)
        {
            SliderModel model = new SliderModel();
            if (Id != null && Id > 0)
            {
                model = db.GetSliderByID(Id ?? 0);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SliderModel model)
        {
            if (model.Id > 0)
            {
                if (ModelState["File"] != null)
                    ModelState["File"].Errors.Clear();
            }
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    #region Update
                    if (model.File != null)
                    {
                        HttpPostedFileBase file = model.File;
                        var path = HttpContext.Server.MapPath("~/UploadFiles/SliderImage");
                        CommonHelper.CreateDirectory(path);

                        _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(path, _FileName);
                        file.SaveAs(_path);
                    }
                    else
                    {
                        _FileName = db.GetSliderByID(model.Id ?? 0).Image;
                    }

                    model.Image = _FileName;
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
                    HttpPostedFileBase file = model.File;

                    var path = Server.MapPath("~/UploadFiles/SliderImage");
                    CommonHelper.CreateDirectory(path);

                    _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(path, _FileName);
                    file.SaveAs(_path);
                    model.Image = _FileName;
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
                return RedirectToAction("SliderList").Success(_Success);
            }
            else
            {
                return View(model).Warning(_Error);
            }
        }
        #endregion

        #region Slider List
        public ActionResult SliderList()
        {
            return View(db.GetSlidersList());
        }
        #endregion

        #region Delete Slider
        public ActionResult DeleteSlider(int Id)
        {
            string _FileName = db.GetSliderByID(Id).Image;
            int SId = db.Delete(Id);
            if (SId > 0)
            {
                string _path = Server.MapPath("~/UploadFiles/SliderImage" + _FileName);
                if (System.IO.File.Exists(_path))
                {
                    System.IO.File.Delete(_path);
                }

                _Success = "Data Deleted successfully";
            }
            return RedirectToAction("SliderList").Success(_Success);
        }
        #endregion
    }
}