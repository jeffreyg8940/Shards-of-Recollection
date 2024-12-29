using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GetsugaFireBall : MonoBehaviour
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
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if(lifeTime > timetillexplode) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("explode");

        if(collision.tag == "Enemy")
            collision.GetComponent<Health>().takeDamage(15);
    }

    public void setDirection(float _direction) 
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;

        float localScaleX = transform.localScale.x; 
        if(Mathf.Sign(localScaleX) != direction) 
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }

}
