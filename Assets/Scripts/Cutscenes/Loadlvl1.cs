using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cutscenes
{
    public class Loadlvl1 : MonoBehaviour
    {
        public void LoadScene1()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
