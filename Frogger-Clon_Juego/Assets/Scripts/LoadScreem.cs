using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreem : MonoBehaviour {

    // Use this for initialization
    public Text percentage;
    public Text LevelLoad;
    public GameObject load;
    public float percentageLoadMaximun;
    public float loadSpeed;
    private float percentageLoad;
    private int loadLevel;
    private DataStructure dataStructure;
	void Start () {
        System.GC.Collect();
        percentageLoad = 0;
        dataStructure = DataStructure.auxiliaryDataStructure;
        LevelLoad.text = "Nivel "+(dataStructure.nextLevel.level +1);
        if (dataStructure == null)
        {
            Debug.Log("ES NULO ÑERI");
        }
        dataStructure.nextLevel.level++;
    }

    // Update is called once per frame
    void Update() {
        UpdateLoadBar();
	}
    public void UpdateLoadBar()
    {
        percentageLoad = percentageLoad + Time.deltaTime * loadSpeed;
        if (load != null)
        {
            float z = (float)percentageLoad / (float)percentageLoadMaximun;
            Vector3 ScaleBar = new Vector3(1, 1, z);
            load.transform.localScale = ScaleBar;
        }
        percentage.text = "" + (int)percentageLoad + "%";
        if (percentageLoad >= percentageLoadMaximun)
        {
            percentageLoad = 0;
            SceneManager.LoadScene(dataStructure.nextLevel.level);
        }
    }
    public void ResetLevel()
    {
        dataStructure.nextLevel.level = 0;
        SceneManager.LoadScene("SplashScreen");
    }
}