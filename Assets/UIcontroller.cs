using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    //���s�����e�L�X�g
    private GameObject runLengthText;

    //����������
    private float len = 0;

    //���鑬�x
    private float speed = 5f;

    //�Q�[���I�[�o�[�̔���
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //UI�I�u�W�F�N�g���i�[
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == false)
        {
            //�������������X�V
            this.len += this.speed * Time.deltaTime;

            //������������\������
            this.runLengthText.GetComponent<Text> ().text = "Distance: " + len.ToString("F2") + "m";

        }

        //�Q�[���I�[�o�[�ɂɂȂ����Ƃ�
        if(this.isGameOver == true)
        {
            //�N���b�N���ꂽ��V�[�������[�h����
            if (Input.GetMouseButtonDown(0))
            {
                //SampleScene��ǂݍ���
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    public void GameOver()
    {
        //�Q�[���I�[�o�[�̎��A��ʏ�ɃQ�[���I�[�o�[��\������
        this.gameOverText.GetComponent<Text>().text = "GAME OVER";
        this.isGameOver = true;
    }
}