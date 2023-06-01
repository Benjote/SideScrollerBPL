using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonCargarNivel : MonoBehaviour
{
    private Button boton;

    private void Awake()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(CargarNivel);
    }

    private void CargarNivel()
    {
        string nombreNivelActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nombreNivelActual);
    }
}