using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterProperties))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour {

    private CharacterProperties _characterProperties;
    private Rigidbody _rb;
    private int _lastFramedAccelerated;

    void Awake() {
        _characterProperties = GetComponent<CharacterProperties>();
        _rb = GetComponent<Rigidbody>();
    }

    void LateUpdate() {
        SlowDownIfNotAccelerated();
    }

    private void SlowDownIfNotAccelerated() {
        if (!IsGrounded()) return;
        if (Time.frameCount == _lastFramedAccelerated) return;
        if (_rb.velocity.sqrMagnitude < 0.06) {
            _rb.velocity = Vector3.zero;
            return;
        };

        Accelerate(-_rb.velocity.ZeroY() / 2);
    }

    public void Accelerate(Vector3 direction) {
        if (_rb.velocity.magnitude < _characterProperties.MaxSpeed) {
            Vector3 changeInVelocity = Vector3.ClampMagnitude(direction * _characterProperties.AccelerationAmount, _characterProperties.AccelerationAmount) * Time.deltaTime;
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity + changeInVelocity, _characterProperties.MaxSpeed);
        }
        _lastFramedAccelerated = Time.frameCount;
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y * 1.05f);
    }
}
