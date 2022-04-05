using UnityEngine;
using UnityEngine.UI;

public class BallBounce : MonoBehaviour
{
    private int _scoreCount = 0;
    [SerializeField] private float _rMin = 1.2f, _rMax = 1.5f, _randomNumber, _divisorX, _upForce = 5;
    private sbyte _colorCount = -1;
    private Rigidbody2D _rb;
    [SerializeField] private Text _scoreText, _finalScoreText, _highestScoreText;
    [SerializeField] private GameObject _gameoverPanel, _racket;
    [SerializeField] private AudioSource _bounce;
    [SerializeField] Color[] c1 = { Color.red, Color.blue, Color.green, Color.black, Color.cyan, Color.grey, Color.magenta, Color.yellow };
    private Renderer _ren;

    private void Awake()
    {
        PlayerPrefs.GetInt("HighestScore", -1);
    }

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _bounce = gameObject.GetComponent<AudioSource>();
        _ren = GetComponent<Renderer>();
        _ren.material.color = Color.white;
    }

    private void Update()
    {
        _randomNumber = UnityEngine.Random.Range(_rMin, _rMax);
        _divisorX = UnityEngine.Random.Range(5, 10);
        if (_colorCount % _divisorX == 0 && _colorCount / 2 < c1.Length)
        {
            _ren.material.color = c1[_colorCount / 2];
        }
        if (_colorCount / 2 == c1.Length)
        {
            _colorCount = -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Racket"))
        {
            _bounce.Play();
            _rb.AddForce(Vector2.up * _upForce * _randomNumber, ForceMode2D.Impulse);
            _scoreCount++;
            _colorCount++;
            _scoreText.text = "Score: " + _scoreCount;
        }
        else if (other.gameObject.CompareTag("FallTrigger"))
        {
            Destroy(this.gameObject);
            Destroy(_racket);
            Cursor.visible = true;
            _gameoverPanel.SetActive(true);
            if (_scoreCount > PlayerPrefs.GetInt("HighestScore"))
            {
                PlayerPrefs.SetInt("HighestScore", _scoreCount);
            }
            _finalScoreText.text = "Final Score: " + _scoreCount;
            _highestScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighestScore");
        }
    }
}
