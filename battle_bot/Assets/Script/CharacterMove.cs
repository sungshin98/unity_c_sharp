using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController characterController;
    public float moveSpeed = 10f;
    public float turnSpeed = 180f;
    public float gravity = -20f;
    public float yVelocity = 0;

    [SerializeField]
    private int playerNumber = 1; // Serialize 필드를 사용하여 플레이어 번호를 설정합니다.
    public Text keyText;
    private string playerPrefix = "Player ";
    void Start()
    {
        keyText.text = "Key Input: ";
    }

    void Update()
    {
        float h = 0;
        float v = 0;
        if (playerNumber == 1 || playerNumber == 2)
        {
            keyText.text = "Key Input: " + GetKeyInput(); // GetKeyInput 함수를 호출하여 입력된 키를 표시합니다.
        }
        if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                h = -1; // 왼쪽 방향키 입력
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                h = 1; // 오른쪽 방향키 입력
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                v = 1; // 위쪽 방향키 입력
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                v = -1; // 아래쪽 방향키 입력
            }
        }
        else if (playerNumber == 1)
        {
            // 2플레이어의 방향 키 입력 처리 (키 코드를 수정하여 원하는 키를 사용할 수 있습니다)
            if (Input.GetKey(KeyCode.A))
            {
                h = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                h = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                v = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                v = -1;
            }
        }

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
        if (playerNumber == 1 || playerNumber == 2)
        {
            keyText.text = "Key Input: " + GetKeyInput(); // GetKeyInput 함수를 호출하여 입력된 키를 표시합니다.
        }
    }
    string GetKeyInput()
    {
        string inputText = playerPrefix + playerNumber + " ";

        if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputText += "<-, ";
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputText += "->, ";
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                inputText += "/\\, ";
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                inputText += "\\/, ";
            }
        }
        else if (playerNumber == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                inputText += "A, ";
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputText += "D, ";
            }
            if (Input.GetKey(KeyCode.W))
            {
                inputText += "W, ";
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputText += "S, ";
            }
        }

        return inputText.TrimEnd(' ', ','); // 끝의 쉼표 및 공백을 제거하여 표시합니다.
    }
}