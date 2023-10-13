using UnityEngine;

namespace DefaultNamespace
{
    public class GameStopper
    {
        public static void PauseGame()
        {
            Time.timeScale = 0;
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}