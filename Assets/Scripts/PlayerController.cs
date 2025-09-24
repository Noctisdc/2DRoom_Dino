using UnityEngine;
using TMPro; //libreria para usar textos

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //variable para guardar la velocidad
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;
    public TextMeshProUGUI textScore;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        //leer las teclas WASD o las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //creamos un vector para direccion del movimiento
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

    }

    //función especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo
    //trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            score = score + 1;
            UpdateTextScore();

            Destroy(other.gameObject);
            Debug.Log("Collected!!!");
            Debug.Log("Score: " + score);


        }
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("has recolectado la llave!");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Water"))
        {
            hasWater = true;
            Debug.Log("has tocado el agua y no puedes ganar!");
            Destroy(gameObject);
        }

        //condicion de victoria
        if (score >= 3 && hasKey && !hasWater)
        {
            Debug.Log("Has ganado, Tienes suficientes puntos y la llave!");
        }


    }

    void UpdateTextScore()
    {
        textScore.text = "Score: " + score;
    }

    

}
