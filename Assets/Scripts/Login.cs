using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Login : MonoBehaviour
{
    [SerializeField] InputField id = null;
    [SerializeField] InputField pw = null;

    DatabaseManager theDatabase;

    // Start is called before the first frame update
    void Start()
    {
        theDatabase = FindObjectOfType<DatabaseManager>();

        var bro = Backend.Initialize(true);
        if(bro.IsSuccess())
            Debug.Log("�ʱ�ȭ����");
        else
            Debug.Log("�ʱ�ȭ ����");
    }
    /*
    void InitializeCallback()
    {
        if(Backend.IsInitalized)
        {
            Debug.Log(Backend.Utils.GetServerTime());
            Debug.Log(Backend.Utils.GetGoogleHash());
        }
        else
            Debug.Log("�ʱ�ȭ ���� (���ͳ� ���� ���)");
    }*/

    public void BtnRegist()//ȸ������
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomSignUp(t_id, t_pw, "���η� ���ԵǾ�����"); //ȸ������ �������� ���ϵǾ� bro ������ �����

        if(bro.IsSuccess())//��� ��Ȱ�ؼ� ������ �� �޾ƿ�
        {
            Debug.Log("ȸ������ �Ϸ�");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("ȸ������ ����");
        }
    }
    public void BtnLogin()//�α���
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomLogin(t_id, t_pw); //ȸ������ �������� ���ϵǾ� bro ������ �����

        if(bro.IsSuccess())//��� ��Ȱ�ؼ� ������ �� �޾ƿ�
        {
            Debug.Log("�α��� �Ϸ�");
            theDatabase.LoadScore();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
            //���� ���� Ȯ���ϸ� �������� �����ߴ��� ���� �ڵ尡 ����, �� ���� �ڵ忡 ���� �ذ��� �ڵ� ¥���
        }
    }
}
