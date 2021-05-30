using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Cursor : MonoBehaviour
{
    [Tooltip("커서 이미지")]
    [SerializeField]
    private Texture2D cursorTexture;//커서 이미지
    public bool hotSpotIsCenter = false;//텍스처 중심을 마우스 좌표로 할지 체크박스로 입력
    public Vector2 adjustHotSpot = Vector2.zero;//좌표를 입력 받음.
    private Vector2 hotspot;

    //public GameObject Bullet;//추후 다른 스크립트에서 생성한 후 불러올 예정. 오브젝트 풀링 방법으로 bullet 구현하기.
    public void Start()
    {
        StartCoroutine("MyCursor");//코루틴으로 TargetCusor()함수 호출
    }
    public void Update()
    {

    }
    IEnumerator MyCursor()
    {
        yield return new WaitForEndOfFrame();//렌더링이 완료할때까지 대기.

        if(hotSpotIsCenter)
        {
            //마우스의 중심으로 이동시킨다.
            hotspot.x = cursorTexture.width / 2;
            hotspot.y = cursorTexture.height / 2;
        }
        else
        {
            hotspot = adjustHotSpot;//초기화
        }
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }

}
