using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUp : MonoBehaviour
{
    [SerializeField] GameObject[] doors; // Mảng các object cửa
    [SerializeField] float moveDistance = 5f; // Khoảng cách cửa sẽ di chuyển lên
    [SerializeField] float moveSpeed = 2f; // Tốc độ di chuyển của cửa
    private Vector3[] initialPositions; // Mảng vị trí ban đầu của các cửa
    private bool isMoving = false; // Kiểm tra trạng thái cửa có đang di chuyển hay không
    [SerializeField] GameObject saw;

    void Start()
    {
        Debug.Log("DoorUp script started");

        // Lưu lại vị trí ban đầu của tất cả các cửa
        initialPositions = new Vector3[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            initialPositions[i] = doors[i].transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DoorUp called");
        if (other.CompareTag("Player")) // Kiểm tra xem object va chạm có tag là Player hay không
        {
            Debug.Log("Player entered the trigger");
            isMoving = true; // Bắt đầu di chuyển cửa
            saw.GetComponent<SawMovement>().enabled=true;
        }
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
