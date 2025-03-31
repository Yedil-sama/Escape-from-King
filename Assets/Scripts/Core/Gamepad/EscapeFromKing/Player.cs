using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class Player : Character
    {
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private Weapon selectedWeapon;
        public void Initialize()
        {

        }
        public void Start()
        {
            movement = GetComponent<PlayerMovement>();
            selectedWeapon = GetComponentInChildren<Weapon>();
        }
        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && selectedWeapon != null)
            {
                selectedWeapon.Attack();
            }
        }
    }

}
