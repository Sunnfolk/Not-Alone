using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cutscenes
{
    public class LoadEnd : MonoBehaviour
    {
        public void LoadEndScene()
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
