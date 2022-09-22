using UnityEngine;

namespace Autobattler.Data
{
    // TODO: this should be POCO class and not dependent on game engine
    // but I choose SO to avoid serialization and speed up creation
    public class GameStateConfig : ScriptableObject
    {
        public int GridWidth { get; }
        public int GridHeight { get; }
        public UnitConfig[] PlayerUnits { get; set; }
        public UnitConfig[] EnemyUnits { get; set; }
    }
}
