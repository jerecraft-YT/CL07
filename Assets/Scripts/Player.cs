using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private BaseAbility[] _abilities;
    [SerializeField] private BaseAbility _current;

    private InputSystem_Actions inputs;

    //hacer que agregar habilidades nuevas sea automatico solo agregando un objeto a una lista quizas????

    private void Awake()
    {
        inputs = new();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Ability1.performed += SelectAbility1;
        inputs.Player.Ability1.performed += SelectAbility2;
        inputs.Player.Ability1.performed += SelectAbility3;
        inputs.Player.Ability1.performed += SelectAbility4;
        inputs.Player.Ability1.performed += SelectAbility5;

        inputs.Player.Cast.performed += OnCast;
    }

    private void OnDisable()
    {
        inputs.Disable();

        inputs.Player.Ability1.performed -= SelectAbility1;
        inputs.Player.Ability1.performed -= SelectAbility2;
        inputs.Player.Ability1.performed -= SelectAbility3;
        inputs.Player.Ability1.performed -= SelectAbility4;
        inputs.Player.Ability1.performed -= SelectAbility5;

        inputs.Player.Cast.performed -= OnCast;
    }

    private void OnCast(InputAction.CallbackContext context)
    {
        if (_current == null) return;

        _current.Execute();
        _current = null;
    }

    #region Ability Selector

    private void SelectAbility5(InputAction.CallbackContext context)
    {
        Select(4);
    }

    private void SelectAbility4(InputAction.CallbackContext context)
    {
        Select(3);
    }

    private void SelectAbility3(InputAction.CallbackContext context)
    {
        Select(2);
    }

    private void SelectAbility2(InputAction.CallbackContext context)
    {
        Select(1);
    }

    private void SelectAbility1(InputAction.CallbackContext context)
    {
        Select(0);
    }

    public void Select(int index)
    {
        _current = _abilities[index];
    }

    #endregion
}
