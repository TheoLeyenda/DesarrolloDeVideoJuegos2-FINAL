using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAll : MonoBehaviour {

    public void ReStart()
    {
        DataStructure.auxiliaryDataStructure.playerData.life = 3;
        DataStructure.auxiliaryDataStructure.nextLevel.level = 0;
        DataStructure.auxiliaryDataStructure.playerData.score = 0;
        SceneManager.LoadScene("SplashScreen");
    }

}
