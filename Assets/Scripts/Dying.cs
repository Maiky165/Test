using UnityEngine;

public class Dying : MonoBehaviour
{
    public GameManager gameManager;     
    public Rigidbody2D rbPlayer;
    public float deathTorque = 10f;     //amount of torque applied on the player on death


    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) Die();     ///triggers death on contact with an obstacle  
    }


    private void Die()
    {
        rbPlayer.constraints = RigidbodyConstraints2D.None;     //removes the freeze of the rotation of the player
        rbPlayer.AddTorque(deathTorque);                        //adds torque on the player
        gameManager.GameOver();                                 //calls a GameOver through the GameManager
    }
}
