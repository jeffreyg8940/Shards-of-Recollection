using Unity.VisualScripting;
using UnityEngine;

public class doors : MonoBehaviour
{
    // setting changeable variables for camera control.
    [SerializeField] private Transform previousRoom; 
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
                {
                    cam.moveToNewRoom(nextRoom);
                    nextRoom.GetComponent<roomReset>().ActivateRoom(true);
                    previousRoom.GetComponent<roomReset>().ActivateRoom(false);
                }
            else
            {
                cam.moveToNewRoom(previousRoom);
                previousRoom.GetComponent<roomReset>().ActivateRoom(true);
                nextRoom.GetComponent<roomReset>().ActivateRoom(false);


            }
        }
    }
}
