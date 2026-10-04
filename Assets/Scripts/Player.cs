using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    //esto solo se usa para guardar una referencia al prefab
    [SerializeField] private BaseAbility[] _abilitiesPrefabs;
    //esto usara el jugador para guardar la referencia a la habilidad que se instancio en el awake
    private BaseAbility[] _abilities;
    private BaseAbility _current;
    private int _currentAbilitieIndex = -1;

    [SerializeField] private float _speed = 5f;
    private Vector2 dirMove;
    private Vector2 aimDirection;

    private InputSystem_Actions inputs;

    //hacer que agregar habilidades nuevas sea automatico solo agregando un objeto a una lista quizas????

    private void Awake()
    {
        inputs = new();

        SetAbilitiesArray();
    }

    private void SetAbilitiesArray()
    {
        _abilities = new BaseAbility[_abilitiesPrefabs.Length];

        for (int i = 0; i < _abilitiesPrefabs.Length; i++)
        {
            BaseAbility ability = Instantiate(_abilitiesPrefabs[i], transform);
            _abilities[i] = ability;
        }

        _currentAbilitieIndex = 0;
        SelectAbilitie();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _speed * (Vector3)dirMove * Time.deltaTime;
    }


    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Scroll.performed += OnScroll;

        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;

        inputs.Player.Mouse.performed += OnMouseMove;

        inputs.Player.Cast.performed += OnCast;
    }

    private void OnDisable()
    {
        inputs.Disable();

        inputs.Player.Scroll.performed -= OnScroll;

        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;

        inputs.Player.Mouse.performed -= OnMouseMove;

        inputs.Player.Cast.performed -= OnCast;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        dirMove = context.ReadValue<Vector2>();
    }

    private void OnMouseMove(InputAction.CallbackContext context)
    {
        aimDirection = (Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position).normalized;
    }

    private void OnScroll(InputAction.CallbackContext ctx)
    {
        Vector2 scrollValue = ctx.ReadValue<Vector2>();

        _currentAbilitieIndex += (int)scrollValue.y;

        SelectAbilitie();
    }

    private void OnCast(InputAction.CallbackContext context)
    {
        if (_current == null)
        {
            Debug.LogWarning("no se ha seleccionado ninguna habilidad");
            return;
        }

        _current.transform.up = aimDirection;
        _current.Execute();
        //_current = null;
    }

    #region Ability Selector

    public void SelectAbilitie()
    {
        if (_abilities.Length == 0)
        {
            Debug.LogWarning("no hay habilidades disponibles");
            return;
        }

        if (_currentAbilitieIndex < 0)
        {
            _currentAbilitieIndex = _abilities.Length - 1;
        }
        else if (_currentAbilitieIndex >= _abilities.Length)
        {
            _currentAbilitieIndex = 0;
        }

        _current = _abilities[_currentAbilitieIndex];

        Debug.Log("se selecciono la habilidad: " + _currentAbilitieIndex);
    }

    #endregion

    public BaseAbility CurrentAbility => _current;
}
