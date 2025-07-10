using UnityEngine;

public class Dying : MonoBehaviour
{
    public Movement playerMovement;
    public LevelManager levelManager;



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) Die();
    }


    private void Die()
    {
        playerMovement.enabled = false;
        levelManager.enabled = false;
    }
}
