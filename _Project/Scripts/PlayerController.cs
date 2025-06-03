using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float rotacao = 720f;

    private CharacterController controller;
    private Vector3 direcao;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direcao = new Vector3(horizontal, 0, vertical).normalized;

        if (direcao.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direcao * velocidade * Time.deltaTime);
        }
    }
}
