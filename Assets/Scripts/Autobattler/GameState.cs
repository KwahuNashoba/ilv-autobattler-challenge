using System.Collections.Generic;

namespace Autobattler
{
    public class GameState
    {
        public readonly int GridWidth;
        public readonly int GridHeight;

        public IList<IUnitBehavior> PlayerUnits;
        public IList<IUnitBehavior> EnemyUnits;
    }
}
