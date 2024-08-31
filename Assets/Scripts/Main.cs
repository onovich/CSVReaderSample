using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    bool isLoadedAssets;
    bool isTearDown;
    TemplateContext context;

    void Start() {
        context = new TemplateContext();
        Action action = async () => {
            try {
                await TemplateCore.LoadSO(context);
                isLoadedAssets = true;
            } catch (Exception e) {
                Debug.LogError(e.ToString());
            }
        };
        action.Invoke();

    }

    void Update() {
        if (!isLoadedAssets) {
            return;
        }
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void OnDestroy() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        TemplateCore.Release(context);
    }

}
