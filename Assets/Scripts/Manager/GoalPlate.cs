using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlate : MonoBehaviour
{

    AudioSource theAudio;
    NoteManager theNote;

    TimingManager theTimingManager;

    Result theResult;

    int goalcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        theNote = FindObjectOfType<NoteManager>();
        
        theTimingManager = GetComponent<TimingManager>();

        theResult = FindObjectOfType<Result>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Note"))
        {
            goalcount += 1;
            Debug.Log("count");
            if(goalcount >= 100)//theTimingManager.boxNoteList.Count)
            {
                theAudio.Play();
                theNote.RemoveNote();

                theResult.ShowResult();
            }
            
            //PlayerController.s_canPresskey = false;

        }
    }

}
