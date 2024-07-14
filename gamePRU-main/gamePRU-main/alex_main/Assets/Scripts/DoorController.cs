using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] doors; // Mảng các object cửa
    public float moveDistance = 5f; // Khoảng cách cửa sẽ di chuyển lên
    public float moveSpeed = 2f; // Tốc độ di chuyển của cửa
    private Vector3[] initialPositions; // Mảng vị trí ban đầu của các cửa
    private bool isMoving = false; // Kiểm tra trạng thái cửa có đang di chuyển hay không

    void Start()
    {
        Debug.Log("DoorController Start called");
        // Lưu lại vị trí ban đầu của tất cả các cửa
        initialPositions = new Vector3[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            initialPositions[i] = doors[i].transform.position;
        }
    }

    public void StartMovingDoors()
    {
        isMoving = true; // Bắt đầu di chuyển cửa
    }

    void Update()
    {
        if (isMoving)
        {
            Debug.Log("Doors are moving");
            bool allDoorsAtTarget = true;
            for (int i = 0; i < doors.Length; i++)
            {
                // Tính vị trí mới của cửa
                Vector3 targetPosition = initialPositions[i] + new Vector3(0, moveDistance, 0);

                // Di chuyển cửa đến vị trí mới
                doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);

                // Kiểm tra nếu cửa đã tới vị trí mới
                if (doors[i].transform.position != targetPosition)
                {
                    allDoorsAtTarget = false;
                }
            }

            if (allDoorsAtTarget)
            {
                Debug.Log("All doors reached the target position");
                isMoving = false; // Dừng di chuyển cửa
            }
        }
    }
}
