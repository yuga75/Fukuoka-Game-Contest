using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;   //(����)�ړ��������I�u�W�F�N�g��ݒ�
    public Vector3 movePosition;�@//�ړ����鋗�����i�[
    public int speed = 5;�@//1�}�X���Ɉړ�����X�s�[�h
    public float rotateSpeed = 5;   //��]�X�s�[�h
    public Vector3 moveY = new Vector3(0, 1, 0);�@//(1�}�X����)Y���̈ړ�����
    public Vector3 moveX = new Vector3(1, 0, 0);�@//(1�}�X����)X���̈ړ�����
    bool hogehoge;
    bool firstMoveJudge;    //�ŏ��̃t���[���̈ړ�����
    bool moveJudge; //�ړ����̔���
    bool rotateJudge;   //��]���̔���

    void Start()
    {
        //�����ݒ�
        firstMoveJudge = true;
        moveJudge = false;
        rotateJudge = false;
    }

    void Update()
    {
        //�ړ��ꏊ�ݒ�
        //�ړ����s���ƁAmoveJudge = true �ɕς��A�ꎞ�I�Ɉړ��̕��򏈗��𖳌���
        if (hogehoge == true)   //�Đ����肪�^�ł���
        {
            //�ŏ��̃t���[���͓Ɨ������ړ��������s��
            if (firstMoveJudge == true && this.gameObject.CompareTag("�ʏ폰"))
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
                firstMoveJudge = false;
            }
            else
            {
                //�Փˏ���
            }

            if (moveJudge == false)
            {
                if (Input.GetKeyDown("up"))
                {
                    movePosition = player.transform.position + moveY;  //movePosition�Ɉړ����鋗�����i�[
                    moveJudge = true;  //moveButtonJudge = true�ɂ��āA�ړ��𐧌�����
                }
            }
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);   //�ړ��J�n(player�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x)



        //�w�肵���ꏊ�ɃI�u�W�F�N�g���ړ�����ƁA�ēx�ړ��������\�ɂȂ�
        if (player.transform.position == movePosition) moveJudge = false;
    }
}