using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float mouseSensitivity = 12.0f;
    public Transform player;

    void Update()
    {
        // Movimento visuale
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);

        // Inseguimento giocatore
        Vector3 playerPos = player.position;
        transform.position = playerPos;
    }
}
