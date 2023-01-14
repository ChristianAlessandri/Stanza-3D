using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public GameObject player;
    public Text text;

    private float doorOpenSpeed = 5.0f;
    private bool isOpen = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= 4f)
        {
            if (WS_Client.canOpenDoor.Equals("true"))
            {
                text.text = "Premi E per interagire con la porta";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isOpen = !isOpen;
                }
            }
            else
            {
                text.text = "La porta è chiusa";
            }
        }
        else
        {
            text.text = "";
        }

        if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, doorOpenSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, 270, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, doorOpenSpeed * Time.deltaTime);
        }
    }
}
