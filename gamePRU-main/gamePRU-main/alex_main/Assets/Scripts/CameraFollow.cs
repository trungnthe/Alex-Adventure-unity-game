using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Transform của nhân vật người chơi
    public Vector3 offset; // Độ lệch của camera so với nhân vật người chơi

    void Start()
    {
        // Nếu chưa thiết lập offset trong Inspector, thiết lập nó ở đây
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Cập nhật vị trí camera theo nhân vật người chơi
        transform.position = player.position + offset;
    }
}