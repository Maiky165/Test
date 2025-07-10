using UnityEngine;

public class Movement : MonoBehaviour
{
    public float force = 10f;
    public Rigidbody2D rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) rb.AddForce(new Vector2(0, force));
    }
}
