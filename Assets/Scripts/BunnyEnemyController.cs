using UnityEngine;

public class BunnyEnemyController : MonoBehaviour
{
    public Transform generationPoint;
    public GameObject bunnyPrefab;
    public float generationInterval = 2f;
    public float moveSpeed = 2f;
    public LayerMask groundLayer;

    private float generationTimer;
    private bool isDead = false;

    private void Update()
    {
        if (!isDead)
        {
            // Movimiento del conejo
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Generación de nuevos conejos
            if (generationPoint != null && transform.position.x < generationPoint.position.x && Time.time > generationTimer)
            {
                GenerateBunny();
                generationTimer = Time.time + generationInterval;
            }
        }
    }

    private void GenerateBunny()
    {
        GameObject newBunny = Instantiate(bunnyPrefab, generationPoint.position, Quaternion.identity);
        Rigidbody2D newBunnyRigidbody = newBunny.GetComponent<Rigidbody2D>();
        if (newBunnyRigidbody != null)
        {
            newBunnyRigidbody.freezeRotation = true; // Desactivar la rotación del Rigidbody2D
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D collider = collision.collider;
            ContactPoint2D[] contacts = collision.contacts;

            foreach (ContactPoint2D contact in contacts)
            {
                if (contact.normal.y > 0.5f && (collider.CompareTag("Ground") || IsGroundLayer(collider.gameObject)))
                {
                    isDead = true;
                    // Realizar el giro
                    transform.Rotate(new Vector3(0f, 0f, 180f));
                    // Caer debajo de la pantalla
                    GetComponent<Rigidbody2D>().gravityScale = 1f;
                    GetComponent<Collider2D>().enabled = false;
                    // Destruir después de un tiempo para eliminarlo completamente del juego
                    Destroy(gameObject, 2f);
                    break;
                }
            }
        }
    }

    private bool IsGroundLayer(GameObject obj)
    {
        return (groundLayer.value & (1 << obj.layer)) != 0;
    }
}