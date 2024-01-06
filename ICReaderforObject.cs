
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ICReaderforObject : UdonSharpBehaviour
{
    [Header("----------------------------------------------------")]
    [Header("決済風ギミック")]
    [Header("----------------------------------------------------")]
    [Header("■使い方■")]
    [Header("TargetObjectのElement0はSEのElement0と連携します。")]
    [Header("TargetObjectのElement1はSEのElement1と連携します。")]
    [Header("                                                ・")]
    [Header("                                                ・")]
    [Header("                                                ・")]

    [Space(20)]

    [Header("※TargetObjectとSEのsize値を揃えてください。")]
    [Header("※TargetObjectとSEは必ず割り当ててください。")]
    [Header("※Errorは必ず割り当ててください。")]
    [Header("※AudioSourceのPlay On Awakeはチェックを外してください。")]
    [Header("※カード側（かざす側）にはCollider、Rigidbody、VRC Pickupを入れてください。")]

    [Space(20)]

    [Header("sizeに数を入れて切り替えたいオブジェクトをドラッグ＆ドロップ")]

    [SerializeField] private GameObject[] TargetObject;

    [Header("sizeに数を入れて切り替えたいオーディオソースをドラッグ＆ドロップ")]

    [SerializeField] private GameObject[] Object;


    //他のオブジェクトと当たったら実行
    public void OnTriggerEnter(Collider ic)
    {
        //Object全消し
        if(Object.Length == TargetObject.Length)
        {
            for(int r =0;r<TargetObject.Length;r++)
            {
                Object[r].SetActive(false);
            }
            //TargetObjectが一致するまでループ
            int i = 0;
            for(int r =0;r<=TargetObject.Length;r++)
            {
                if(ic.name == TargetObject[i].name)
                {
                    break;
                }
                i=r;
            }
            //TargetObjectが一致しなかった時
            if(i == TargetObject.Length)
            {
            }
            //TargetObjectが一致した時
            else if(i != TargetObject.Length)
            {
                Object[i].SetActive(true);
            }
        }
        else
        {
            Debug.Log("AudioSourceとTargetObjectのsize値が一致しませんでした。");
        }
    }
}
