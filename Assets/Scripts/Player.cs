using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private int _animSpeed = Animator.StringToHash("Speed");
    private const string _vertical = "Vertical";
    private const string _horizontal = "Horizontal";

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(z: Input.GetAxis(_vertical), y: 0, x: Input.GetAxis(_horizontal));
        _animator.SetFloat(_animSpeed, moveInput.magnitude);

        if (moveInput.magnitude > 0.1F)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveInput), Time.deltaTime * _speedRotation);
        }
        _rigidbody.velocity = moveInput * _speed;

    }
}
