using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Unity2D : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private bool IsFlip = false;
    public float maxSpeed = 500.0f;

    public GameObject LeftUp;
    public GameObject RightUp;
    public GameObject RightDown;
    public GameObject LeftDown;
    private AudioSource audioSource;
    public AudioClip DamagedClip;
    public AudioClip ShootClip;

    private Color OriginColor;

    float minX, maxX, minY, maxY;

    public int nHp
    {
        get;set;
    }

    // 총알 생성을 위한 변수
    public GameObject pBullet;
    public GameObject pSkill;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        OriginColor = spriteRenderer.color;
        nHp = 5;
    }

    void Update () {
        if (GameManager.Instance.IsGameRunning == false) return;
        CalcLimit();
        Move_2D();
        CheckFlip();

        if (Input.GetKeyDown(KeyCode.R))
            SoundManager.Instance.MuteAll();

        if (Input.GetKeyDown(KeyCode.T))
            SoundManager.Instance.ActiveAll();
    }

    void Move_2D()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float AddX = x * maxSpeed * Time.deltaTime;
        float AddY = y * maxSpeed * Time.deltaTime;

        Vector2 Origin = rigidBody.transform.position;

        // X 제한 범위 예외처리
        if (Origin.x + AddX < minX || Origin.x + AddX > maxX)
            AddX = 0.0f;

        // Y 제한 범위 예외처리
        if (Origin.y + AddY < minY || Origin.y + AddY > maxY)
            AddY = 0.0f;

        Vector2 NextPosition = new Vector2(AddX, AddY);
        NextPosition += Origin;
        rigidBody.MovePosition(NextPosition);
    }

    void CalcLimit()
    {
        minX = LeftDown.transform.position.x;
        maxX = RightDown.transform.position.x;
        minY = LeftDown.transform.position.y;
        maxY = LeftUp.transform.position.y;
    }

    void CheckFlip()
    {
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
            IsFlip = true;
        else
            IsFlip = false;

        spriteRenderer.flipX = IsFlip;
    }

    void PlaySound_Damaged()
    {
        audioSource.clip = DamagedClip;
        audioSource.Play();
    }

    void CreateBullet()
    {
        if (GameManager.Instance.IsGameRunning == false)
            return;

        GameObject target = Instantiate(pBullet, this.transform.position, this.transform.rotation);
        if (!IsFlip)
            target.SendMessage("SetRight");
        else
            target.SendMessage("SetLeft");
    }

    void Skill()
    {
        if (GameManager.Instance.IsGameRunning == false)
            return;

        Instantiate(pSkill, Vector3.zero, this.transform.rotation);
    }

    IEnumerator ChangeAlpha()
    {
        int nCnt = 0;

        while(nCnt < 7)
        {
            nCnt++;
            Color NextColor = spriteRenderer.color;

            if (NextColor.a >= 0.9f)
                NextColor.a = 0.5f;
            else
                NextColor.a = 1.0f;

            spriteRenderer.color = NextColor;
            yield return new WaitForSeconds(0.5f);
        }

        Color color = spriteRenderer.color;
        color.a = 1.0f;
        spriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StopCoroutine(ChangeAlpha());
            PlaySound_Damaged();
            StartCoroutine(ChangeAlpha());
            nHp -= 5;
        }
    }
    Rect Field01 = new Rect(600, 420, 100, 60);
    Rect Field02 = new Rect(700, 420, 100, 60);
    Rect Field03 = new Rect(0, 0, 100, 100);

    private void OnGUI()
    {
        if(GUI.Button(Field01, "공격"))
        {
            CreateBullet();
            audioSource.clip = ShootClip;
            audioSource.Play();
        }
        if(GUI.Button(Field02, "스킬"))
        {
            Skill();
        }
    }
}
