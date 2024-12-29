using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyRangedHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
