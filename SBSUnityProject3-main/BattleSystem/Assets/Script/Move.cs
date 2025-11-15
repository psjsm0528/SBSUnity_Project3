using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 컴퓨터야 움직여줘
    // 방향
    // 속도
    //Vector2 dir2 = new Vector2(0, 1f, 0, 1f); 2차원
    //Vector3 dir3 = new Vector3(0.1f, 0.1f, 0.1f); 3차원
    [SerializeField] int direction = -1;
    [SerializeField] float speed = 10f;
    [SerializeField] float knockbackPower;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // rigid는 Move클래스가 부착되어 있는 오브젝트에서 가져와라
    }

    private void Start()
    {
        rigid.linearVelocityX = direction * speed;
    }

    public void Stop() 
    {
        rigid.linearVelocityX = 0;
    }

    public void KnockBack()
    {
        // 방향 : direction * (-1)
        int knockDirection = direction * (-1); //방향 :
        float knockbackPower = 10f;
        float knockbackPowerY = 5f;
        rigid.AddForceY(knockbackPowerY, ForceMode2D.Impulse);
        rigid.AddForceX(knockbackPower * knockDirection, ForceMode2D.Impulse);
        StartCoroutine(KnockBackLogic());
        // 넉백을 받으면 반대 방향으로 날아간다.
        // 넉백 후 일정 시간뒤에 다시 멈췄다가, move
    }

    IEnumerator KnockBackLogic()
    {
        yield return new WaitForSeconds(1f);
        Stop();
        yield return new WaitForSeconds(0.5f);
        rigid.linearVelocityX = direction * speed;
    }
}
