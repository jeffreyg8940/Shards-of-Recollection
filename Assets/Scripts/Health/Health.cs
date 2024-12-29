using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health settings")]
    [SerializeField] private float startingHealth;
    public float CurrentHealth {get; private set;}

    private Animator anim;
    private bool dead;

    [Header ("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numbofFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        //refs to diff components
        anim = GetComponent<Animator>();
        CurrentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, startingHealth);

        Debug.Log(CurrentHealth);

        
        if(CurrentHealth > 1)
        {
            anim.SetTrigger("Hurt");
            //Iframes
            StartCoroutine(Iframing());
        }
        else 
        {
            if(!dead)
            {
                anim.SetTrigger("death");
                //disable all compononents
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                dead = true;
            }

        }
    }

    private void Update()
    {           

    }

    public void playerHeal(float _value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Iframing()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numbofFlashes; i++)
        {
            spriteRend.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numbofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numbofFlashes * 2));
        }
        // time till frames stop
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
