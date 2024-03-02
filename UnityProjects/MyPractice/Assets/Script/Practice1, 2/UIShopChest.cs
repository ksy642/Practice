using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopChest : MonoBehaviour
{
   
    public GameObject contents;
    public GameObject uiListItemPrefab;
    public GameObject uiListItemAdPrefab;

    void Start()
    {
        for(int i=0; i<5; i++)
        {
            if (i == 0)
            {
                Instantiate<GameObject>(this.uiListItemAdPrefab, contents.transform);
            }
            else
            {
                Instantiate<GameObject>(this.uiListItemPrefab, contents.transform);
            }
        }
    }
}
