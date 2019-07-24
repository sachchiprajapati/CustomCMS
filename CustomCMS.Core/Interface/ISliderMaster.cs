using CustomCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Core.Interface
{
    public interface ISliderMaster
    {
        int Add(SliderModel obj);
        int Update(SliderModel obj);
        int Delete(int Id);
        List<SliderModel> GetSlidersList();
        SliderModel GetSliderByID(int Id);
    }
}
