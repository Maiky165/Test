using UnityEngine;

public class Dying : MonoBehaviour
{
    public Movement playerMovement;
    public LevelManager levelManager;
    public Rigidbody2D rbPlayer;
    public float torque = 10f;



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) Die();
    }


    private void Die()
    {
        playerMovement.enabled = false;
        levelManager.enabled = false;
        rbPlayer.constraints = RigidbodyConstraints2D.None;
        rbPlayer.AddTorque(torque);
    }
}
