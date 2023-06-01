using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float backgroundParallaxSpeed = 0.5f;

    public Transform backgroundLayer1;
    public Transform backgroundLayer2;

    private float startPositionX;

    private void Start()
    {
        startPositionX = transform.position.x;
    }

    private void Update()
    {
        float backgroundMovement = (Time.time - startPositionX) * backgroundParallaxSpeed;

        // Actualiza la posición de cada capa de fondo
        backgroundLayer1.position = new Vector2(startPositionX + backgroundMovement, backgroundLayer1.position.y);
        backgroundLayer2.position = new Vector2(startPositionX + backgroundMovement * 0.5f, backgroundLayer2.position.y);
    }
}