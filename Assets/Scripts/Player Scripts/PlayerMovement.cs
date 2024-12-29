using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    // setting variables to access different elements in unity.
    [SerializeField] private float speed; 
    [SerializeField] private float jump_Speed; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float horizontalinput;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider; 

    private void Awake()
    {
        //Grab ref's for rigid body and animator.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        body.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * speed,body.linearVelocityY);

        horizontalinput = Input.GetAxis("Horizontal");
        // in the mission to make movement less jaring for the user, we will flip the model when he is moving left, when moving right it will be left the same.
        if(horizontalinput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
        // in order to get the character to jump, we added an input.getkey to get the space key input then using body velocity to make the character jump.
        if(Input.GetKey(KeyCode.Space) && isGrounded())
            jump();
        // animator inputs.
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isGrounded());
        
    }

    private void jump() 
    {
         body.linearVelocity = new Vector2(body.linearVelocityX, jump_Speed);
         anim.SetTrigger("jump");

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool isWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.01f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack() 
    {
        return horizontalinput == 0 && isGrounded();
    }
}
