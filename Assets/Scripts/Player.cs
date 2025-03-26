using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Weapon selectedWeapon;
    public void Initialize()
    {

    }
    public void Start()
    {
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
