using UnityEngine;
using UnityEngine.InputSystem;

public class EasyCheckPoint : MonoBehaviour
{
    private static Vector2 _SavedPosition;
    public static GameObject player;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        player = _player;
        SavePlayerPosition();
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ResetPlayerPosition();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SavePlayerPosition();
    }

    public static void ResetPlayerPosition()
    {
        player.transform.position = _SavedPosition;
    }

    public static void SavePlayerPosition()
    {
        _SavedPosition = player.transform.position;
    }
}