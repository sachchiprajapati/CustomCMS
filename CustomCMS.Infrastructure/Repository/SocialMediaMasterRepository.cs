using CustomCMS.Core.Interface;
using CustomCMS.Core.Model;
using CustomCMS.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomCMS.Infrastructure.Repository
{
    public class SocialMediaMasterRepository : ISocialMediaMaster
    {
        #region "Declaration"
        private static DBHelper objDBHelper = new DBHelper();
        #endregion

        #region SocialMedia Add
        public int Add(SocialMediaModel obj)
        {
            int Id = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeInsert);
                objDBHelper.AddParameter("SocialURL", obj.SocialURL);
                objDBHelper.AddParameter("SocialStatus", obj.SocialStatus);
                objDBHelper.AddParameter("SMID", obj.SMId);
                objDBHelper.AddParameter("CreatedBy", 1);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("SId", 0);
                
                Id = (int)objDBHelper.ExecuteNonQuery(SPName.spSocialMediaDetail, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region SocialMedia Update
        public int Update(SocialMediaModel obj)
        {
            int Id = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeUpdate);
                objDBHelper.AddParameter("SocialURL", obj.SocialURL);
                objDBHelper.AddParameter("SocialStatus", obj.SocialStatus);
                objDBHelper.AddParameter("SMID", obj.SMId);
                objDBHelper.AddParameter("SId", obj.Id);
                objDBHelper.AddParameter("UpdatedBy", 1);
                objDBHelper.AddParameter("CreatedBy", 0);
              
                Id = (int)objDBHelper.ExecuteNonQuery(SPName.spSocialMediaDetail, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region SocialMedia Delete
        public int Delete(int Id)
        {
            int SId = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeDelete);
                objDBHelper.AddParameter("SId", Id);
                objDBHelper.AddParameter("SocialURL", string.Empty);
                objDBHelper.AddParameter("SocialStatus", false);
                objDBHelper.AddParameter("SMID", 0);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("CreatedBy", 0);

                SId = (int)objDBHelper.ExecuteNonQuery(SPName.spSocialMediaDetail, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SId;
        }
        #endregion

        #region Get SocialMedia By ID
        public SocialMediaModel GetSocialMediaByID(int Id)
        {
            SocialMediaModel model = new SocialMediaModel();
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeGetByID);
                objDBHelper.AddParameter("SId", Id);
                objDBHelper.AddParameter("SocialURL", string.Empty);
                objDBHelper.AddParameter("SocialStatus", false);
                objDBHelper.AddParameter("SMID", 0);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("CreatedBy", 0);

                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spSocialMediaDetail, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.Id = Id;
                            model.SocialStatus  = CommonLogic.GetBoolValue(dr["SocialStatus"]);
                            model.SocialURL = CommonLogic.GetStringValue(dr["SocialURL"]);
                            model.SMId = CommonLogic.GetIntValue(dr["SMID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        #endregion

        #region Get SocialMedia List
        public List<SocialMediaModel> GetSocialMediaList()
        {
            List<SocialMediaModel> model = new List<SocialMediaModel>();
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeSelect);
                objDBHelper.AddParameter("SId", 0);
                objDBHelper.AddParameter("SocialURL", string.Empty);
                objDBHelper.AddParameter("SocialStatus", false);
                objDBHelper.AddParameter("SMID", 0);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("CreatedBy", 0);

                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spSocialMediaDetail, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SocialMediaModel obj = new SocialMediaModel();
                            obj.Id = CommonLogic.GetIntValue(dr["Id"]);
                            obj.SocialStatus = CommonLogic.GetBoolValue(dr["SocialStatus"]);
                            obj.SocialURL = CommonLogic.GetStringValue(dr["SocialURL"]);
                            obj.SMId = CommonLogic.GetIntValue(dr["SMID"]);
                            obj.SocialMediaName = CommonLogic.GetStringValue(dr["SocialMediaName"]);
                            model.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        #endregion

        #region Get SocialMedia Master List
        public List<SelectListItem> GetMasterSocialMediaList()
        {
            List<SelectListItem> model = new List<SelectListItem>();
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
               
                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spSocialMediaMaster, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SelectListItem obj = new SelectListItem();
                            obj.Value = CommonLogic.GetStringValue(dr["Id"]);
                            obj.Text = CommonLogic.GetStringValue(dr["SocialMediaName"]);
                            model.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        #endregion
    }
}
