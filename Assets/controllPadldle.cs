using UnityEngine;

public class controllPaddle : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    public float boundX = 2.25f;
    private Rigidbody2D rb2d;

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var vel = rb2d.linearVelocity;
        if (Input.GetKey(moveRight)) {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {
            vel.x = -speed;
        }
        else {
            vel.x = 0;
        }
        rb2d.linearVelocity = vel;

        // trava a posição usando o próprio Rigidbody2D, não o transform
        Vector2 clampedPos = rb2d.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -boundX, boundX);
        rb2d.position = clampedPos;
    }

}
