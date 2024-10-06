using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 引入场景管理库

public class EnergyManager : MonoBehaviour
{
    public Slider energyBar; // UI的能量条
    public float energy = 100f; // 初始体力值
    public float energyDecreaseRate = 10f; // 每秒减少的能量
    public float energyIncreaseAmount = 5f; // 碰撞球体时增加的能量
    public GameObject player; // 玩家对象
    public GameObject ball; // 球体对象

    private CharacterController characterController; // 引用玩家的 CharacterController
    private bool isMoving = false; // 判断玩家是否在移动

    void Start()
    {
        // 初始化能量条
        energyBar.maxValue = 100;
        energyBar.value = energy;

        // 获取玩家的 CharacterController 组件
        characterController = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        // 通过速度检测玩家是否在移动
        CheckPlayerMovement();

        // 如果玩家在移动，减少能量
        if (isMoving)
        {
            energy -= energyDecreaseRate * Time.deltaTime;
            energy = Mathf.Clamp(energy, 0, 100); // 保证能量值在0-100之间
            energyBar.value = energy;
            Debug.Log("Player is moving. Current energy: " + energy); // 打印当前能量值
        }

        // 检查能量是否为 0
        if (energy <= 0)
        {
            EndGame(); // 调用结束游戏方法
        }
    }

    // 检查玩家是否在移动
    private void CheckPlayerMovement()
    {
        // 检查玩家当前的水平速度是否大于一个非常小的值（表示正在移动）
        if (characterController.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    // 当玩家与球体碰撞时调用
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            Debug.Log("Before collision, energy: " + energy); // 碰撞前打印能量值
            IncreaseEnergy();
            Debug.Log("After collision, energy: " + energy); // 碰撞后打印能量值
            Destroy(ball); // 销毁球体
        }
    }

    // 增加能量的方法
    public void IncreaseEnergy()
    {
        energy += energyIncreaseAmount;
        energy = Mathf.Clamp(energy, 0, 100); // 保证能量值在0-100之间
        energyBar.value = energy;
    }

    // 结束游戏并返回主菜单
    private void EndGame()
    {
        Debug.Log("Game Over! Returning to MainMenu...");
        SceneManager.LoadScene("MainMenu"); // 加载 MainMenu 场景
    }
}
