using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private string _sceneToReload;

        public void ReloadScene()
        {
            SceneManager.LoadScene(_sceneToReload);
        }
    }
}