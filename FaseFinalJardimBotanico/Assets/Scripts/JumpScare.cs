using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Playables;


public class JumpScare : MonoBehaviour
{
    public GameObject telaperdeu; // Objeto para ativar
    public GameObject telajogo;
    public PlayableDirector cutscene;
    public GameObject cutsceneOBJ;

private void OnTriggerEnter(Collider other) 
{
      if (other.gameObject.tag == "guarda")
        {
            Debug.Log("colidiu com guarda");
           PerdeuJumpScare();
        }
    
}
      
    public void AtivarTelaPerdeu()
    {
        telaperdeu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
    }

  

    public void PerdeuJumpScare()
    {
            
            telajogo.SetActive(false);
            cutscene.Play();
            cutsceneOBJ.SetActive(true);
        
            Invoke("AtivarTelaPerdeu", (float)cutscene.duration);
    }

}
