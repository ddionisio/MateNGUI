using UnityEngine;
using System.Collections;

[AddComponentMenu("M8/NGUI/ModalConfirm")]
public class NGUIModalConfirm : M8.UIModal.Dialogs.ConfirmDialogBase {
    public UILabel title;
    public UILabel text;

    public UIEventListener yes;
    public UIEventListener no;

    protected override void OnSetInfo(string aTitle, string aText) {
        if(aTitle != null) title.text = aTitle;
        if(aText != null) text.text = aText;
    }

    protected override void OnActive(bool active) {
        if(active) {
            yes.onClick = YesClick;
            no.onClick = NoClick;

            UICamera.selectedObject = no.gameObject;
        }
        else {
            yes.onClick = null;
            no.onClick = null;
        }
    }

    public override void Open() {
        NGUILayoutBase.RefreshNow(transform);
    }

    void YesClick(GameObject go) {
        Click(true);
    }

    void NoClick(GameObject go) {
        Click(false);
    }
}
