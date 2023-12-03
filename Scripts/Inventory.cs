using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private enum GameState
    {
		Hands,
        Pistol
    }
	
	private GameState gameState;
	public GameObject pistol;
	
	private void Start()
	{
		gameState = GameState.Pistol;
	}
	
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			switch (gameState)
			{
				case GameState.Hands:
					break;
				case GameState.Pistol:
					pistol.SetActive(false);
					gameState = GameState.Hands;
					break;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			switch (gameState)
			{
				case GameState.Hands:
					pistol.SetActive(true);
					gameState = GameState.Pistol;
					break;
				case GameState.Pistol:
					break;
			}
		}
	}
}
