using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class HashHelper
    {
        /// <summary>
        /// hash 怎么 计算 的 了  
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static int GetGuidHashCode(string guid)
        {
            int hash = 0;
            if (Guid.TryParse(guid, out Guid id))
            {
                hash = id.GetHashCode();
            }
            else
            {
                //hash = guid.GetHashCode();
                foreach (var item in guid)
                {
                    hash = unchecked( hash * 37 + item);
                }
            }
            return hash;
        }


    }
}
