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

    // ��ġ Ƚ�� �ؽ�Ʈ
    public Text feverComboText;
    // ��ġ Ƚ�� ī��Ʈ
    private int clickCount = 0;

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

    // ���� ȭ�� ��ƼŬ
    public GameObject basic;

    public AudioSource EndSFX01;
    public AudioSource EndSFX02;
    public AudioSource EndSFX03;

    public AudioSource comitionBGM;

    public AudioSource feverBGM;

    public AudioSource feverClickSFX;

    // ��ũ �� Ŭ�� ���
    public bool nowRank00;
    public bool nowRank01;
    public bool nowRank02;
    public bool nowRank03;
    public bool nowRank04;


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
        UpdatefeverComboText();
    }
    public void OnButtonClick()
    {
        //��ư Ŭ���� ī��Ʈ ����
        clickCount++;
        UpdatefeverComboText();
    }

    void UpdatefeverComboText()
    {
        //�ؽ�Ʈ ������Ʈ
        feverComboText.text = "Combo\n" + clickCount.ToString();
        
    }


    public void OnEnable()
    {
        feverButton.onClick.RemoveAllListeners();  // ���� �̺�Ʈ ����
        feverButton.onClick.AddListener(OnClickFeverButton);
        UpdateFeverTimeText();
        data_Dialog = CSVReader.Read("FeverCSV");

        nowRank00 = false;
        nowRank01 = false;
        nowRank02 = false;
        nowRank03 = false;
        nowRank04 = false;

        countdownTime = 5f;
        feverSlider.value = 0;
        feverGauge = 0;

        if (NowRank == 0)
        {
            nowRank00 = true;
        }

        if (NowRank == 1)
        {
            nowRank01 = true;
        }

        if (NowRank == 2)
        {
            nowRank02 = true;
        }

        if (NowRank == 3)
        {
            nowRank03 = true;
        }

        if (NowRank == 4)
        {
            nowRank04 = true;
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

            if (countdownTime <= 0 || feverGauge >= 50)
            {
                
                // ī��Ʈ �ٿ��� 0�� �Ǹ� feverBg�� ��Ȱ��ȭ�ϰ� endBg�� Ȱ��ȭ�Ѵ�.
                feverBg.SetActive(false);

                // feverGauge �˻�
                if (feverGauge >= 0)
                {
                    feverBGM.Stop();

                    ResultFever01();
                
                        
                }

                if (feverGauge >= 25 && feverGauge < 50)
                {
                    feverBGM.Stop();

                    ResultFever02();
                }

                if (feverGauge >= 50)
                {
                    feverBGM.Stop();

                    ResultFever03();
                }
            }
        }

    }

    public void ResultFever01()
    {
        if(NowRank == 0)
        {
            endText.text = data_Dialog[0]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[0]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[0]["ResultImg"].ToString());
            endGold.text = data_Dialog[0]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[0]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[3]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[3]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[3]["ResultImg"].ToString());
            endGold.text = data_Dialog[3]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[3]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[6]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[6]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[6]["ResultImg"].ToString());
            endGold.text = data_Dialog[6]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[6]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[9]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[9]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[9]["ResultImg"].ToString());
            endGold.text = data_Dialog[9]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[9]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[12]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[12]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[12]["ResultImg"].ToString());
            endGold.text = data_Dialog[12]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[12]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        endBg.SetActive(true);

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
        EndSFX01.Play();

    }

    public void ResultFever02()
    {

        if (NowRank == 0)
        {
            endText.text = data_Dialog[1]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[1]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[1]["ResultImg"].ToString());
            endGold.text = data_Dialog[1]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[1]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[4]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[4]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[4]["ResultImg"].ToString());
            endGold.text = data_Dialog[4]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[4]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[7]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[7]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[7]["ResultImg"].ToString());
            endGold.text = data_Dialog[7]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[7]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[10]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[10]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[10]["ResultImg"].ToString());
            endGold.text = data_Dialog[10]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[10]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[13]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[13]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[13]["ResultImg"].ToString());
            endGold.text = data_Dialog[13]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[13]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }
        basic.gameObject.SetActive(true);

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
        basic.gameObject.SetActive(true);
        EndSFX02.Play();

    }

    public void ResultFever03()
    {
        if (NowRank == 0)
        {
            endText.text = data_Dialog[2]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[2]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[2]["ResultImg"].ToString());
            endGold.text = data_Dialog[2]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[2]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 1)
        {
            endText.text = data_Dialog[5]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[5]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[5]["ResultImg"].ToString());
            endGold.text = data_Dialog[5]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[5]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 2)
        {
            endText.text = data_Dialog[8]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[8]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[8]["ResultImg"].ToString());
            endGold.text = data_Dialog[8]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[8]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 3)
        {
            endText.text = data_Dialog[11]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[11]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[11]["ResultImg"].ToString());
            endGold.text = data_Dialog[11]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[11]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        if (NowRank == 4)
        {
            endText.text = data_Dialog[14]["ResultExplain"].ToString();
            endTitle.text = data_Dialog[14]["ResultGrade"].ToString();
            SetImageFromResultImg(data_Dialog[14]["ResultImg"].ToString());
            endGold.text = data_Dialog[14]["FeverGold"].ToString() + "��� ȹ��!";
            int i = (int)data_Dialog[14]["FeverGold"];
            DataManager.Instance.nowGold += i;
            Save();
        }

        basic.gameObject.SetActive(true);

        // endBg�� �۰� ��������� ���̵���
        endBg.SetActive(true);
        endBg.transform.localScale = Vector3.zero; // �ʱ� ũ�⸦ 0���� ����

        // DOTween�� ����Ͽ� ���̵��� �ִϸ��̼� ����
        endBg.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce); // ���� ũ��� 1.5�� ���� ���̵���
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

            if (nowRank00 == true)
            {
                feverGauge++;
            }

            else if (nowRank01 == true)
            {
                feverGauge += 2;
            }

            else if (nowRank02 == true)
            {
                feverGauge += 3;
            }

            else if (nowRank03 == true)
            {
                feverGauge += 4;
            }

            else if (nowRank04 == true)
            {
                feverGauge += 5;
            }

            Debug.Log(feverGauge);

            // feverButton Ŭ�� �� feverGauge ���� �� feverSlider �̵�
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
        goldText.text = DataManager.Instance.nowGold.ToString();

        EndSFX01.Stop();
        EndSFX02.Stop();
        EndSFX03.Stop();

        nowRank00 = false;
        nowRank01 = false;
        nowRank02 = false;
        nowRank03 = false;
        nowRank04 = false;

        //�޺� Ƚ�� �ʱ�ȭ
        clickCount = 0;
        UpdatefeverComboText();

        // result�� Shine_pink ��ƼŬ ������Ʈ�� ��Ȱ��ȭ
        endBg.SetActive(false);
        basic.gameObject.SetActive(false);
        feverStart.gameObject.SetActive(false);

        comitionBGM.Play();

    }

}