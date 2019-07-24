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

namespace CustomCMS.Infrastructure.Repository
{
    public class SliderMasterRepository : ISliderMaster
    {
        #region "Declaration"
        private static DBHelper objDBHelper = new DBHelper();
        #endregion

        #region Slider Add
        public int Add(SliderModel obj)
        {
            int Id = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeInsert);
                objDBHelper.AddParameter("Title", obj.Title);
                objDBHelper.AddParameter("Image", obj.Image);
                objDBHelper.AddParameter("CreatedBy", 1);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("SId", 0);
                Id = (int)objDBHelper.ExecuteNonQuery(SPName.spSlider, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Slider Update
        public int Update(SliderModel obj)
        {
            int Id = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeUpdate);
                objDBHelper.AddParameter("Title", obj.Title);
                objDBHelper.AddParameter("Image", obj.Image);
                objDBHelper.AddParameter("SId", obj.Id);
                objDBHelper.AddParameter("UpdatedBy", 1);
                objDBHelper.AddParameter("CreatedBy", 0);
                Id = (int)objDBHelper.ExecuteNonQuery(SPName.spSlider, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Slider Delete
        public int Delete(int Id)
        {
            int SId = 0;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeDelete);
                objDBHelper.AddParameter("SId", Id);
                objDBHelper.AddParameter("Title", string.Empty);
                objDBHelper.AddParameter("Image", string.Empty);
                objDBHelper.AddParameter("UpdatedBy", 0);
                objDBHelper.AddParameter("CreatedBy", 0);
                SId = (int)objDBHelper.ExecuteNonQuery(SPName.spSlider, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SId;
        }
        #endregion

        #region Get Slider By ID
        public SliderModel GetSliderByID(int Id)
        {
            SliderModel model = new SliderModel();
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeGetByID);
                objDBHelper.AddParameter("SId", Id);
                objDBHelper.AddParameter("Title", string.Empty);
                objDBHelper.AddParameter("Image", string.Empty);
                objDBHelper.AddParameter("CreatedBy", 0);
                objDBHelper.AddParameter("UpdatedBy", 0);

                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spSlider, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.Id = Id;
                            model.Title = CommonLogic.GetStringValue(dr["Title"]);
                            model.Image = CommonLogic.GetStringValue(dr["Image"]);
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

        #region Get Slider List
        public List<SliderModel> GetSlidersList()
        {
            List<SliderModel> model = new List<SliderModel>();
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("Mode", SPMode.modeSelect);
                objDBHelper.AddParameter("SId", 0);
                objDBHelper.AddParameter("Title", string.Empty);
                objDBHelper.AddParameter("Image", string.Empty);
                objDBHelper.AddParameter("CreatedBy", 0);
                objDBHelper.AddParameter("UpdatedBy", 0);

                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spSlider, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SliderModel obj = new SliderModel();
                            obj.Id = CommonLogic.GetIntValue(dr["Id"]);
                            obj.Title = CommonLogic.GetStringValue(dr["Title"]);
                            obj.Image = CommonLogic.GetStringValue(dr["Image"]);
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
