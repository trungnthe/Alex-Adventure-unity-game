using UnityEngine;
using UnityEngine.SceneManagement; // Để sử dụng SceneManager

public class SawMovement : MonoBehaviour
{
    [SerializeField] Transform[] points; // Các điểm lưỡi cưa sẽ di chuyển qua
    [SerializeField] float speed = 5f; // Tốc độ di chuyển của lưỡi cưa
    [SerializeField] GameObject player;
    [SerializeField] GameObject switchh;


    private int currentPointIndex = 0;
    private Transform targetPoint;
    private bool moving = false; // Biến để kiểm tra xem lưỡi cưa còn di chuyển hay không


    void Start()
    {
        if (points.Length > 0)
        {
            targetPoint = points[currentPointIndex];
        }
    }

    void Update()
    {
        Switchhh sw = switchh.GetComponent<Switchhh>();
        if (targetPoint != null && sw.isOpen)
        {
            // Di chuyển lưỡi cưa tới điểm đích
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

            // Kiểm tra nếu lưỡi cưa đã tới điểm đích
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                currentPointIndex++;
                if (currentPointIndex < points.Length)
                {
                    targetPoint = points[currentPointIndex];
                }
                else
                {
                    moving = false; // Dừng di chuyển khi đạt tới điểm cuối cùng
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Cham vao roi chet roii");
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.Die();
               
            }
        }
    }

}
