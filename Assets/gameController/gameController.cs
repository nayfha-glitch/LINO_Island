using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle }


public class gameController : MonoBehaviour
{
    [SerializeField] player_controller PlayerController;
    [SerializeField] Dialog startDialog;

    GameState state;

    private void Start()
    {
        DialogManager.Instance.ShowDialog(startDialog);
        state = GameState.Dialog;
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            PlayerController.HandleUpdate();
        } else if (state == GameState.Dialog)
        {

        } else if (state == GameState.Battle)
        {

        }
    }

    public void SetStateFreeRoam()
    {
        state = GameState.FreeRoam;
    }

}
