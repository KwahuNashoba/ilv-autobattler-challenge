using UnityEngine;

namespace Autobattler.Data
{
    // TODO: this should be POCO class and not dependent on game engine
    // but I choose SO to avoid serialization and speed up creation
    [CreateAssetMenu(menuName = "AutoBattler/Level Config")]
    public class LevelConfigData : ScriptableObject
    {
        public int GridWidth;
        public int GridHeight;
        public UnitConfig[] PlayerUnits;
        public UnitConfig[] EnemyUnits;
    }
}
