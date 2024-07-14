using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    // Biến để đặt khoảng cách di chuyển
    public float distance = 2.0f;

    // Biến để đặt tốc độ di chuyển
    public float speed = 2.0f;

    // Biến để kiểm tra chiều di chuyển
    public bool moveUp = true;

    // Vị trí ban đầu của đối tượng
    private Vector3 startPosition;

    void Start()
    {
        // Lưu lại vị trí ban đầu của đối tượng
        startPosition = transform.position;
    }

    void Update()
    {
        // Tính toán vị trí mới theo hàm sin để đối tượng di chuyển lên xuống
        float newY;
        if (moveUp)
        {
            // Nếu moveUp là true, đối tượng di chuyển từ dưới lên trên và ngược lại
            newY = startPosition.y + Mathf.Sin(Time.time * speed) * distance;
        }
        else
        {
            // Nếu moveUp là false, đối tượng di chuyển từ trên xuống dưới và ngược lại
            newY = startPosition.y + Mathf.Sin(Time.time * speed + Mathf.PI) * distance;
        }
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
