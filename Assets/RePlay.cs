using UnityEngine;
using System.Collections;

public class RePlay : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        if (gameManager.recording) {
            Record();
        } else {
            Playback();
        }

	}

    void Playback () {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
//        Debug.Log("Playing frame: " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void Record () {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
//        Debug.Log("Frame number: " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

// Structure for storing time, position and rotation
public struct MyKeyFrame {

    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }

}