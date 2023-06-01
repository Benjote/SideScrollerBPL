using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonRetry : MonoBehaviour
{
    private Button boton;

    private void Awake()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(ReiniciarEscena);
    }

    private void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}