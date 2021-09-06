using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPet : MonoBehaviour
{
    private HamsterData data;

    private GameObject hamster;

    public GameObject hamsterPrefab;

    public Image avatar;

    public void SetData(HamsterData data)
    {
        this.data = data;
        SetAvatar();
        CreateHamster();
    }

    public void CreateHamster()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-2.5f, -5f);
        hamster = Instantiate(hamsterPrefab, new Vector2(x, y), Quaternion.identity);
        hamster.GetComponent<Hamster>().SetData(data);
    }

    public void DestroyHamster()
    {
        Destroy(hamster);
    }

    public void SetAvatar()
    {
        if (data.level >= 10)
        {
            avatar.sprite = Resources.Load<Sprite>("Adult/" + data.sprite);
        }
        else
        {
            avatar.sprite = Resources.Load<Sprite>("Baby/" + data.sprite);
        }
    }

    public void SeclectHamster()
    {
        PetPanel.instance.SelectHamster(ref data, this.gameObject);
    }
}
