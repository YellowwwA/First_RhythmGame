using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    
    public int bpm = 0;
    double currentTime = 0d;

    //bool noteActive = true;

    [SerializeField] Transform[] tfNoteAppear = null;
    //[SerializeField] GameObject goNote = null;    //노트 풀링 코드 추가하면서 기존 노트 생성 코드 주석처리

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager theComboManager;

    void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
        theComboManager = FindObjectOfType<ComboManager>();
    }


    // Update is called once per frame
    void Update()
    {
        //if(noteActive)
        if(GameManager.instance.isStartGame)
        {
            currentTime += Time.deltaTime;

            if(currentTime >= 60d / bpm)
            {
                //아래 세줄 노트 풀링 코드
                GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                int i = Random.Range(0,4);
                t_note.transform.position = new Vector3(tfNoteAppear[i].position.x,tfNoteAppear[i].position.y,tfNoteAppear[i].position.z);   //노트 위치 조절 위해 x+n부분만 코드추가
                t_note.transform.rotation = Quaternion.Euler(0,0,-90.0f);   //노트의 회전 위해 임의 추가                         //노트 위치 조절은 게임 뷰 비율에 따라 달라지는듯
                t_note.transform.localScale = new Vector3(1.5f,1.5f,1.5f);  //노트의 크기 조절 위해 임의 추가                          //나중에 게임뷰 비율 고정시키고 위치 조절 한번에 하기
                t_note.SetActive(true);

                //노트 생성 파괴에 의한 시스템 과부하?때문에 미리 큐에 객체 생성 후 가져다 쓰기만 하는 풀링 사용 위해 잠시 기존의 노트 생성 코드 주석처리
                //GameObject t_noteA = Instantiate(goNote, tfNoteAppear.position, Quaternion.Euler(0,0,-90.0f));
            
                /*
                GameObject t_noteB = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+200f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteC = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+400f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteD = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+600f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteE = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+800f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                */

                //t_noteA.transform.SetParent(this.transform, false); //노트 크기때문에 false 추가
            
                /*
                t_noteB.transform.SetParent(this.transform, false); //노트 크기때문에 false 추가
                t_noteC.transform.SetParent(this.transform, false); //노트 크기때문에 false 추가
                t_noteD.transform.SetParent(this.transform, false); //노트 크기때문에 false 추가
                t_noteE.transform.SetParent(this.transform, false); //노트 크기때문에 false 추가
                */



                theTimingManager.boxNoteList.Add(t_note);

                currentTime -= 60d / bpm;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {   
            if(collision.GetComponent<Note>().GetNoteFlag())
            {    
                theTimingManager.MissRecord();
                theEffectManager.JudgementEffect(4);
                theComboManager.ResetCombo();
            }

            theTimingManager.boxNoteList.Remove(collision.gameObject);



            //노트 풀링 코드 추가 (큐에서 가져온 노트 다시 반환(=노트삭제))
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);

            //Destroy(collision.gameObject); 노트 풀링 위해 기존 노트 파괴 코드 주석처리
        }
    }

    public void RemoveNote()
    {
        //noteActive = false;
        GameManager.instance.isStartGame = false;

        for(int i = 0; i<theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }

        theTimingManager.boxNoteList.Clear();
    }

}
