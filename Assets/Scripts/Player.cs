using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float deathLimit = -50f; // L�mite del eje Y para la muerte

    void Update()
    {
        if (transform.position.y < deathLimit)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScene"); // Carga la escena del men� de muerte
    }
}
