using UnityEngine;

public abstract class ViewBase : MonoBehaviour
{
    [SerializeField] protected GameState _targetState;

    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);

    public void Initialize(GameStateController stateController)
    {
        stateController.OnStateChanged += OnStateChanged;
        OnStateChanged(stateController.CurrentState);
    }

    void OnStateChanged(GameState newState)
    {
        if (newState == _targetState)
            Show();
        else
            Hide();
    }
}
