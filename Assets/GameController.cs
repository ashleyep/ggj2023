using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public float destinationY = -208f;
    public float speed = 50f;
    public RectTransform[] panels;
    public Button startButton;
    public GameObject growingAnimation;
    public GameObject loopingStartAnimation;
    public GameObject longStem;
    public GameObject justStem;


    private RectTransform topPanel;
    private RectTransform middlePanel;
    private Vector3 startPosTop;
    private Vector3 startPosMiddle;
    private Vector3 topOriginalPos;
    private Vector3 middleOriginalPos;
    private int panelCounter = 0;

    private bool playing = false;

    
    void Start() {
        startPosTop = new Vector3(0, 430);
        startPosMiddle = new Vector3(0, 0);

        loopingStartAnimation.SetActive(false);
        //longStem.SetActive(false);
        justStem.SetActive(false);
        startButton.gameObject.SetActive(false);
        StartCoroutine(WaitAndSwitchStartScreenAnim());
    }
    
    void Update()
    {
        if (playing) {
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

    void ResetTopPanel() {
        topPanel.anchoredPosition = topOriginalPos; // move back to original pos
        panelCounter++; // increment counter
        topPanel = panels[panelCounter % panels.Length]; // get next panel from list
        topOriginalPos = topPanel.anchoredPosition; // save original pos
        topPanel.anchoredPosition = startPosTop; // move to top of screen
    }

    void ResetMiddlePanel() {
        middlePanel.anchoredPosition = middleOriginalPos; // move back to original pos
        panelCounter++; // increment counter
        middlePanel = panels[panelCounter % panels.Length]; // get next panel from list
        middleOriginalPos = middlePanel.anchoredPosition; // save original pos
        middlePanel.anchoredPosition = startPosTop; // move to top of screen
    }

    public void StartGameOnClick() {

        panelCounter++;
        topPanel = panels[panelCounter];
        topOriginalPos = topPanel.anchoredPosition;
        topPanel.anchoredPosition = startPosTop;

        playing = true;
        startButton.gameObject.SetActive(false);
        StartCoroutine(WaitAndSwitchScreenAnim2());

    }

    IEnumerator WaitAndSwitchStartScreenAnim() {

        yield return new WaitForSeconds(3f);
        growingAnimation.SetActive(false);
        loopingStartAnimation.SetActive(true);
        longStem.SetActive(true);

        middlePanel = panels[panelCounter];
        middleOriginalPos = middlePanel.anchoredPosition;
        middlePanel.anchoredPosition = startPosMiddle;
        startButton.gameObject.SetActive(true);

        yield break;

    }

    IEnumerator WaitAndSwitchScreenAnim2() {
        yield return new WaitForSeconds(0.8f);
        justStem.SetActive(true);
        yield break;
    }
}
