using System.Collections.Generic;

namespace BattleFroggy.Model
{
    internal class ArenaModel
    {
        public List<OrangeModel> Oranges = new List<OrangeModel>();
        
        public ArenaModel()
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
