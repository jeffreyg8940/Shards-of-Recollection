using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    //initial variables
    [Header("Attack Params")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [Header("ranged Attack Params")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] bullets;
    [Header("collider Params")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    // initial refs
    private Animator anim; 
    private EnemyPatrol enemyPatrol;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        //Attack player only when seen

        if(playerInsight())
        {
            if(cooldownTimer >= attackCoolDown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !playerInsight();
        }

    }

    private bool playerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        bullets[FindBullet()].transform.position = firepoint.position;
        bullets[FindBullet()].GetComponent<BadGetsugaFireBall>().ActivateProjectile();
    }

    private int FindBullet()
    {
        for(int i = 0; i < bullets.Length; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
