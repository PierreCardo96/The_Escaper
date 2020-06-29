using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private Canvas gameOverCanvas;
    private void Start()
    {
        gameOverCanvas = FindObjectOfType<GameUI>().GetGameOverCanvas();
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
