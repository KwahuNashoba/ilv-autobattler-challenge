using Autobattler.Data;
using Autobattler.Simulation;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelConfigData _levelConfig = default;
        [SerializeField] private LevelGenerator levelGenerator = null;
        [SerializeField] private GameObject PlayerPrefab;
        [SerializeField] private GameObject EnemyPrefab;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _enemy;

        private IBattleSimulation _battleSimulation;

        private void Start()
        {
            InitializeLevel(_levelConfig);
            _battleSimulation = new DeterministicBattleSimulation(0.1f, _levelConfig);
        }

        private void Update()
        {
            _battleSimulation.Tick(Time.realtimeSinceStartup);

            MoveUnits();
        }

        private void InitializeLevel(LevelConfigData levelConfig)
        {
            levelGenerator.GenerateLevel(levelConfig);
        }

        public void MoveUnits()
        {
            var playerUnit = _battleSimulation.GameStateeee.PlayerUnits.FirstOrDefault();
            _player.position = new Vector3(playerUnit.PositionX * 0.55f, playerUnit.PositionY * 0.64f, 0);
            var enemyUnit = _battleSimulation.GameStateeee.EnemyUnits.FirstOrDefault();
            _enemy.position = new Vector3(enemyUnit.PositionX * 0.55f, enemyUnit.PositionY * 0.64f, 0);
        }
    }
}
