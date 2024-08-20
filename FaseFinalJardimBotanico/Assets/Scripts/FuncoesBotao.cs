using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class FuncoesBotao : MonoBehaviour
{
     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Sair");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Fase1");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

     public void VoltarMenu ()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
