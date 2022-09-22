using System.Collections.Generic;

namespace Autobattler
{
    public interface IUnitBehavior
    {
        public int PositionX { get; }
        public int PositionY { get; }

        public void TickTarget(IEnumerable<IUnitBehavior> enemyUnits);
        public void TickPosition(IEnumerable<IUnitBehavior> enemyUnits);
        public void TickAttack(IEnumerable<IUnitBehavior> enemyUnits);
        public void TickDeath(IEnumerable<IUnitBehavior> playerUnits); // TODO: do we need this? State should remove dead units
    }
}
