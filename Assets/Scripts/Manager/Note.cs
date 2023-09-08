using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    void OnEnable() //원래 Start함수였는데 노트 풀링 코드 수정하면서 OnEnable함수로 함수명 변경
    {
        if(noteImage == null)   //노트 풀링 후 큐에 노트 반환(삭제)하면서 이미지 비활성화 코드 추가
            noteImage = GetComponent<UnityEngine.UI.Image>();   //여긴 기존 코드
        
        noteImage.enabled = true;   //노트 풀링 후 큐에 노트 반환 하면서 이미지 비활성화 코드 추가
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
