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
    {   //��׶���� �۾� ����, �񵿱� ��� : �����ڵ�� ������ ����ǹǷ� ����� �� ������ ����
        //BackendAsyncClass.BackendAsync(Backend.GameData.GetPrivateContents, "Score", UserDataBro => //�� �̸�(Score)���ε� �����̺����̺��� ������ ������ UserDataBro��� �̸��� ����?�� ����
     /*   var UserDataBro = Backend.GameData.GetTableList();
        //{
            if (UserDataBro.IsSuccess())
            {
                Param data = new Param();   //������ �����Ҷ� ���� ParamŬ����
                data.Add("Scores", score); //Add(Ű��, value��)  , ���̺� "Scores"��� �̸��� Ű���� ����

                if (UserDataBro.GetReturnValuetoJSON()["rows"].Count > 0)    //�̹� �����Ͱ� �����Ѵٸ� ���� ������ ����
                {
                    string t_Indate = UserDataBro.GetReturnValuetoJSON()["rows"][0]["inDate"]["S"].ToString();  //������ �������� �ĺ����� ������
                                                                                                                // �ڽ��� inDate�� row�� ����
                    Backend.GameData.UpdateV2("Score", t_Indate, Backend.UserInDate, data);
                    Backend.GameData.UpdateV2("Score", t_Indate, "owner_inDate", data);
                }
                else    //�����Ͱ� ���ٸ� ���� ������� ->Insert
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
    {   /*//��׶��忡�� ����, �񵿱� ���
        BackendAsyncClass.BackendAsync(Backend.GameInfo.GetPrivateContents, "Score", UserDataBro => //�����̺��� (Score)���̺��� UserDataBro��� �̸����� ������
        {
            JsonData t_data = UserDataBro.GetReturnValuetoJSON();   //������ �����͸� t_data�� ����
            //����ó��

            if (t_data.Count > 0)    //������ �����Ͱ� �����ϸ� 
            {
                JsonData t_List = t_data["rows"][0]["Scores"]["L"]; //Json������ t_List�� �ִ� Scores(���̺� ���� ���� ��)�� ("L"=)����Ʈ�� ���·� ������
                for (int i = 0; i < t_List.Count; i++)
                {
                    var t_value = t_List[i]["N"];   //Score�� �����̱� ������ ("N"=)���� ���·� �����ͼ� t_value�� ����
                    score[i] = int.Parse(t_value.ToString());   //�� ���� int������ ��ȯ�ؼ� score �迭�� ����
                }
                Debug.Log("�ε� �Ϸ�");
            }
            else    //������ ������ ���� == �ε��Ұ� ����
            {
                Debug.Log("�ε��� �� ����");
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
