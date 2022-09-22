namespace Autobattler.Simulation
{
    interface IBattleSimulation
    {
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
