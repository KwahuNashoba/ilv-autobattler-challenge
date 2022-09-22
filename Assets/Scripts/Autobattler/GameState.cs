using System.Collections.Generic;

namespace Autobattler
{
    public class GameState
    {
        public int GridWidth;
        public int GridHeight;

        public IList<IUnitBehavior> PlayerUnits;
        public IList<IUnitBehavior> EnemyUnits;
    }
}
