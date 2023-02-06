using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public float destinationY = -208f;
    public float speed = 50f;
    public RectTransform[] panels;
    public Button startButton;
    // public Button continue;
    public Button end;
    public GameObject growingAnimation;
    public GameObject loopingStartAnimation;
    public GameObject longStem;
    public GameObject justStem;
    public GameObject bar;

    public Button howTo;
    public Button endless;
    public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI title;
    public GameObject title;


    private RectTransform topPanel;
    private RectTransform middlePanel;
    private Vector3 startPosTop;
    private Vector3 startPosMiddle;
    private Vector3 topOriginalPos;
    private Vector3 middleOriginalPos;
    private int panelCounter = 0;
    private int score = 0;

    [HideInInspector]
    public bool playing = false;

    
    void Start() {
        startPosTop = new Vector3(0, 427);
        startPosMiddle = new Vector3(0, 0);

        loopingStartAnimation.SetActive(false);
        //longStem.SetActive(false);
        justStem.SetActive(false);
        startButton.gameObject.SetActive(false);
        bar.SetActive(false);
        howTo.gameObject.SetActive(false);
        endless.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
        StartCoroutine(WaitAndSwitchStartScreenAnim());
    }
    
    void FixedUpdate()
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
    // void ContinueOrEnd() {
        
    // }
    public void ContinueOnClick() {
        //start loop again
        panelCounter = 1;
        playing = true;

        StartCoroutine(WaitAndSwitchScreenAnim2());
        StartCoroutine(ScoreKeeper());
        
    }
    public void EndOnClick() {
        //start loop again
        SceneManager.LoadScene("endscene");
    }
    void ResetTopPanel() {
        topPanel.anchoredPosition = topOriginalPos; // move back to original pos
        panelCounter++; // increment counter
        topPanel = panels[panelCounter]; // get next panel from list
        topOriginalPos = topPanel.anchoredPosition; // save original pos
        topPanel.anchoredPosition = startPosTop; // move to top of screen
         if (panelCounter == 43) {
            playing = false;
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
        if (panelCounter == 43) {
            playing = false;
            // middlePanel = panels[44]; // get next panel from list
            // middleOriginalPos = middlePanel.anchoredPosition; // save original pos
            // middlePanel.anchoredPosition = startPosTop; // move to top of screen
        }
       
    }

    public void StartGameOnClick() {

        panelCounter++;
        topPanel = panels[panelCounter];
        topOriginalPos = topPanel.anchoredPosition;
        topPanel.anchoredPosition = startPosTop;

        playing = true;
        startButton.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        endless.gameObject.SetActive(false);
        StartCoroutine(WaitAndSwitchScreenAnim2());
        StartCoroutine(ScoreKeeper());


    }

    IEnumerator ScoreKeeper() {
        while (playing) {
            yield return new WaitForSeconds(0.5f);
            score++;
            scoreText.text = score.ToString();
        }
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
        end.gameObject.SetActive(true);
        howTo.gameObject.SetActive(true);
        endless.gameObject.SetActive(true);

        yield break;

    }

    IEnumerator WaitAndSwitchScreenAnim2() {
        yield return new WaitForSeconds(0.8f);
        justStem.SetActive(true);
        bar.SetActive(true);
        yield break;
    }

}
