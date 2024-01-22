using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private float winTime = 0.0f;
    private bool isInGoal = false;
    public bool isWin = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log("WIN TIME: " + Time.time);
        
    }

    private void FixedUpdate() {
        if(boxPrefab != null){
            float distance = (transform.position - boxPrefab.transform.position).magnitude; 
            if(distance < 0.5f){
                isInGoal = true;
            }
        }
        if(isInGoal){
            winTime += Time.deltaTime;
            Debug.Log("WIN TIME: " + winTime);
            if(winTime > 5.0f){
                isWin = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("You Win!");
            }
        }

    //    if (isInGoal){
    //        if(boxPrefab != null){
    //         float distance = (transform.position - boxPrefab.transform.position).magnitude; 
    //            if(distance < 0.5f){
    //             //wait for 5s
    //             winTime += Time.deltaTime;
    //             Debug.Log("WIN TIME: " + winTime);
    //             if(winTime > 5.0f){
    //                 isWin = true;
    //                 Debug.Log("You Win!");
    //             }   
    //            }
    //        }
    //    }
    }
    private void winning(){
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Box")){
            Debug.Log("Yang bener aja!");
            boxPrefab = other.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Box")){
            Debug.Log("Rugi dong!");
            boxPrefab = null;
            isInGoal = false;
            winTime = 0.0f; 
        }
    }
}
