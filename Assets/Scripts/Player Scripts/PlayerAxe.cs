using Unity.VisualScripting;
using UnityEngine;

public class PlayerAxe : MonoBehaviour
{
    // setting normal variables
    // Fireballs are setup to already exist but activate and deactivate when needed
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float AttackCooldown;
    private Animator anim; 
    private PlayerMovement playerMovement; 
    private float cooldownTimer = Mathf.Infinity; 
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>(); 
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.C) && cooldownTimer > AttackCooldown && playerMovement.canAttack())
            anim.SetTrigger("attack_axe");
            
        
        cooldownTimer += Time.deltaTime;
    }

    private void attack_axe() 
    {
        Debug.Log("attack intiated");
        cooldownTimer = 0;
        //pool fireballs
        fireballs[FindFireBalls()].transform.position = firePoint.position;
        fireballs[FindFireBalls()].GetComponent<GetsugaAxe>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireBalls()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
