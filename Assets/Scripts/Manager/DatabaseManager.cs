using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class DatabaseManager : MonoBehaviour
{
    public int[] score;

    void Start()
    {
        //LoadScore();
    }

    public void SaveScore()
    {   //백그라운드로 작업 수행, 비동기 통신 : 메인코드와 별도로 실행되므로 통신할 때 끊김이 없음
        //BackendAsyncClass.BackendAsync(Backend.GameData.GetPrivateContents, "Score", UserDataBro => //이 이름(Score)으로된 프라이빗테이블에서 가져온 정보를 UserDataBro라는 이름의 변수?에 저장
     /*   var UserDataBro = Backend.GameData.GetTableList();
        //{
            if (UserDataBro.IsSuccess())
            {
                Param data = new Param();   //데이터 저장할때 쓰는 Param클래스
                data.Add("Scores", score); //Add(키값, value값)  , 테이블에 "Scores"라는 이름의 키값이 존재

                if (UserDataBro.GetReturnValuetoJSON()["rows"].Count > 0)    //이미 데이터가 존재한다면 기존 데이터 수정
                {
                    string t_Indate = UserDataBro.GetReturnValuetoJSON()["rows"][0]["inDate"]["S"].ToString();  //수정할 데이터의 식별값을 가져옴
                                                                                                                // 자신의 inDate의 row를 제거
                    Backend.GameData.UpdateV2("Score", t_Indate, Backend.UserInDate, data);
                    Backend.GameData.UpdateV2("Score", t_Indate, "owner_inDate", data);
                }
                else    //데이터가 없다면 새로 만들어줌 ->Insert
                {
                    Backend.GameData.Insert("Score", data, (callback) =>
                    {

                    });
                }
            }*/
        //});
        PlayerPrefs.SetInt("Score1", score[0]);
        PlayerPrefs.SetInt("Score2", score[1]);
        PlayerPrefs.SetInt("Score3", score[2]);

    }

    public void LoadScore()
    {   /*//백그라운드에서 실행, 비동기 통신
        BackendAsyncClass.BackendAsync(Backend.GameInfo.GetPrivateContents, "Score", UserDataBro => //프라이빗한 (Score)테이블을 UserDataBro라는 이름으로 가져옴
        {
            JsonData t_data = UserDataBro.GetReturnValuetoJSON();   //가져온 데이터를 t_data에 저장
            //이후처리

            if (t_data.Count > 0)    //가져온 데이터가 존재하면 
            {
                JsonData t_List = t_data["rows"][0]["Scores"]["L"]; //Json데이터 t_List에 있는 Scores(테이블 내의 점수 값)를 ("L"=)리스트의 형태로 가져옴
                for (int i = 0; i < t_List.Count; i++)
                {
                    var t_value = t_List[i]["N"];   //Score는 숫자이기 때문에 ("N"=)숫자 형태로 가져와서 t_value에 저장
                    score[i] = int.Parse(t_value.ToString());   //이 값을 int형으로 변환해서 score 배열에 저장
                }
                Debug.Log("로드 완료");
            }
            else    //가져온 데이터 없음 == 로드할것 없음
            {
                Debug.Log("로드할 것 없음");
            }
        });*/
        //
        if(PlayerPrefs.HasKey("Score1"))
        {
            score[0] = PlayerPrefs.GetInt("Score1");
            score[1] = PlayerPrefs.GetInt("Score2");
            score[2] = PlayerPrefs.GetInt("Score3");

        }
    }

}
