using UnityEngine;
using UnityEngine.AI;

public class LobisomenCaca: MonoBehaviour
{
    public Transform alvo; // o alvo que o lobisomem deve seguir
    private NavMeshAgent agente; // o NavMeshAgent anexado a este objeto
    private Animator animator; 


    void Start()
    {
        // Obtém o NavMeshAgent anexado a este objeto
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        Seguiranimar();
    }

    private void Seguiranimar()
    {
         // Define o destino do agente para a posição do alvo
        agente.SetDestination(alvo.position);

        //Animações de andar e parar

        if (agente.velocity != Vector3.zero)
        {
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }
    }

}