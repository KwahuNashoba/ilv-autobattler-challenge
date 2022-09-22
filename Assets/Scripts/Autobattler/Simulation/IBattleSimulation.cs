namespace Autobattler.Simulation
{
    interface IBattleSimulation
    {
        public GameState GameStateeee { get; }
        public GameStatus Tick(float elapsedTime);
    }
    public enum GameStatus
    {
        Playing,
        Won,
        Lost,
        Tied
    }
}
