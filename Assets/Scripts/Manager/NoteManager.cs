using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    
    public int bpm = 0;
    double currentTime = 0d;

    //bool noteActive = true;

    [SerializeField] Transform[] tfNoteAppear = null;
    //[SerializeField] GameObject goNote = null;    //��Ʈ Ǯ�� �ڵ� �߰��ϸ鼭 ���� ��Ʈ ���� �ڵ� �ּ�ó��

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
                //�Ʒ� ���� ��Ʈ Ǯ�� �ڵ�
                GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                int i = Random.Range(0,4);
                t_note.transform.position = new Vector3(tfNoteAppear[i].position.x,tfNoteAppear[i].position.y,tfNoteAppear[i].position.z);   //��Ʈ ��ġ ���� ���� x+n�κи� �ڵ��߰�
                t_note.transform.rotation = Quaternion.Euler(0,0,-90.0f);   //��Ʈ�� ȸ�� ���� ���� �߰�                         //��Ʈ ��ġ ������ ���� �� ������ ���� �޶����µ�
                t_note.transform.localScale = new Vector3(1.5f,1.5f,1.5f);  //��Ʈ�� ũ�� ���� ���� ���� �߰�                          //���߿� ���Ӻ� ���� ������Ű�� ��ġ ���� �ѹ��� �ϱ�
                t_note.SetActive(true);

                //��Ʈ ���� �ı��� ���� �ý��� ������?������ �̸� ť�� ��ü ���� �� ������ ���⸸ �ϴ� Ǯ�� ��� ���� ��� ������ ��Ʈ ���� �ڵ� �ּ�ó��
                //GameObject t_noteA = Instantiate(goNote, tfNoteAppear.position, Quaternion.Euler(0,0,-90.0f));
            
                /*
                GameObject t_noteB = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+200f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteC = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+400f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteD = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+600f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                GameObject t_noteE = Instantiate(goNote, new Vector3(tfNoteAppear.position.x+800f,tfNoteAppear.position.y,tfNoteAppear.position.z) , Quaternion.Euler(0,0,-90.0f));
                */

                //t_noteA.transform.SetParent(this.transform, false); //��Ʈ ũ�⶧���� false �߰�
            
                /*
                t_noteB.transform.SetParent(this.transform, false); //��Ʈ ũ�⶧���� false �߰�
                t_noteC.transform.SetParent(this.transform, false); //��Ʈ ũ�⶧���� false �߰�
                t_noteD.transform.SetParent(this.transform, false); //��Ʈ ũ�⶧���� false �߰�
                t_noteE.transform.SetParent(this.transform, false); //��Ʈ ũ�⶧���� false �߰�
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



            //��Ʈ Ǯ�� �ڵ� �߰� (ť���� ������ ��Ʈ �ٽ� ��ȯ(=��Ʈ����))
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);

            //Destroy(collision.gameObject); ��Ʈ Ǯ�� ���� ���� ��Ʈ �ı� �ڵ� �ּ�ó��
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
