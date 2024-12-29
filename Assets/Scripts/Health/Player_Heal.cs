using UnityEngine;

public class Player_Heal : MonoBehaviour
{

    [Header ("Heal Settings")]
    [SerializeField] private float HealthValue;
    private Health healthComponent; 

    [SerializeField] private float startingHeals;
    public float amountOfHeals; 
    private void Awake()
    {
        healthComponent = GetComponent<Health>();
        amountOfHeals = startingHeals;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && amountOfHeals > 0)
        {
            amountOfHeals -= 1;
            healthComponent.playerHeal(HealthValue);
        }
    }
}
