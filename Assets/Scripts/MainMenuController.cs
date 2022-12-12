using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
        string clickedObj = EventSystem.current.currentSelectedGameObject.name;
        int objIndex = int.Parse(clickedObj);
        GameManager.instance.CharIndex = objIndex;
        SceneManager.LoadScene("Gameplay");
    }
}
