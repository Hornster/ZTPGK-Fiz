using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private UnityEvent _showVictoryText;


    void Start()
    {
        InputReader.RegisterExit(ExitGame);
    }

    public void GameObjectiveMet()
    {
        _showVictoryText?.Invoke();
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
