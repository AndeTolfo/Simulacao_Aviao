using UnityEngine;

public class collisionAviao : MonoBehaviour
{
     public AudioClip explosao;
     public AudioController audioController;

    public GameObject explosionPrefab; // Prefab da explosão

    private Vector3 targetPosition = new Vector3(98f, 135f, 260f); // Posição alvo para o avião chegar
    private float flyingSpeed = 200f; // Velocidade de voo

    private Rigidbody rb;
    private bool isMoving = true; // Indica se o avião está em movimento
    private bool hasCollided = false; // Indica se já ocorreu uma colisão

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 initialPosition = transform.position;
        Vector3 direction = (targetPosition - initialPosition).normalized;
        transform.rotation = Quaternion.LookRotation(direction); // Orienta o avião na direção correta
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        // Move o avião na direção especificada com a velocidade definida
        Vector3 movement = transform.forward * flyingSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se houve colisão e se é a primeira colisão
        if (!hasCollided)
        {
            hasCollided = true;
            isMoving = false;
            rb.velocity = Vector3.zero;
            Explode();
            audioController.ToqueSFX(explosao);
        }
    }

    private void Explode()
    {
        // Instancia o prefab da explosão na posição atual do avião
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 3f); // Define um tempo para destruir a explosão após alguns segundos
        PlayParticles();
        Debug.Log("O avião colidiu e explodiu!");
        // Aqui você pode adicionar outras ações relacionadas à explosão, como tocar um som, exibir uma animação, etc.
                // Destruir o avião
        Destroy(gameObject);
        
   
    }


    private void PlayParticles()
    {
        var children = transform.GetComponentsInChildren<ParticleSystem>();
        for (var i = 0; i < children.Length; ++i)
        {
            children[i].Play();
        }
        var current = GetComponent<ParticleSystem>();
        if (current != null) current.Play();
    }
}
