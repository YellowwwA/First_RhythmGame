using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>(); //생성된 노트를 담는 List -> 판정 범위에 있는지 모든 노트를 비교하기 위함

    int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null; //나중에 Boxes로 수정 + 하이라키 뷰에서 오브젝트 이름도 CenterFrame 아닌가...?

    EffectManager theEffect;
    ScoreManager theScoreManager; //점수계산코드추가
    ComboManager theComboManager;

    AudioManager theAudioManager;

    StatusManager theStatus;

    

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();

        theStatus = FindObjectOfType<StatusManager>();

        theAudioManager = AudioManager.instance;


        timingBoxs = new Vector2[timingRect.Length];

        for(int i = 0; i<timingRect.Length; i++)
        {   //타이밍 박스 설정 (0번째 타이밍 박스 = Perfect(가장 좁은 판정), 3번째 타이밍박스 = Bad 가장 넓은 판정)
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.height/2,  //localPosition.x에서 y로 수정
                              Center.localPosition.x + timingRect[i].rect.height/2);    //localPosition.y + - timingRect[i].rect.width/2
        }
    }


    public void CheckTiming()
    {
        for(int i = 0; i<boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.position.y; //여기도 x에서 y로 수정    localPosition.y;

            for(int x = 0; x<timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    //노트제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //이펙트연출
                    if(x<timingBoxs.Length -1)
                        theEffect.NoteHitEffect();
                    Debug.Log("Hit" + x);
                    theEffect.JudgementEffect(x);

                    judgementRecord[x]++; //판정 기록

                    //점수 증가
                    theScoreManager.IncreaseScore(x);

                    theStatus.CheckShield();

                    theAudioManager.PlaySFX("Clap");

                    return;
                }

            }/*
            if(t_notePosX < 360.0f)
            {
                boxNoteList[i].GetComponent<Note>().HideNote();
                boxNoteList.RemoveAt(i);
                theComboManager.ResetCombo();
                theEffect.JudgementEffect(timingBoxs.Length);
                MissRecord();
                Debug.Log("MissA");                
            }*/

        }
     
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
        Debug.Log("MissB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int[] GetJudgementRecord()
    {
        return judgementRecord; //판정한 기록들 총합해서 (result코드에)반환시켜줌
    }

    public void MissRecord()
    {
        judgementRecord[4]++; // miss(index 4) 기록
        theStatus.DecreaseHp(1);
        theAudioManager.PlaySFX("Falling");
        theStatus.ResetShieldCombo();
    }


    public void Initialized()
    {
        judgementRecord[0] = 0;
        judgementRecord[1] = 0;
        judgementRecord[2] = 0;
        judgementRecord[3] = 0;
        judgementRecord[4] = 0;

    }
}
