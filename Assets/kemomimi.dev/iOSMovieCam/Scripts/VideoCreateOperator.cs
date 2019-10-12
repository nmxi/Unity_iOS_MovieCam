using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoCreateOperator : MonoBehaviour {

    private VideoCreator.VideoCreatorUnity videoCreatorUnity;

    public RenderTexture texture = null;

    public Text text;

    private bool isRecording = false;

    // Use this for initialization
    void Start () {
        videoCreatorUnity = new VideoCreator.VideoCreatorUnity(Application.temporaryCachePath + "/tmp.mov", true, 1080, 1920);
	}
	
	// Update is called once per frame
	void Update () {

        if (!isRecording) return;

        if (texture == null) return;

        videoCreatorUnity.Append(texture);

	}

    public void StartRecord()
    {
        if (isRecording) return;
        videoCreatorUnity.StartRecording();
        isRecording = true;

        text.text = "start recording !!";
    }

    public void FinishRecord()
    {
        if (!isRecording) return;
        videoCreatorUnity.FinishRecording();
        isRecording = false;

        text.text = "finish recording !!";
    }
}
