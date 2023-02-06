using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectRightNote : MonoBehaviour
{
    // Update is called once per frame

        //detect if image is between -200 and -400

    //list of whats currently in the box
    // when someting enters the trigger add it to the list
    //when a key is pressed loop through the list and see if that key corresponds to 
    // something in the list. if not, fail state
    // if so, remove that item from teh list.
    // if something makes it to the ontrigger exit and it's still in the list
    // then fail state 
    public List<string> objectsEntered;
    public GameController controller;
    bool fail;
    public bool endlessMode;
    void Start() {
        objectsEntered = new List<string>();
        fail = false;
        // endlessMode = false;
    }
    
    void Update () {
        Debug.Log("endless" + endlessMode);

        if (fail && !endlessMode) {
            controller.playing = false;
            SceneManager.LoadScene("Bella2");
        }

        // Debug.Log("update");
        if (Input.GetKeyDown(KeyCode.A)) {
            for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "a") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("a pressed");
        }
        if (Input.GetKeyDown(KeyCode.S)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "s") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("s pressed");
        }
        if (Input.GetKeyDown(KeyCode.D)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "d") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("d pressed");
        }
        if (Input.GetKeyDown(KeyCode.F)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "f") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("f pressed");
        }
        if (Input.GetKeyDown(KeyCode.J)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "j") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("j pressed");
        }
        if (Input.GetKeyDown(KeyCode.K)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "k") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("k pressed");
        }
        if (Input.GetKeyDown(KeyCode.L)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "l") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("l pressed");
        }
        if (Input.GetKeyDown(KeyCode.Semicolon)){
             for (int i = 0; i < objectsEntered.Count;i++){
                if (objectsEntered[i] == "semicolon") {
                    objectsEntered.RemoveAt(i);
                    fail = false;
                }
            }
            Debug.Log("; pressed");
        }

    }
     public void changePLZ()
     {
   
        endlessMode = true;
 
     }

     
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("I'm the trigger, someone has entered");
        Debug.Log("other tag is " + other.tag);
        objectsEntered.Add(other.tag);
        
    }
    
    private void OnTriggerExit2D(Collider2D other){
        Debug.Log("OnTriggerExit Event" + other.tag);
        if (objectsEntered.Contains(other.tag)) {
            fail = true;
        }
        Debug.Log(fail);
    }

    // Update is called once per frame
}
