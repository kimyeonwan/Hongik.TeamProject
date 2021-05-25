using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Cursor : MonoBehaviour
{
    [Tooltip("Ŀ�� �̹���")]
    [SerializeField]
    private Texture2D cursorTexture;//Ŀ�� �̹���
    public bool hotSpotIsCenter = false;//�ؽ�ó �߽��� ���콺 ��ǥ�� ���� üũ�ڽ��� �Է�
    public Vector2 adjustHotSpot = Vector2.zero;//��ǥ�� �Է� ����.
    private Vector2 hotspot;

    //public GameObject Bullet;//���� �ٸ� ��ũ��Ʈ���� ������ �� �ҷ��� ����. ������Ʈ Ǯ�� ������� bullet �����ϱ�.
    public void Start()
    {
        StartCoroutine("MyCursor");//�ڷ�ƾ���� TargetCusor()�Լ� ȣ��
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 5);

            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
            Vector3 HitPos = Input.mousePosition;

            Debug.Log(HitPos);
            //Update ���� RayCast�� ���콺 ��ġ �ޱ�. ���� Bullet �����Ҷ� ĳ���� ��ġ->raycast�� ���� ��ġ���� Bullet�� ���� �� �̵���Ű��.
        }
    }
    IEnumerator MyCursor()
    {
        yield return new WaitForEndOfFrame();//�������� �Ϸ��Ҷ����� ���.

        if(hotSpotIsCenter)
        {
            //���콺�� �߽����� �̵���Ų��.
            hotspot.x = cursorTexture.width / 2;
            hotspot.y = cursorTexture.height / 2;
        }
        else
        {
            hotspot = adjustHotSpot;//�ʱ�ȭ
        }
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }

}