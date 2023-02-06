using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
// Use t$$anonymous$$s for initialization
     public void LoadSceneSelectEnd()
     {
         SceneManager.LoadScene("endlessFun");
     }
     public void LoadSceneSelectInstructions() {
        SceneManager.LoadScene("instructions");
     }

     public void LoadSceneMain() {
        Debug.Log("called LoadSceneMain");
        SceneManager.LoadScene("Bella2");
     }

}
