public class Playing : IGameState
{
    private GameManager gameManager;

    public Playing(GameManager manager)
    {
        gameManager = manager;
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Game started. Player is playing.");
    }

    public void HandleSubmit()
    {
        gameManager.CheckAnswer();
    }

    public void Exit()
    {
        UnityEngine.Debug.Log("Leaving Playing State.");
    }
}