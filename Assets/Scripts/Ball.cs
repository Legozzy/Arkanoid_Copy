using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D ballRigidBody2D;

    private void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Paddle.Instance.onBallPush += Paddle_onBallPush;
    }

    private void Paddle_onBallPush(object sender, System.EventArgs e)
    {
        float pushForce = 2f;
        //ballRigidBody2D.linearVelocity = Vector2.zero;
        ballRigidBody2D.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
    }
}
