public class Win : IGameState
{
    private GameManager gameManager;

    public Win(GameManager manager)
    {
        gameManager = manager;
    }

    public void Enter()
    {
        gameManager.WinGame();
    }

    public void HandleSubmit()
    {

    }

    public void Exit()
    {
        UnityEngine.Debug.Log("Leaving Win State.");
    }
}
