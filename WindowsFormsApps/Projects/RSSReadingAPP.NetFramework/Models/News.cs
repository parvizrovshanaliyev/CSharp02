using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReadingAPP.NetFramework.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return this.Title;
        }

        #endregion
    }
}
