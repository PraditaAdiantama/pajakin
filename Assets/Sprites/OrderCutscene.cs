using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OrderCutscene : MonoBehaviour
{
    private PlayableDirector thisPlayableDirector;

    public Canvas orderCanvas;

    private void Awake()
    {
        orderCanvas.enabled = false;
        thisPlayableDirector = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        thisPlayableDirector.stopped += OnPlayableDirectorStoppped;
    }

    private void OnPlayableDirectorStoppped(PlayableDirector playable)
    {
        if (playable == thisPlayableDirector)
        {
            orderCanvas.enabled = true;
        }
    }
}
