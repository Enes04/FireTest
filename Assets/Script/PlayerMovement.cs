using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private DetectCollider detectCollider;
    public float speed;
    private DynamicJoystick dynamicJoystick;
    private Animator animator;
    private float animSpeed;
    [HideInInspector]
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        detectCollider = GetComponent<DetectCollider>();
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        transform.Translate(dynamicJoystick.Horizontal * speed * Time.deltaTime, 0, dynamicJoystick.Vertical * speed * Time.deltaTime);
        animSpeed = Mathf.Lerp(animSpeed, 2 * Mathf.Abs(dynamicJoystick.Vertical) + Mathf.Abs(dynamicJoystick.Horizontal), 0.15f);
        animator.SetFloat(Speed, animSpeed);
        if (detectCollider.lookAt)
            transform.GetChild(0).LookAt(transform.GetChild(0).position + new Vector3(dynamicJoystick.Horizontal, 0f, dynamicJoystick.Vertical) * (speed * Time.deltaTime));
    }
}