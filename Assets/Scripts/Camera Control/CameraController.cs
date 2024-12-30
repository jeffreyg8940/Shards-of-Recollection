using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //room controller
    [SerializeField] private float speed; 
    
    private float currentpositionx;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player; 
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private void Update()
    {
        //room controller
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentpositionx, transform.position.y, transform.position.z), ref velocity, speed);

        Vector3 targetPosition = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        // transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        // lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void moveToNewRoom(Transform _newRoom)
    {
        currentpositionx = _newRoom.position.x; 
    }

}
