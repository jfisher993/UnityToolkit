using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour {

    #region Serialized Fields
    [SerializeField]
    private bool isEnabled = true;
    [SerializeField]
    private bool isReversed;
    [SerializeField]
    private bool isPingPong;
    [SerializeField]
    private bool isStartIndexInitialColor;
    [SerializeField]
    private int startIndex;
    [SerializeField]
    private ColorSwitch[] switchers;
    [SerializeField]
    private float newIntervalForAll;
    #endregion

    private Material mat;
    private int currentIndex, previousIndex;
    private bool isIndexIncreasing;
    private float timer;

    private void Start() {
        InitializeSwitcher();
    }

    private void InitializeSwitcher() {
        if (switchers.Length < 0){
            Debug.LogWarning("Please add some Switches for the ColorSwitcher to work");
            enabled = false;
            return;
        }

        mat = GetComponent<Renderer>().sharedMaterial;

        if (isStartIndexInitialColor){
            mat.color = switchers[startIndex].Color;
        }
            
        previousIndex = currentIndex = startIndex;
        isIndexIncreasing = !isReversed;
    }

    private void Update() {
        if (!isEnabled){
            return;
        }
            
        UpdateColor();

        if (mat.color == switchers[currentIndex].Color){
            NewColor();
        }

    }

    private void UpdateColor() {
        if (switchers[previousIndex].IsLerpToNext) {
            mat.color = Color.Lerp(mat.color, switchers[currentIndex].Color, Time.deltaTime / timer);
            timer -= Time.deltaTime;
        } else {
            timer += Time.deltaTime;
            if (timer >= switchers[previousIndex].Interval){
                mat.color = switchers[currentIndex].Color;
            }
        }
    }

    private void NewColor(){
        timer = switchers[currentIndex].IsLerpToNext ? switchers[currentIndex].Interval : 0;
        previousIndex = currentIndex;
        if (isPingPong){
            PingPongShiftIndex();
        } else {
            NormalShiftIndex();
        }
    }
        
    private void PingPongShiftIndex() {
        if (currentIndex >= switchers.Length - 1){
            currentIndex--;
            isIndexIncreasing = false;
        } else if (currentIndex <= 0){
            currentIndex++;
            isIndexIncreasing = true;
        } else {
            currentIndex += isIndexIncreasing ? 1 : -1;
        }
    }

    private void NormalShiftIndex() {
        currentIndex += isReversed ? -1 : 1;
        if (currentIndex >= switchers.Length){
            currentIndex = 0;
        } else if (currentIndex < 0){
            currentIndex = switchers.Length - 1;
        }
    }

    #region Editor Extensions
    [ContextMenu("Set All Intervals")]
    public void SetAllIntervals() {
        for (int i = 0; i < switchers.Length; i++){
            switchers[i].Interval = newIntervalForAll;
        }
    }

    private void OnValidate() {
        if (startIndex >= switchers.Length){
            startIndex = switchers.Length - 1;
        } else if (startIndex < 0){
            startIndex = 0;
        }
        InitializeSwitcher();
    }
    #endregion
}

[System.Serializable]
public class ColorSwitch {
    #region Serialized Fields
    [SerializeField]
    private float interval;
    [SerializeField]
    private bool isLerpToNext;
    [SerializeField]
    private Color color;
    #endregion


    #region Getters Setters
    public float Interval {
        get {
            return interval;
        }
        set {
            interval = value;
        }
    }

    public bool IsLerpToNext {
        get {
            return isLerpToNext;
        }
        set {
            isLerpToNext = value;
        }
    }

    public Color Color {
        get {
            return color;
        }
        set {
            color = value;
        }
    }
    #endregion
}
