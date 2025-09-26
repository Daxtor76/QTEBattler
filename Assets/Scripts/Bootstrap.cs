using UnistrokeGestureRecognition;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public RecognizerController recognizerController;

    private void Awake()
    {
        DataLoader.LoadInitData();
        CreateControllers();
    }

    private void CreateControllers()
    {
        CreateRecognizerController();
    }

    private void CreateRecognizerController()
    {
        if (GameObject.Find(recognizerController.name) == null)
            Instantiate(recognizerController);
        else
            Debug.Log($"{nameof(recognizerController)} already exists :(");
    }
}
