using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static Ball Instance { get; private set; }

    [SerializeField] private Transform paddle;
    [SerializeField] private float maxBounceAngle = 75f;

    private Vector3 offset = new Vector3(0, 0.25f, 0);
    private Rigidbody2D ballRigidBody2D;
    private bool launched;
    private float ballSpeed = 5f;

    public event EventHandler onBrickDestroy;

    private void Awake()
    {
        Instance = this;

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
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.TryGetComponent(out Paddle paddle))
        {
            BounceFromPaddle(collision2D);
        } else if (collision2D.gameObject.TryGetComponent(out Brick brick))
        {
            onBrickDestroy?.Invoke(this, EventArgs.Empty);
            brick.TakeHit();
        }
        
        KeepConstantSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        
    }

    private void KeepConstantSpeed()
    {
        if (ballRigidBody2D.linearVelocity.sqrMagnitude > 0.01f)
        {
            ballRigidBody2D.linearVelocity = ballRigidBody2D.linearVelocity.normalized * ballSpeed;
        }
    }

    private void BounceFromPaddle(Collision2D collision2D)
    {
        Vector2 contactPoint = collision2D.GetContact(0).point;

        float paddleWidth = collision2D.collider.bounds.size.x;

        float paddleCenter = collision2D.collider.bounds.center.x;

        float hitPosition = (contactPoint.x - paddleCenter) / (paddleWidth / 2);

        float angle = hitPosition * maxBounceAngle;

        Vector2 direction = Quaternion.Euler(0, 0, -angle) * Vector2.up;

        ballRigidBody2D.linearVelocity = direction * ballSpeed;
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
