using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController characterController;
    public float moveSpeed = 10f;
    public float turnSpeed = 180f; // 회전 속도 추가

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // 방향 전환을 Q와 E 키로 구현
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }

        // yvelocity와 관련된 점프 부분 제거

        characterController.Move(moveDirection * Time.deltaTime);
    }
}