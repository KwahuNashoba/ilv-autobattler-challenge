using Autobattler.Data;
using Autobattler.Units;
using System;
using System.Collections.Generic;

namespace Autobattler.Simulation
{
    public class DeterministicBattleSimulation : IBattleSimulation
    {
        private GameState _gameState;
        private readonly float _stepTime;
        private readonly LevelConfigData _gameStateConfig;

        private float lastTickTime = 0;

        public GameState GameStateeee => _gameState;

        public DeterministicBattleSimulation(float stepTime, LevelConfigData gameStateConfig)
        {
            _stepTime = stepTime;
            _gameStateConfig = gameStateConfig;

            InitGameState(gameStateConfig);
        }

        public GameStatus Tick(float elapsedTime)
        {
            // NOTE: since main goal is to simulate this on client, we are using runtime DB
            // in other words, units will be updated in memory, each of them updating its state
            // this should lower CPU load, memory footprint and GC allocation
            int totalSteps = CalculateStepCount(elapsedTime);

            // advance stage by stage to preserve determinism
            for(int stepIndex = 0; stepIndex < totalSteps; ++stepIndex)
            {
                // locate next target (unit or field)
                ExecuteTickStage(_gameState.PlayerUnits, _gameState.EnemyUnits, TickTarget);
                ExecuteTickStage(_gameState.EnemyUnits, _gameState.PlayerUnits, TickTarget);

                // update position based on selected target
                ExecuteTickStage(_gameState.PlayerUnits, _gameState.EnemyUnits, TickPosition);
                ExecuteTickStage(_gameState.EnemyUnits, _gameState.PlayerUnits, TickPosition);

                // perform attack (healing etc)
                ExecuteTickStage(_gameState.PlayerUnits, _gameState.EnemyUnits, TickAction);
                ExecuteTickStage(_gameState.EnemyUnits, _gameState.PlayerUnits, TickAction);

                // check if the unit should die
                ExecuteTickStage(_gameState.PlayerUnits, _gameState.PlayerUnits, TickDeath);
                ExecuteTickStage(_gameState.EnemyUnits, _gameState.EnemyUnits, TickDeath);
            }

            lastTickTime += totalSteps * _stepTime;

            return GetGameStatus(_gameState);
        }

        private int CalculateStepCount(float elapsedTime)
        {
            if (lastTickTime == 0) return 1; // first tick

            float deltaTime = elapsedTime - lastTickTime;
            return (int)(deltaTime / _stepTime);
        }

        // NOTE: avoiding foreach which will create copy of collection each time
        private void ExecuteTickStage(IList<IUnitBehavior> units, IList<IUnitBehavior> opponentUnits, Action<IUnitBehavior, IEnumerable<IUnitBehavior>> tickAction)
        {
            for(int unitIndex = 0; unitIndex < units.Count; ++unitIndex)
            {
                tickAction(units[unitIndex], opponentUnits);
            }
        }

        private void TickTarget(IUnitBehavior unit, IEnumerable<IUnitBehavior> enemyUnits)
        {
            unit.TickTarget(enemyUnits);
        }

        private void TickPosition(IUnitBehavior unit, IEnumerable<IUnitBehavior> enemyUnits)
        {
            unit.TickPosition(enemyUnits);
        }

        private void TickAction(IUnitBehavior unit, IEnumerable<IUnitBehavior> enemyUnits)
        {
            unit.TickAttack(enemyUnits);
        }

        private void TickDeath(IUnitBehavior unit, IEnumerable<IUnitBehavior> playerUnits)
        {
            unit.TickDeath(playerUnits);
        }

        private GameStatus GetGameStatus(GameState gameState)
        {
            int playerUnitCount = gameState.PlayerUnits.Count;
            int enemyUnitCount = gameState.EnemyUnits.Count;
            
            if(playerUnitCount > 0 && enemyUnitCount == 0)
            {
                return GameStatus.Won;
            }
            else if(enemyUnitCount > 0 && playerUnitCount == 0)
            {
                return GameStatus.Lost;
            }
            else if(playerUnitCount == 0 && enemyUnitCount == 0)
            {
                return GameStatus.Tied;
            }
            else
            {
                return GameStatus.Playing;
            }
        }

        private void InitGameState(LevelConfigData levelConfig)
        {
            // create initial position for all units based on deterministic random seed based algorithm
            _gameState = new GameState();
            _gameState.GridWidth = levelConfig.GridWidth;
            _gameState.GridHeight= levelConfig.GridHeight;
            _gameState.PlayerUnits = new List<IUnitBehavior>(){ new UnitBehaviour(10, 10) };
            _gameState.EnemyUnits = new List<IUnitBehavior>(){ new UnitBehaviour(20, 20) };
        }
    }
}
