using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement playerMovement;     
    public Rigidbody2D playerRb;
    public LevelManager levelManager;

    public bool gameActive = false;     



    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (gameActive == false && Input.GetKey("r")) {
            StartGame();
        }
    }

    //ends the active game
    //disables player movement script and level segment movement
    public void GameOver()
    {
        playerMovement.enabled = false;
        levelManager.SetActive(false);
        gameActive = false;
    }

    //starts a game
    public void StartGame()
    {   
        //resets player
        playerMovement.gameObject.transform.position = new Vector3(0, 0, 0);    //resets player position
        playerMovement.gameObject.transform.rotation = Quaternion.identity;     //resets player rotation
        playerRb.linearVelocity = new Vector3(0, 0, 0);                         //resets player velocity
        playerRb.angularVelocity = 0;                                           //resets angular velocity of player
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;           //freeues the rotation of the player (got potentially disabled at death)

        //activates necessary components
        playerMovement.enabled = true;                                          //activates player movement   
        levelManager.SetActive(true);                                           //activates level segment movement                       
        if (levelManager.enabled == false) levelManager.enabled = true;         //activates LevelManager
        levelManager.Initiate();                                                //initiates LevelManager

        gameActive = true;                      
    }
}
