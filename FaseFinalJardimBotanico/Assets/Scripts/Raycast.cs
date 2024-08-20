using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    public string targetLayer = "TransparentFX";
    public float maxDistance = 100f; // Defina a distância máxima aqui
    public GameObject txtcliquepararegastar; // O objeto que será ativado
    public TextMeshProUGUI txtanimaisresgatados; // Referência ao TextMeshPro

    private int deletionCount = 0; // Variável para contar as deleções

    public GameObject telaFinal;
    public GameObject telaJogo;
    public GameObject lobisomen;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        ResgatarAnimais();
        VerificarVitoria();
    }

    public void ResgatarAnimais()
    {
        // Cria um raycast na direção do cursor
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o raycast atingiu um objeto dentro da distância máxima
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Verifica se o objeto está na layer "TransparentFX"
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer(targetLayer))
            {
                // Ativa o objeto
                txtcliquepararegastar.SetActive(true);

                // Verifica se o botão esquerdo do mouse foi clicado
                if (Input.GetMouseButtonDown(0))
                {
                    // Deleta o objeto
                    Destroy(hit.transform.gameObject);
                    deletionCount++;
                    txtanimaisresgatados.text = "Animais resgatados: " + deletionCount + "/5";
                }
            }
            else
            {
                // Desativa o objeto se o raycast não está mais detectando um objeto na layer "TransparentFX"
                txtcliquepararegastar.SetActive(false);
            }
        }
        else
        {
            // Desativa o objeto se o raycast não está mais detectando um objeto
            txtcliquepararegastar.SetActive(false);
        }
    }

    public void VerificarVitoria()
    {
        if (deletionCount == 5)
        {
            // Ativa o objeto telaFinal

            telaFinal.SetActive(true);
            telaJogo.SetActive(false);
            lobisomen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
