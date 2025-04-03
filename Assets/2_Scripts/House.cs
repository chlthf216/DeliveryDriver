using UnityEngine;

public class House 
{
    public string tv = "거실 tv";
    private string diary = "비밀 다이어리";
    protected string secretkey = "집 비밀번호";


    public string GetDiary()
    {
        return diary;
    }
}
