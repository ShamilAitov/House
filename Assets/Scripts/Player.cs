using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private Animator _animator;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(z: Input.GetAxis("Vertical"), y: 0, x: Input.GetAxis("Horizontal"));
        _animator.SetFloat("Speed", moveInput.magnitude);

        if (moveInput.magnitude > 0.1F)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveInput), Time.deltaTime * _speedRotation);
        }

        _rigidbody.velocity = moveInput * _speed;

    }
}
