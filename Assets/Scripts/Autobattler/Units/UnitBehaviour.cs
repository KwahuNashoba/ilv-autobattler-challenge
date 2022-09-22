using System.Collections.Generic;

namespace Autobattler.Units
{
    public class UnitBehaviour : IUnitBehavior
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public UnitBehaviour(int initialPositionX, int initialPositionY)
        {
            PositionX = initialPositionX;
            PositionY = initialPositionY;
        }

        public void TickAttack(IEnumerable<IUnitBehavior> enemyUnits)
        {
            // TODO: if in attacking state, current target
        }

        public void TickDeath(IEnumerable<IUnitBehavior> playerUnits)
        {
            // TODO: remove itself from collection
        }

        public void TickPosition(IEnumerable<IUnitBehavior> enemyUnits)
        {
            // TODO: if in moving state, keep moving until in range
            // else, ignore this callback
        }

        public void TickTarget(IEnumerable<IUnitBehavior> enemyUnits)
        {
            // TODO: if not is attack state, find nearest enemy using deterministic pathfinding and switch to move state
            // else, ignore this callback
        }
    }
}
