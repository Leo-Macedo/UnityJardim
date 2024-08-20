using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimento : MonoBehaviour
{
     CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;
    Vector3 finalVelocity;

    float forwardSpeed = 6f;
    float strafeSpeed = 6f;
    public float veloCorrida = 12f;  // Velocidade de corrida
    public float veloAndando = 6f;  // Velocidade de caminhada

    float gravity;
    public float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;
   
    public float energia = 100f;  // A energia inicial do guarda
    public Slider sliderEnergia;  // O slider que mostra a energia do guarda
    private bool estaCorrendo = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

        sliderEnergia.maxValue = energia;
        sliderEnergia.value = energia;
        // Começa a regenerar energia após 5 segundos
        InvokeRepeating("RegenerarEnergia", 1f, 1f);
    }

    void Update()
    {
        Mover();
        Pular();
        Correr();
        
    }
   public void Mover()
   {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
   }

   public void Pular()
   {
        vertical += gravity * Time.deltaTime * Vector3.up;

        if(controller.isGrounded) {
            vertical = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }
   }
    void Correr()
    {
       
        if (Input.GetKey(KeyCode.LeftShift) && energia > 0)  // O guarda só pode correr se a energia for maior que 0
        {
            estaCorrendo = true;
            forwardSpeed = veloCorrida;  // Aumenta a velocidade para correr
            energia -= 0.7f;  // A energia diminui em 10 unidades quando o guarda corre
            sliderEnergia.value = energia;  // Atualiza o valor do slider
        }

         else
        {
            estaCorrendo = false;
            forwardSpeed = veloAndando;  // Retorna à velocidade normal
        }
    }

    void RegenerarEnergia()
    {
        if (!estaCorrendo && energia < 200)  // Se o guarda não está correndo e a energia é menor que 100
        {
            energia += 50;  // A energia aumenta em 10 unidades
            sliderEnergia.value = energia;  // Atualiza o valor do slider
        }
    }
}