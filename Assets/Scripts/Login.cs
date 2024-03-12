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
            Debug.Log("초기화성공");
        else
            Debug.Log("초기화 실패");
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
            Debug.Log("초기화 실패 (인터넷 문제 등등)");
    }*/

    public void BtnRegist()//회원가입
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomSignUp(t_id, t_pw, "어떤경로로 가입되었는지"); //회원가입 정보들이 리턴되어 bro 변수에 저장됨

        if(bro.IsSuccess())//통신 원활해서 정보를 잘 받아옴
        {
            Debug.Log("회원가입 완료");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("회원가입 실패");
        }
    }
    public void BtnLogin()//로그인
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomLogin(t_id, t_pw); //회원가입 정보들이 리턴되어 bro 변수에 저장됨

        if(bro.IsSuccess())//통신 원활해서 정보를 잘 받아옴
        {
            Debug.Log("로그인 완료");
            theDatabase.LoadScore();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
            //서버 들어가서 확인하면 뭐때문에 실패했는지 오류 코드가 나옴, 이 오류 코드에 따라 해결방법 코드 짜면됨
        }
    }
}
