using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Transform paddle;

    private Vector3 offset = new Vector3(0, 0.25f, 0);
    private Rigidbody2D ballRigidBody2D;
    private bool launched;
    private float ballSpeed = 3f;

    private void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        ballRigidBody2D.simulated = false;
    }

    private void Start()
    {
        Paddle.Instance.onLaunchRequested += Ball_onLaunchRequested;
    }

    private void Update()
    {
        if (!launched)
        {
            transform.position = paddle.position + offset;
        }

        Debug.Log(ballRigidBody2D.linearVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        KeepConstantSpeed();
    }

    private void KeepConstantSpeed()
    {
        if (ballRigidBody2D.linearVelocity.sqrMagnitude > 0.01f)
        {
            ballRigidBody2D.linearVelocity = ballRigidBody2D.linearVelocity.normalized * ballSpeed;
        }
    }

    private void Ball_onLaunchRequested(object sender, System.EventArgs e)
    {
        if (launched)
        {
            return;
        }

        Vector2 direction = new Vector2(0.4f, 1f).normalized;

        launched = true;
        ballRigidBody2D.simulated = true;

        ballRigidBody2D.linearVelocity = direction * ballSpeed;
    }

    private void OnDestroy()
    {
        if (Paddle.Instance != null)
        {
            Paddle.Instance.onLaunchRequested -= Ball_onLaunchRequested;
        }
    }
}
