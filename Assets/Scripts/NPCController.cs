using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator animator;
    public Animator closeAnimator;
    public float playerDistanceThreshold = 3f;

    private bool playerIsNearby = false;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calcula la distancia entre el NPC y el jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Verifica si el jugador está lo suficientemente cerca del NPC
            if (distanceToPlayer <= playerDistanceThreshold && !playerIsNearby)
            {
                playerIsNearby = true;
                animator.SetBool("PlayerIsNearby", true);
                closeAnimator.SetBool("PlayerIsNearby", true);
            }
            // Verifica si el jugador se ha alejado del NPC
            else if (distanceToPlayer > playerDistanceThreshold && playerIsNearby)
            {
                playerIsNearby = false;
                animator.SetBool("PlayerIsNearby", false);
                closeAnimator.SetBool("PlayerIsNearby", false);
            }
        }
    }
}