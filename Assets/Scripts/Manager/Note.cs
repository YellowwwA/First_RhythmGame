using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    void OnEnable() //���� Start�Լ����µ� ��Ʈ Ǯ�� �ڵ� �����ϸ鼭 OnEnable�Լ��� �Լ��� ����
    {
        if(noteImage == null)   //��Ʈ Ǯ�� �� ť�� ��Ʈ ��ȯ(����)�ϸ鼭 �̹��� ��Ȱ��ȭ �ڵ� �߰�
            noteImage = GetComponent<UnityEngine.UI.Image>();   //���� ���� �ڵ�
        
        noteImage.enabled = true;   //��Ʈ Ǯ�� �� ť�� ��Ʈ ��ȯ �ϸ鼭 �̹��� ��Ȱ��ȭ �ڵ� �߰�
    }



    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }
    
    
    
    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
