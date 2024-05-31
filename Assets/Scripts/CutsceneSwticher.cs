using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CusceneSwither : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject transition;
    
    public int nextScene;

    void Start()
    {
        if(playableDirector != null){
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director){
        if(director = playableDirector){
            Transition transitionScript = transition.GetComponent<Transition>();
            transitionScript.TriggerStart();
        }
    }

    void OnDestroy(){
        if(playableDirector != null){
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }

}
