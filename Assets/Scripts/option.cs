using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class option : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] panels;
    public Image imageToMove;

    private int selectedIndex = -1;

    void Start()
    {
        OnButtonClicked(0);
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    void Update()
    {
        if (selectedIndex >= 0)
        {
            MoveImage(selectedIndex);
        }
    }

    void OnButtonClicked(int index)
    {
        selectedIndex = index;
        SetButtonHeights(25f);
        buttons[index].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30f);
        buttons[index].interactable = false;

        SetPanelVisibility(index);
    }

    void SetButtonHeights(float height)
    {
        foreach (Button button in buttons)
        {
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            button.interactable = true;
        }
    }

    void SetPanelVisibility(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);
        }
    }

    void MoveImage(int index)
    {
        RectTransform buttonRectTransform = buttons[index].GetComponent<RectTransform>();
        Vector3 newPosition = buttonRectTransform.position;
        newPosition.y = buttonRectTransform.position.y - 16.2f;
        RectTransform imageRectTransform = imageToMove.GetComponent<RectTransform>();
        imageRectTransform.position = newPosition;
    }
}
