using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Camera camera;

    private float speed = 5.0f;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = camera.transform.forward * vertical + camera.transform.right * horizontal;
        direction.y = 0;
        direction = direction.normalized;

        _characterController.Move(direction * speed * Time.deltaTime);
    }
}
