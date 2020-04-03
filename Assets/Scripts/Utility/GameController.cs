using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the game.
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private UnityEvent _showVictoryText;


    void Start()
    {
        InputReader.RegisterExit(ExitGame);
    }
    /// <summary>
    /// Handler for the objective completion eeveent.
    /// </summary>
    public void GameObjectiveMet()
    {
        _showVictoryText?.Invoke();
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
