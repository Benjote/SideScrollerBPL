using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float deathLimit = -50f; // Límite del eje Y para la muerte

    void Update()
    {
        if (transform.position.y < deathLimit)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScene"); // Carga la escena del menú de muerte
    }
}
