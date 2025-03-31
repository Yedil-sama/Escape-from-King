using System.Collections.Generic;
using UnityEngine;

namespace Core.RealWorld
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }

        public float throwSpeed = 3f;
        public Player player;
        public PickableItem selectedItem;
        private List<Item> items = new List<Item>();

        public void Initialize(Player player)
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            this.player = player;
        }

        public void PickUpItem(PickableItem item)
        {
            if (item == null) return;

            AddItem(item);
            item.transform.SetParent(player.itemHolder);
            item.transform.localPosition = Vector3.zero;
            selectedItem = item;

            Debug.Log($"Picked up {item.itemName}");
        }
        public void ThrowSelectedItem()
        {
            if (selectedItem == null) return;

            ThrowItem(selectedItem);
            selectedItem = null;
        }
        public void ThrowItem(PickableItem item)
        {
            if (item == null) return;
            if (!items.Contains(item)) return;

            item.transform.SetParent(GameManager.Instance.worldTransform);
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;

                Vector3 throwDirection = player.transform.forward;
                rb.AddForce(throwDirection * throwSpeed, ForceMode.Impulse);
            }

            items.Remove(item);
        }

        public void AddItem(Item item)
        {
            if (item == null || items.Contains(item)) return;

            items.Add(item);

            Debug.Log($"{item.itemName} is added to Inventory");
        }

        public void RemoveItem(Item item)
        {
            if (item == null || !items.Contains(item)) return;

            items.Remove(item);
            if (selectedItem == item)
            {
                selectedItem = null;
            }

            Debug.Log($"{item.itemName} is removed from Inventory");
        }
    }
}
