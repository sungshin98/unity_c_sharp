using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController characterController;
    public float moveSpeed = 10f;
    public float turnSpeed = 180f;
    public float gravity = -20f;
    public float yVelocity = 0;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // AD 키로 좌우 방향 전환
        transform.Rotate(Vector3.up * h * turnSpeed * Time.deltaTime);

        Vector3 moveDirection = new Vector3(0, 0, v);

        // WS 키로 전진 및 후퇴
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // 점프 부분은 유지

        // 중력 및 이동 처리
        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}