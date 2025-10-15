using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force = 10f;         //the force that gets applied on the Rigidbody
    public Rigidbody2D playerRb;      //the Rigidbody2D of the player


    //Using FixedUpdate when working with a Rigidbody
    void FixedUpdate()
    {
        //if Space is being pressed a vertical force pointing up is applied on the Rigidbody
        if (Input.GetKey(KeyCode.Space)) playerRb.AddForce(new Vector2(0, force));
    }
}
