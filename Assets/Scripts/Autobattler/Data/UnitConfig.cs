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
    public class UnitConfig : ScriptableObject
    {
        public UnitType UnitType { get; set; }
        public int MovementSpeed { get; set; }
        public int AttackRange { get; set; }
        public int AttackDamage { get; set; }
        public float HealthPoints { get; set; }
    }
}
