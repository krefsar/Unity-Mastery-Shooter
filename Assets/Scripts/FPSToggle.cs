using UnityEngine;

public class FPSToggle : MonoBehaviour
{
    private Weapons weapons;

    [SerializeField]
    private GameObject[] firstPersonObjects;
    [SerializeField]
    private GameObject[] thirdPersonObjects;
    [SerializeField]
    private KeyCode toggleKey = KeyCode.F1;

    private bool isFpsMode;

    private void Awake()
    {
        weapons = FindObjectOfType<Weapons>();
    }

    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;
        weapons.IsFpsMode = isFpsMode;

        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObj in firstPersonObjects)
        {
            gameObj.SetActive(isFpsMode);
        }

        foreach (var gameObj in thirdPersonObjects)
        {
            gameObj.SetActive(!isFpsMode);
        }
    }
}
