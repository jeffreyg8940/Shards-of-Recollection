using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Poionts")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [Header ("Movment Params")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    [SerializeField] private float idletimer;

    [SerializeField] private Animator anim;

    private void Awake()
    {
        initscale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("run", false);
        
    }
    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveinDirection(-1); 
            else
                directionChange();
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveinDirection(1);
            else
                directionChange();
        }

    }
    private void directionChange() 
    {
        anim.SetBool("run", false);

        idletimer += Time.deltaTime;

        if(idletimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveinDirection(int _direction) 
    {
        idletimer = 0;
        anim.SetBool("run", true);
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction, 
        initscale.y, initscale.z);
        // make enemy face direction first then move.
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
}
