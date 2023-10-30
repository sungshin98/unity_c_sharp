using UnityEngine;

public class RotateObjectInZYPlane : MonoBehaviour
{
    public float rotationSpeed = 30f;  // 회전 속도
    public float radius = 2f;          // 반지름

    private Vector3 center;            // 중심 좌표
    private float angle = 0f;          // 현재 회전 각도

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        // 시간에 따라 회전 각도를 증가시킴
        angle += rotationSpeed * Time.deltaTime;

        // ZY 평면에서의 회전 각도 계산
        float angleZY = angle * Mathf.Deg2Rad;

        // ZY 평면에서의 X, Y, Z 좌표 계산
        float x = center.x + radius * Mathf.Cos(angleZY);
        float z = center.z + radius * Mathf.Sin(angleZY);
        float y = center.y;

        // 오브젝트의 위치를 업데이트하여 ZY 평면에서 원을 그리며 회전
        Vector3 newPosition = new Vector3(x, y, z);
        transform.position = newPosition;

        // 오브젝트의 회전
        transform.rotation = Quaternion.Euler(0f, angle, 0f); // Y 축 주위 회전을 설정
    }
}
