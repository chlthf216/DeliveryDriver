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
            Debug.Log("������ ��� ����");
        }
        else
        {
            Debug.Log("������ ��� �Ұ�");
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
                Debug.Log("��� �հ�");
            }
            else
            {
                Debug.Log("�Ϲ� �հ�");
            }
        }
        else
        {
            Debug.Log("���հ�");
        }
    }

    private static void Ex1()
    {
        int health = 69;
        if (health > 70)
        {
            Debug.Log("�ǰ��ؿ�");
        }
        else if (health > 30)
        {
            Debug.Log("�ణ ���ƾ��");
        }
        else if (health > 0)
        {
            Debug.Log("�����ؿ�");
        }
        else
        {
            Debug.Log("���");
        }
    }

}

