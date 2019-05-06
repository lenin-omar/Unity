using UnityEngine;

public class Paddle : MonoBehaviour {

    //Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //Cached references
    private GameSession gameSession;
    private Ball ball;

    public void Start() {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y); //Transformada en la posición actual del GameObject
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);   //Para que no vaya más allá de1-15 en eje X
        transform.position = paddlePosition;    //Transformada del paddle (este script pertenece al paddle game object)
    }

    private float GetXPos() {
        if (gameSession.IsAutoPlayEnabled()) {
            return ball.transform.position.x;
        } else {
            //Input.mousePosition.x es la posición en pixeles del mouse en eje x
            //Screen.width es el ancho total de la pantalla en pixleles.
            //Al hacer la división (Input.mousePosition.x / Screen.width) se obtiene un valor de 0.0 a 1.0 (porcontaje de la pantalla en x)
            //screenWidthInUnits es el ancho de la pantalla en unidades de unity
            //mousePositionUnit va de 1.0 a 16.0
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
