using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll;
    public float speed;
    public float OffsetX;
}
public class BackGroundScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        for(int i = 0; i<ScrollDatas.Length;i++)
        {
            SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.speed) * Time.deltaTime;
        if(scrollData.OffsetX>1)
        {
            scrollData.OffsetX = scrollData.OffsetX % 1.0f;
        }

        Vector2 Offset = new Vector2(scrollData.OffsetX, 0);

        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", Offset);
    }
}
