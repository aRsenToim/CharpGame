using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model
{
    internal class ArenaModel
    {
        public List<OrangeModel> Oranges = new List<OrangeModel>();
        
        public ArenaModel(bool isActivePlayer)
        {   
        }

        public void RemoveAllOranges() {
            Oranges.RemoveAll(o => !o.IsActive);
        }
        public void DeleteAllOranges() {
            Oranges.Clear();
        }
    }
}
