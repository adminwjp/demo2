using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility.AspNetCore.Localizer
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        string[] files;
        public JsonStringLocalizerFactory(string[] files)
        {
            this.files = files;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(files);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(files);
        }
    }
}
