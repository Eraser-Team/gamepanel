using UnityEngine;
using UnityEngine.UI;

public class ESCsettings : MonoBehaviour
{
    private enum GameState
    {
        Settings,
        Game,
		SB,
		Tab
    }

    private GameState gameState;
	public GameObject settingsPanel;
	public GameObject sbPanel;
	public GameObject tabPanel;

    private void Start()
    {
        gameState = GameState.Game;
        Cursor.lockState = CursorLockMode.Confined;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gameState)
            {
                case GameState.Settings:
				    Cursor.lockState = CursorLockMode.Locked;
                    settingsPanel.SetActive(false);
                    gameState = GameState.Game;
                    break;
                case GameState.Game:
					Cursor.lockState = CursorLockMode.Confined;
                    settingsPanel.SetActive(true);
                    gameState = GameState.Settings;
                    break;
				case GameState.SB:
					Cursor.lockState = CursorLockMode.Confined;
					sbPanel.SetActive(false);
					gameState = GameState.Game;
					break;
            }
        }
		if (Input.GetKeyDown(KeyCode.Q))
		{
			switch (gameState)
			{
				case GameState.SB:
					sbPanel.SetActive(false);
					Cursor.lockState = CursorLockMode.Locked;
					gameState = GameState.Game;
					break;
				case GameState.Game:
					sbPanel.SetActive(true);
					Cursor.lockState = CursorLockMode.Confined;
					gameState = GameState.SB;
					break;
				case GameState.Settings:
					break;
				case GameState.Tab:
					break;
			}
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			switch (gameState)
			{
				case GameState.Game:
					tabPanel.SetActive(true);
					gameState = GameState.Tab;
					break;
				case GameState.SB:
					break;
				case GameState.Settings:
					break;
				case GameState.Tab:
					break;
			}
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			switch (gameState)
			{
				case GameState.Game:
					break;
				case GameState.SB:
					break;
				case GameState.Settings:
					break;				
				case GameState.Tab:
					tabPanel.SetActive(false);
					gameState = GameState.Game;
					break;
			}
		}
    }
}