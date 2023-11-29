using UnityEngine;

public class PlayerCollision2 : MonoBehaviour
{
    public float bounceForce = 500f;  // 튕기는 힘의 크기

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("atwp1"))
        {
            // 체력 관리를 GameManager에서 가져와 사용
            int playerHealth = GameManager.instance.GetPlayerHealth(2);  // 플레이어 1의 체력을 가져옴
            playerHealth -= 10;  // 체력 감소
            GameManager.instance.SetPlayerHealth(2, playerHealth);  // 감소된 체력을 GameManager에 설정

            // 접촉한 방향으로 튕겨나가는 힘을 가함
            Vector3 bounceDirection = -(transform.position - collision.contacts[0].point);
            GetComponent<Rigidbody>().AddForce(bounceDirection.normalized * bounceForce);

            // 여기에 다른 로직을 추가할 수 있습니다.
        }
    }
}