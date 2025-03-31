using UnityEngine;

namespace Core.RealWorld
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public Player player;
        public Transform worldTransform;
        [SerializeField] private InventoryManager inventoryManager;
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (player == null)
            {
                player = FindObjectOfType<Player>();
            }
            InitializeInventory();
        }
        public void InitializeInventory()
        {
            inventoryManager.Initialize(player);
        }
    }

}
