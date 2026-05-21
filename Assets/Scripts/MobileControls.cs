using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public GameObject mobileControls;

    void Start()
    {
    #if UNITY_STANDALONE || UNITY_EDITOR
        mobileControls.SetActive(false);
    #endif
    }
}
