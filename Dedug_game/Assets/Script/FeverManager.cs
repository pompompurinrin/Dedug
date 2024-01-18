using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FeverManager : MonoBehaviour
{
    public GameObject feverStart;
    public Button feverButton;
    public Text feverTime;
    public int feverGauge;

    public Slider feverSlider;
    public GameObject feverBg;
    public GameObject endBg;

    public Text goldText;

    int NowGold;

    // �ǹ�Ÿ�� ������ ��ư
    public Button endFever;

    // ��� ����� ������Ʈ��
    public Text endText;
    public Text endTitle;
    public Text endGold;
    public Image endImg;

    float countdownTime;

    // ���� ��ũ
    int NowRank;

    // ����Ʈ ���� ����
    public GameObject feverEffectPrefab; // Ŭ�� ����Ʈ ������
    public Transform effectSpawnPoint;    // ����Ʈ ���� ��ġ
    public Transform feverParentObject; // ����Ʈ ���� �θ� ��ü


    // �ִϸ��̼� ���� ����
    public Animator feverAnimator;
    private bool isRunning = false;
    private int clicksInSecond = 0;
    private float clickTimer = 0f;

    // ��ƼŬ ����
    public Image result;
    public GameObject shinePinkParticle;

    // ���� ȭ�� ��ƼŬ
    public GameObject basic;
    public GameObject happy;

    public AudioSource EndSFX01;
    public AudioSource EndSFX02;
    public AudioSource EndSFX03;
    public AudioSource resultSFX;

    public AudioSource comitionBGM;

    public AudioSource feverBGM;

    public AudioSource feverClickSFX;


    List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();

    private void Awake()
    {
        // ����: ���� ���� ���� �� ������ �ε�
        NowGold = PlayerPrefs.GetInt("NowGold");
        NowRank = PlayerPrefs.GetInt("NowRank");
    }

    public void Start()
    {
        // ���� ���� ����
        DataManager.Instance.nowGold = NowGold;
        DataManager.Instance.nowRank = NowRank;
    }

    public void OnEnable()
    {
        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");

        // ��ũ�� ���� countdownTime �ʱ�ȭ
        if (NowRank == 0)
        {
            countdownTime = 10f;
        }
        else if (NowRank == 1)
        {
            countdownTime = 13f;
        }
        else if (NowRank == 2)
        {
            countdownTime = 16f;
        }
        else if (NowRank == 3)
        {
            countdownTime = 23f;
        }
        else if (NowRank == 4)
        {
            countdownTime = 30f;
        }

    }


    void Update()
    {

        // Ŭ�� Ƚ���� �ʴ� �ʱ�ȭ
        clickTimer += Time.deltaTime;
        if (clickTimer >= 1f)
        {
            clicksInSecond = 0;
            clickTimer = 0f;
        }

        if (feverBg.activeSelf && countdownTime > 0)
        {

            countdownTime -= Time.deltaTime;
            UpdateFeverTimeText();

            // �ִϸ��̼� ������Ʈ
            UpdateAnimation();

            if (countdownTime <= 0)
            {
                
                // ī��Ʈ �ٿ��� 0�� �Ǹ� feverBg�� ��Ȱ��ȭ�ϰ� endBg�� Ȱ��ȭ�Ѵ�.
                feverBg.SetActive(false);

                // feverGauge �˻�
                if (feverGauge >= 1 && feverGauge <= 10)
                {
                    feverBGM.Stop();
                    // result�� Shine_pink ��ƼŬ ������Ʈ�� Ȱ��ȭ
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay(2f)); // 2�� �Ŀ� ��ƼŬ ��Ȱ��ȭ


                }

                if (feverGauge >= 11 && feverGauge <= 25)
                {
                    feverBGM.Stop();
                    // result�� Shine_pink ��ƼŬ ������Ʈ�� Ȱ��ȭ
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay02(2f)); // 2�� �Ŀ� ��ƼŬ ��Ȱ��ȭ




                }

                if (feverGauge >= 26)
                {
                    feverBGM.Stop();
                    // result�� Shine_pink ��ƼŬ ������Ʈ�� Ȱ��ȭ
                    result.gameObject.SetActive(true);
                    shinePinkParticle.SetActive(true);
                    resultSFX.Play();

                    StartCoroutine(DeactivateParticlesAfterDelay03(2f)); // 2�� �Ŀ� ��ƼŬ ��Ȱ��ȭ


                }
            }
        }

    }

    IEnumerator DeactivateParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[0]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[0]["ResultGrade"].ToString();
        endGold.text = data_Dialog[0]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[0]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 20;
        Save();

        endBg.SetActive(true);

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
        EndSFX01.Play();

    }

    IEnumerator DeactivateParticlesAfterDelay02(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[1]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
        endGold.text = data_Dialog[1]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 50;
        Save();

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
        basic.gameObject.SetActive(true);
        EndSFX02.Play();

    }

    IEnumerator DeactivateParticlesAfterDelay03(float delay)
    {
        yield return new WaitForSeconds(delay);

        shinePinkParticle.SetActive(false);

        endText.text = data_Dialog[2]["ResultExplain"].ToString();
        endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
        endGold.text = data_Dialog[2]["FeverGold"].ToString();

        SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());

        DataManager.Instance.nowGold += 80;
        Save();

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
        happy.gameObject.SetActive(true);
        EndSFX03.Play();

    }


    public void Save()
    {
        // ����: PlayerPrefs�� ���� �� ����
        PlayerPrefs.SetInt("NowRank", DataManager.Instance.nowRank);
        PlayerPrefs.SetInt("NowGold", DataManager.Instance.nowGold);
        PlayerPrefs.SetInt("FeverNum", DataManager.Instance.feverNum);
        PlayerPrefs.Save();
    }

    void SetImageFromResultImg(string resultImgValue)
    {
        // ����: "FeverImg1" ���� ���� �̹����� ����
        if (resultImgValue == "1")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg1");
        }

        else if (resultImgValue == "2")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg2");
        }

        else if (resultImgValue == "3")
        {
            endImg.sprite = Resources.Load<Sprite>("FeverImg3");
        }


        // ���� ó��: "ResultImg" ���� ���� �������� ���� ���� ���
        else
        {
            Debug.LogError("Unexpected ResultImg value: " + resultImgValue);
        }
    }


    void OnClickFeverButton()
    {
        if (countdownTime > 0)
        {
            // Ŭ�� ����Ʈ �Լ� ȣ��
            CreateClickEffect();
            feverClickSFX.Play();
            // feverButton Ŭ�� �� feverGauge ���� �� feverSlider �̵�
            feverGauge++;
            feverSlider.value = feverGauge;

            // Ŭ�� Ƚ�� ����
            clicksInSecond++;
        }
    }

    void CreateClickEffect()
    {
        if (feverEffectPrefab != null && feverParentObject != null)
        {
            // ���� ���콺 ��ǥ�� �����ͼ� World ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z ���� 0���� ���� (2D ������ ���)

            // Ŭ�� ����Ʈ�� �����ϰ� feverParentObject�� �θ�� ����
            GameObject clickEffect = Instantiate(feverEffectPrefab, mousePosition, Quaternion.identity, feverParentObject.transform);
            Destroy(clickEffect, 1f); // 1�� �Ŀ� ����Ʈ ���� (���ϴ� �ð����� ���� ����)
        }
    }

    void UpdateFeverTimeText()
    {
        // feverTime �ؽ�Ʈ ������Ʈ
        feverTime.text = Mathf.CeilToInt(countdownTime).ToString();
    }

    void UpdateAnimation()
    {
        // Ŭ�� Ƚ���� 2�� �̻��� ��� feverRun �ִϸ��̼� ���
        // �׷��� ������ feverIdle �ִϸ��̼� ���
        isRunning = clicksInSecond >= 2;
        feverAnimator.SetBool("Run", isRunning);
    }

    public void EndFiver()
    {
        countdownTime = 10;
        feverSlider.value = 0;
        feverGauge = 0;
        goldText.text = DataManager.Instance.nowGold.ToString();

        // result�� Shine_pink ��ƼŬ ������Ʈ�� ��Ȱ��ȭ
        result.gameObject.SetActive(false);
        endBg.SetActive(false);
        basic.gameObject.SetActive(false);
        feverStart.gameObject.SetActive(false);

        comitionBGM.Play();

    }

}