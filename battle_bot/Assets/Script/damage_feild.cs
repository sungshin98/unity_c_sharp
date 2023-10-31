/*using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float damageAmount = 10.0f; // 데미지 양

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어 캐릭터인지 확인
        if (other.CompareTag(""Player""))
        {
            // 플레이어 캐릭터에게 데미지 부여
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}*/