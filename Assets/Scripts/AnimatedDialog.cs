using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ダイアログのアニメーション
/// </summary>
public class AnimatedDialog : MonoBehaviour
{
    // アニメーター
    [SerializeField] private Animator _animator;

    // アニメーターコントローラーのレイヤー(通常は0)
    [SerializeField] private int _layer;

    // IsOpenフラグ(アニメーターコントローラー内で定義したフラグ)
    private static readonly int ParamIsOpen = Animator.StringToHash("IsOpen");

    // ダイアログは開いているかどうか
    public bool IsOpen => gameObject.activeSelf;

    // アニメーション中かどうか
    public bool IsTransition { get; private set; }

    // ダイアログを開く
    public void Open()
    {
        // 不正操作防止
        if (IsOpen || IsTransition) return;

        // パネル自体をアクティブにする
        gameObject.SetActive(true);

        // IsOpenフラグをセット
        _animator.SetBool(ParamIsOpen, true);

        // アニメーション待機
        StartCoroutine(WaitAnimation("Shown"));
    }

    // ダイアログを閉じる
    public void Close()
    {
        // 不正操作防止
        if (!IsOpen || IsTransition) return;

        // IsOpenフラグをクリア
        _animator.SetBool(ParamIsOpen, false);

        // アニメーション待機し、終わったらパネル自体を非アクティブにする
        StartCoroutine(WaitAnimation("Hidden", () => gameObject.SetActive(false)));
    }

    public void Close2()
    {
        gameObject.SetActive(false);
    }

    // 開閉アニメーションの待機コルーチン
    private IEnumerator WaitAnimation(string stateName, UnityAction onCompleted = null)
    {
        IsTransition = true;

        yield return new WaitUntil(() =>
        {
            // ステートが変化し、アニメーションが終了するまでループ
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            return state.IsName(stateName) && state.normalizedTime >= 1;
        });

        IsTransition = false;

        onCompleted?.Invoke();
    }
}