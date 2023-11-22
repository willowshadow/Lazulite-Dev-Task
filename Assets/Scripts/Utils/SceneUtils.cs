using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneUtils : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}