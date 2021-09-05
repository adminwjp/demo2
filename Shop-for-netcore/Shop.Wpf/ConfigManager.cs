using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.IO;
using Utility.Json;
using Utility.Wpf;
using Utility.Wpf.Entries;
using Microsoft.Extensions.DependencyInjection;
using Abp.ObjectMapping;
using Shop.Wpf.ViewModel;
using Shop.Application.Services.Dtos;
using Shop.Application.Services;

namespace Shop.Wpf
{
    public class ConfigManager
    {
        public static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss";
        public static void Load()
        {
            BindConfig();
            BindConfigMethod();
        }
        private static void BindConfigMethod()
        {
            IObjectMapper objectMapper = StartManager.serviceProvider.GetService<IObjectMapper>();
            ShopConfigManager.objectMapper = objectMapper;
            ShopConfigManager.BindShopConfig();
        }

        private static void BindConfig()
        {
            string json = FileHelper.ReadFile("Config/shop.json");
            List<MuilDataEntry> muilDataEntries = JsonHelper.ToObject<List<MuilDataEntry>>(json);
            if (muilDataEntries != null)
            {
                foreach (var muilDataEntry in muilDataEntries)
                {
                    CacheListModelManager.CacheFlagMuilDataEntry[muilDataEntry.Flag] = muilDataEntry;
                }
            }
        }
    }
}
