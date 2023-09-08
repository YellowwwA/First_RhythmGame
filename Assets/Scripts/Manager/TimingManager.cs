using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>(); //������ ��Ʈ�� ��� List -> ���� ������ �ִ��� ��� ��Ʈ�� ���ϱ� ����

    int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null; //���߿� Boxes�� ���� + ���̶�Ű �信�� ������Ʈ �̸��� CenterFrame �ƴѰ�...?

    EffectManager theEffect;
    ScoreManager theScoreManager; //��������ڵ��߰�
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
        {   //Ÿ�̹� �ڽ� ���� (0��° Ÿ�̹� �ڽ� = Perfect(���� ���� ����), 3��° Ÿ�ֹ̹ڽ� = Bad ���� ���� ����)
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.height/2,  //localPosition.x���� y�� ����
                              Center.localPosition.x + timingRect[i].rect.height/2);    //localPosition.y + - timingRect[i].rect.width/2
        }
    }


    public void CheckTiming()
    {
        for(int i = 0; i<boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.position.y; //���⵵ x���� y�� ����    localPosition.y;

            for(int x = 0; x<timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    //��Ʈ����
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //����Ʈ����
                    if(x<timingBoxs.Length -1)
                        theEffect.NoteHitEffect();
                    Debug.Log("Hit" + x);
                    theEffect.JudgementEffect(x);

                    judgementRecord[x]++; //���� ���

                    //���� ����
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
        return judgementRecord; //������ ��ϵ� �����ؼ� (result�ڵ忡)��ȯ������
    }

    public void MissRecord()
    {
        judgementRecord[4]++; // miss(index 4) ���
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
