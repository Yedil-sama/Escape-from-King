using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float maxSpeed = 100f;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    public void Start()
    {
        InitializePlayer();
    }
    private void InitializePlayer()
    {

    }
}
