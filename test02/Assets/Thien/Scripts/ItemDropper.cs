using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject itemPrefab; // Vật phẩm để thả
    public Transform player; // Đối tượng người chơi (hoặc vị trí của người chơi)
    public float dropDistance = 2.0f; // Khoảng cách từ người chơi tới vật phẩm thả
    public int itemCount = 5; // Số lượng vật phẩm có thể thả
    public TMPro.TMP_Text itemCountText; // UI hiển thị số lượng vật phẩm còn lại

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím F
        if (Input.GetKeyDown(KeyCode.F) && itemCount > 0)
        {
            DropItem();
        }
    }

    void DropItem()
    {
        // Tạo vị trí thả vật phẩm trước mặt người chơi
        Vector3 dropPosition = player.position + player.forward * dropDistance;

        // Tạo vật phẩm tại vị trí đã tính
        GameObject droppedItem = Instantiate(itemPrefab, dropPosition, Quaternion.identity);

        // Thêm trọng lực và đảm bảo vật phẩm có Rigidbody để rơi xuống
        Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = droppedItem.AddComponent<Rigidbody>();  // Nếu không có Rigidbody thì thêm vào
        }

        // Thiết lập trọng lực
        rb.useGravity = true;

        // Giảm số lượng vật phẩm
        itemCount--;

        // Cập nhật UI số lượng vật phẩm
        itemCountText.text = "Items: " + itemCount;

        // Nếu không còn vật phẩm, vô hiệu hóa khả năng thả
        if (itemCount == 0)
        {
            itemCountText.text = "No more items to drop!";
        }
    }
}
