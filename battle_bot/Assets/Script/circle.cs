using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 톱니 회전 속도 (각도/초)
    public float radius = 1.0f; // 반지름
    public int numTeeth = 10; // 톱니 이빨 수
    public Material lineMaterial; // 원을 그릴 데 사용할 머티리얼

    private LineRenderer lineRenderer;
    private float currentAngle = 0.0f;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = numTeeth + 1;
    }

    void Update()
    {
        currentAngle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        DrawGear();
    }

    void DrawGear()
    {
        float angleIncrement = 360.0f / numTeeth;

        for (int i = 0; i <= numTeeth; i++)
        {
            float angle = i * angleIncrement;
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            Vector3 position = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, position);
        }
    }
}