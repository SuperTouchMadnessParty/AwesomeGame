using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {
    private AwesomeGame awesomeGame;
    private bool gamePaused;
    public GameObject leaderBtn;
    public GameObject settingBtn;
    public GameObject restartBtn;
    public Vector2 settingBtnAnchor = new Vector2(0, 0);
    public Vector2 restartBtnAnchor = new Vector2(0, 0);
    public Vector2 leaderBtnAnchor = new Vector2(0, 0);

    private float timeToPan = 20; 

    // Use this for initialization
    void Start()
    {
        GameObject game = GameObject.Find("Game");
        if (game != null)
        {
            awesomeGame = game.GetComponent<AwesomeGame>();
            gamePaused = awesomeGame.IsPaused;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gamePaused)
        {
            buttonPan(leaderBtn, leaderBtnAnchor, true);
        }
	}

    void buttonPan(GameObject button, Vector2 anchorPnt, bool bIn)
    {
        RectTransform btnTransform = button.GetComponent<RectTransform>();
        if(btnTransform.position.x < anchorPnt.x)
        {
            btnTransform.position = new Vector2(btnTransform.position.x + (Time.deltaTime / timeToPan), btnTransform.position.y);
        }
    }
}
