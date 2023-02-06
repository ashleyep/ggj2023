using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollingDown : MonoBehaviour
{
    
    public float destinationY = -208f;
    public float speed = 50f;
    public RectTransform[] panels;


    private RectTransform topPanel;
    private RectTransform middlePanel;
    private Vector3 startPosTop;
    private Vector3 startPosMiddle;
    private Vector3 topOriginalPos;
    private Vector3 middleOriginalPos;
    private int panelCounter = 0;

    [HideInInspector]
    // public bool playing = false;
    private bool playing_here = false;
    
    void Start() {
        startPosTop = new Vector3(0, 427);
        startPosMiddle = new Vector3(0, 0);
        panelCounter++;
        topPanel = panels[panelCounter];
        topOriginalPos = topPanel.anchoredPosition;
        topPanel.anchoredPosition = startPosTop;

        middlePanel = panels[panelCounter];
        middleOriginalPos = middlePanel.anchoredPosition;
        middlePanel.anchoredPosition = startPosMiddle;

        playing_here = true;

        // loopingStartAnimation.SetActive(false);
        // //longStem.SetActive(false);
        // justStem.SetActive(false);
        // startButton.gameObject.SetActive(false);
        // bar.SetActive(false);
        // StartCoroutine(WaitAndSwitchStartScreenAnim());
    }
    
    void Update()
    {
        if (playing_here) {
            var step =  speed * Time.deltaTime;
            if (topPanel != null) {
                topPanel.anchoredPosition = Vector2.MoveTowards(topPanel.anchoredPosition, new Vector2(topPanel.anchoredPosition.x, destinationY), step);
                if (topPanel.anchoredPosition.y == destinationY) {
                    ResetTopPanel();
                }
            }
            if (middlePanel != null) {
                middlePanel.anchoredPosition = Vector2.MoveTowards(middlePanel.anchoredPosition, new Vector2(middlePanel.anchoredPosition.x, destinationY), step);
                if (middlePanel.anchoredPosition.y == destinationY) {
                    ResetMiddlePanel();
                }
            }
        }
    }
    // void ContinueOrEnd() {
        
    // }
    // public void ContinueOnClick() {
    //     //start loop again
    //     panelCounter = 1;
    //     playing = true;

    //     StartCoroutine(WaitAndSwitchScreenAnim2());
    //     StartCoroutine(ScoreKeeper());
        
    // }
    // public void EndOnClick() {
    //     //start loop again
    //     SceneManager.LoadScene("endscene");
    // }
    void ResetTopPanel() {
        topPanel.anchoredPosition = topOriginalPos; // move back to original pos
        panelCounter++; // increment counter
        topPanel = panels[panelCounter]; // get next panel from list
        topOriginalPos = topPanel.anchoredPosition; // save original pos
        topPanel.anchoredPosition = startPosTop; // move to top of screen
         if (panelCounter == 3) {
            playing_here = false;
            // topPanel = panels[44]; // get next panel from list
            // topOriginalPos = topPanel.anchoredPosition; // save original pos
            // topPanel.anchoredPosition = startPosTop; // move to top of screen
        }
       
    }

    void ResetMiddlePanel() {
        middlePanel.anchoredPosition = middleOriginalPos; // move back to original pos
        panelCounter++; // increment counter
        middlePanel = panels[panelCounter]; // get next panel from list
        middleOriginalPos = middlePanel.anchoredPosition; // save original pos
        middlePanel.anchoredPosition = startPosTop; // move to top of screen
        if (panelCounter == 3) {
            playing_here = false;
            // middlePanel = panels[44]; // get next panel from list
            // middleOriginalPos = middlePanel.anchoredPosition; // save original pos
            // middlePanel.anchoredPosition = startPosTop; // move to top of screen
        }
       
    }

    // public void StartGameOnClick() {


    //     startButton.gameObject.SetActive(false);
    //     StartCoroutine(WaitAndSwitchScreenAnim2());
    //     StartCoroutine(ScoreKeeper());

    // }

    // IEnumerator ScoreKeeper() {
    //     while (playing) {
    //         yield return new WaitForSeconds(0.5f);
    //         score++;
    //         scoreText.text = score.ToString();
    //     }
    // }

    // IEnumerator WaitAndSwitchStartScreenAnim() {

    //     yield return new WaitForSeconds(3f);
    //     growingAnimation.SetActive(false);
    //     loopingStartAnimation.SetActive(true);
    //     longStem.SetActive(true);

    //     startButton.gameObject.SetActive(true);

    //     yield break;

    // }

    // IEnumerator WaitAndSwitchScreenAnim2() {
    //     yield return new WaitForSeconds(0.8f);
    //     justStem.SetActive(true);
    //     bar.SetActive(true);
    //     yield break;
    // }

}
