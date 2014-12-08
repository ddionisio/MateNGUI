using UnityEngine;
using System.Collections;

/// <summary>
/// Set given 'select' to UICamera.selectObject upon modal active.
/// </summary>
[AddComponentMenu("M8/NGUI/ModalActiveSelect")]
public class NGUIModalActiveSelect : MonoBehaviour {

    public GameObject select;

    private M8.UIModal.Controller mController;

    void OnDestroy() {
        if(mController != null) {
            mController.onActiveCallback -= UIActive;
        }
    }

    void Awake() {
        mController = GetComponent<M8.UIModal.Controller>();
        if(mController != null) {
            mController.onActiveCallback += UIActive;
        }
    }

    void UIActive(bool active) {
        if(active && select.activeInHierarchy) {
            UICamera.selectedObject = select;
        }
    }
}