using System.Collections.Generic;

namespace Autobattler.Units
{
    public class UnitBehaviour : IUnitBehavior
    {
        public int PositionX => throw new System.NotImplementedException();

        public int PositionY => throw new System.NotImplementedException();

        public void TickAttack(IEnumerable<IUnitBehavior> enemyUnits)
        {
            throw new System.NotImplementedException();
        }

        public void TickDeath(IEnumerable<IUnitBehavior> playerUnits)
        {
            throw new System.NotImplementedException();
        }

        public void TickPosition(IEnumerable<IUnitBehavior> enemyUnits)
        {
            throw new System.NotImplementedException();
        }

        public void TickTarget(IEnumerable<IUnitBehavior> enemyUnits)
        {
            throw new System.NotImplementedException();
        }
    }
}
