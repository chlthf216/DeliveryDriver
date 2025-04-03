using UnityEngine;

public class Operater : MonoBehaviour
{


    void Start()
    {
        Ex1();
        Ex2();
        Ex3();
    }
    private void Ex3()
    {
        int level = 4;
        bool hasSpecialItem = true;
        bool isInBattle = true;

        if (level >= 5 && hasSpecialItem && isInBattle)
        {
            Debug.Log("아이템 사용 가능");
        }
        else
        {
            Debug.Log("아이템 사용 불가");
        }
    }

    private void Ex2()
    {
        int mathScore = 95;
        int englishScore = 85;
        if (mathScore > 60 && englishScore > 60)
        {
            if (mathScore + englishScore >= 180)
            {
                Debug.Log("우수 합격");
            }
            else
            {
                Debug.Log("일반 합격");
            }
        }
        else
        {
            Debug.Log("불합격");
        }
    }

    private static void Ex1()
    {
        int health = 69;
        if (health > 70)
        {
            Debug.Log("건강해요");
        }
        else if (health > 30)
        {
            Debug.Log("약간 지쳤어요");
        }
        else if (health > 0)
        {
            Debug.Log("위험해요");
        }
        else
        {
            Debug.Log("사망");
        }
    }

}

