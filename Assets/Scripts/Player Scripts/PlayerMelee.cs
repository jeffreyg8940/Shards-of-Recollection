using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    // setting up variables
    [Header("Attack Params")]
    [SerializeField] private float attackCoolDown;
    private bool hasDamaged = false;
    [SerializeField] private float range;
    [Header("collider Params")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    private PlayerMovement playerMovement; 


    private float cooldownTimer = Mathf.Infinity;

    private Animator anim; 

    private Health enemyHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //Attack player only when seen

        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCoolDown)
        {
            anim.SetTrigger("meeleeattack");
            hasDamaged = false;
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;

    }

    private bool enemyInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, enemyLayer);

        if(hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();   
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damageEnemy()
    {
        if(enemyInsight())
        {
            if (!hasDamaged && enemyInsight())
                enemyHealth.takeDamage(damage);
                hasDamaged = true;
        }
    }
}
