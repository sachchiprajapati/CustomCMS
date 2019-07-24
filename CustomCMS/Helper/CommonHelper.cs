using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CustomCMS.Helper
{
    public class CommonHelper
    {
        #region Check Directory Exists then Create Directory
        /// <summary>
        /// Check Directory Exist or not if not then create Directory
        /// </summary>
        /// <param name="dirpath">dirpath</param>
        public static void CreateDirectory(string dirpath)
        {
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
        }
        #endregion
    }
}