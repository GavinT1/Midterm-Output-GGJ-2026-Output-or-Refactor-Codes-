using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame 
{
    public class GameController_Messy : MonoBehaviour
    {
        public static GameController_Messy I; 

        [Header("Factory")]
        public GameplayFactory factory; 

        [Header("Player")]
        public Transform player;
        public Transform firePoint;

        [Header("Game State")]

        public int gameState = 0;

        [Header("Spawning")]
        public Transform[] spawnPoints;
        public float spawnInterval = 0.6f;
        private float spawnTimer;

        private void Awake()
        {
            
            if (I == null) I = this;
        }

        public void GameOver()
        {
            gameState = 3;
            Time.timeScale = 0.7f; 
            Debug.Log("Game Over");
        }

        public void TogglePause()
        {
            if (gameState == 1) gameState = 2;
            else if (gameState == 2) gameState = 1;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update()
        {
            if (gameState == 1) 
            {
                HandleSpawning();
            }
        }

        private void HandleSpawning()
        {
            if (spawnPoints == null || spawnPoints.Length == 0) return;

            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer = 0f;
                int i = Random.Range(0, spawnPoints.Length);
                Transform p = spawnPoints[i];

                if (factory != null)
                {
                    factory.SpawnEnemy(p.position, p.rotation);
                }
            }
        }

        public void Shoot()
        {
            if (factory != null)
            {
                factory.SpawnBullet(firePoint.position, firePoint.rotation);
            }
        }
    }
}