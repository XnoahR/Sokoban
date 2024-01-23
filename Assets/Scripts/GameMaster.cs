using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public GoalScript goalScript;
    public GameObject pauseMenu;
    public bool isPaused = false;   
    // Start is called before the first frame update
    void Awake()
    {
        pauseMenu = transform.GetChild(0).gameObject;
    }

    private void Start() {
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {

        //Reset current level
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }else{
                Pause();
            }   
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //Start time
        isPaused = false;
    }
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //Stop time
        isPaused = true;
    }
    
    public void ResumeButton(){
        Resume();
    }

}
