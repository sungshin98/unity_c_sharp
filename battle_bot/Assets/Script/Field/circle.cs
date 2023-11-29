using UnityEngine;

public class ShrinkOverTime : MonoBehaviour
{
    public float shrinkInterval = 2.0f; // 크기를 줄이는 주기 (초)
    private float initialScale;
    private float timeSinceLastShrink;
    private float targetScale;

    void Start()
    {
        initialScale = transform.localScale.x; // 또는 원하는 축의 크기로 설정
        targetScale = initialScale * 0.3f; // 기존 크기의 10%
        timeSinceLastShrink = 0.0f;
    }

    void Update()
    {
        timeSinceLastShrink += Time.deltaTime;

        if (transform.localScale.x > targetScale)
        {
            if (timeSinceLastShrink >= shrinkInterval)
            {
                timeSinceLastShrink = 0.0f;
                Shrink();
            }
        }
    }

    void Shrink()
    {
        float newScale = transform.localScale.x - (initialScale * 0.1f);
        transform.localScale = new Vector3(newScale, newScale, newScale);

        if (newScale <= targetScale)
        {
            // 크기가 목표 크기 (기존 크기의 10%) 이하로 떨어졌을 때 축소 중단
            transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            enabled = false; // 이 스크립트 비활성화
        }
    }
}