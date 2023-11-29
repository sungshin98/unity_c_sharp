using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Slider externalPlayer1HealthSlider;
    public Slider externalPlayer2HealthSlider;
    private int player1Health = 100;
    private int player2Health = 100;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateHealthSlider();
    }

    public int GetPlayerHealth(int playerNumber)
    {
        return (playerNumber == 1) ? player1Health : player2Health;
    }

    public void SetPlayerHealth(int playerNumber, int health)
    {
        if (playerNumber == 1)
        {
            player1Health = health;
        }
        else if (playerNumber == 2)
        {
            player2Health = health;
        }

        UpdateHealthSlider();
        CheckGameOver();
    }

    void UpdateHealthSlider()
    {
        externalPlayer1HealthSlider.value = player1Health;  // 현재는 player1Health만 업데이트하도록 되어 있었음
        externalPlayer2HealthSlider.value = player2Health;  // 만약 player2Health도 표시하려면 이 줄을 주석 해제하세요
    }

    void CheckGameOver()
    {
        if (player1Health <= 0 || player2Health <= 0)
        {
            Debug.Log("Game Over!");
            // 원하는 처리를 여기에 추가
        }
    }
}