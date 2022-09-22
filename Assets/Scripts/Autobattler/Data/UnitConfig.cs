using UnityEngine;

namespace Autobattler.Data
{
    public enum UnitType
    {
        Main,
        Sidekick
    }

    // TODO: this should be POCO class and not dependent on game engine
    // but I choose SO to avoid serialization and speed up creation
    [CreateAssetMenu(menuName = "AutoBattler/Unit Config")]
    public class UnitConfig : ScriptableObject
    {
        public UnitType UnitType;
        public int MovementSpeed;
        public int AttackRange;
        public int AttackDamage;
        public float HealthPoints;
    }
}
