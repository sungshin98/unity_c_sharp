/*using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100.0f; // 최대 체력
    private float currentHealth; // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 게임 시작 시 최대 체력으로 초기화
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하로 떨어지면 플레이어를 사망 처리
        }
    }

    void Die()
    {
        // 사망 처리 로직 예시: 게임 오버 화면을 활성화
        GameManager.instance.PlayerDied(gameObject); // GameManager에 플레이어 사망 처리 함수를 호출

        // 또는 리스폰 로직을 실행하거나 다른 동작을 수행할 수 있습니다.
    }
}*/