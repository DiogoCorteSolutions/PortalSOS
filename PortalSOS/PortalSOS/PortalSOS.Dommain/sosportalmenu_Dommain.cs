using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class sosportalmenu_Dommain
    {
        public sosportalmenu_Dommain()
        {
            this.SubMenu = new List<sosportalmenu_Dommain>();
        }

        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public IList<sosportalmenu_Dommain> SubMenu { get; set; }
    }
}
