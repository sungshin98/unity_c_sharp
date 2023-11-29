using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 360f; // 회전 속도를 조절합니다.

    void Update()
    {
        // X축을 기준으로 회전합니다.
        // 회전 속도에 Time.deltaTime을 곱하여 프레임 속도에 독립적으로 회전합니다.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}