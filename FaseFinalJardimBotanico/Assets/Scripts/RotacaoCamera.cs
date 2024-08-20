using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotacaoCamera : MonoBehaviour
{
    public Transform corpoPlayer;
    public Transform cabecaPlayer;
    public float sensibilidadeCam = 10f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYMax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.05f;
    float smoothCoefy = 0.05f;
    private void Start() {
        
    }
private void LateUpdate() {
    transform.position = cabecaPlayer.position;
}
    
    private void Update() {
        RotacionarCamera();
    }

    private void RotacionarCamera()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensibilidadeCam;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensibilidadeCam;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += horizontalDelta;
        rotationY += verticalDelta;

        rotationY = Math.Clamp(rotationY, angleYmin, angleYMax);

          corpoPlayer.localEulerAngles = new Vector3(0, rotationX, 0);


        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
