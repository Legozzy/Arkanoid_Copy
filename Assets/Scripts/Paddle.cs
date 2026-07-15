using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{

    public static Paddle Instance { get; private set; }

    [SerializeField] private float moveSpeed = 5f;

    public event EventHandler onLaunchRequested;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            onLaunchRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
