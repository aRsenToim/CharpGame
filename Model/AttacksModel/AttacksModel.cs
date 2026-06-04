using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model.AttacksModel
{
    internal class AttackModel
    {
        private readonly List<IAttack> _attacks = new List<IAttack>();
        public IReadOnlyList<IAttack> Attacks => _attacks;

        public void AddAttack(IAttack attack)
        {
            _attacks.Add(attack);
        }

        public IAttack GetAttack(int index)
        {
            return _attacks[index];
        }
    }
}
