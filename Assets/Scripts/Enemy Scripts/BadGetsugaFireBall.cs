using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BadGetsugaFireBall : EnemyDamage
{
    // setting main variables
    [SerializeField] private float timetillexplode;
    private float lifeTime;
    private float direction;
    [SerializeField] private float speed;
    private bool hit;
    // setting refs
    private BoxCollider2D boxcollider; 
    private Animator anim; 

    private void Awake() 
    {
        boxcollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if(lifeTime > timetillexplode) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("explode");

        if(collision.tag == "Player")
            collision.GetComponent<Health>().takeDamage(15);
    }

    public void ActivateProjectile() 
    {
        lifeTime = 0;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }

}
