using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameMode
{                                                            // b
    idle,
    playing,
    levelEnd
}

public class monkeyBall : MonoBehaviour
{

    static private monkeyBall S;

    [Header("Inscribed")]
    public Text uitLevel;  // The UIText_Level Text
    public Vector3 mapPos; // The place to put map
    public GameObject[] maps;
    public GameObject player;

    [Header("Dynamic")]
    public int level;     // The current level
    public int levelMax;  // The number of levels
    public float mph;
    public GameObject map;    // The current map
    public GameMode mode = GameMode.idle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        S = this; // Define the Singleton                                      // c

        level = 0;

        levelMax = maps.Length;
        StartLevel();
    }

    void StartLevel()
    {
        //reset player position
        playerReset();
        // Get rid of the old map if one exists
        if (map != null)
        {
            Destroy(map);
        }

        map = Instantiate<GameObject>(maps[level]);

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;
            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);                                           // e
        }
    }
    void NextLevel()
    {                                                         // e
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    void playerReset()
    {
        player.transform.position = new Vector3(0, 0.572f, 0);
    }
}
