using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private float fixedTimestep;
    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        fixedTimestep = Time.fixedDeltaTime;

        PlayerPrefsManager.UnlockLevel(2);
        Debug.Log("Unlock lvl 1 " + PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log("Unlock lvl 2 " + PlayerPrefsManager.IsLevelUnlocked(2));
    }
	
	// Update is called once per frame
	void Update () {
	    if (CrossPlatformInputManager.GetButton ("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused) {
            isPaused = false;
            Resume();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused) {
            isPaused = true;
            Pause();
        }
    }

    void Pause () {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void Resume() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedTimestep;
    }

    void OnApplicationPause (bool pauseStatus) {
        isPaused = pauseStatus;
    }
}
