using UnityEngine;

namespace UI
{
    public class BasicPickup : MonoBehaviour
    {
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);    
            }
        }
    }
}
