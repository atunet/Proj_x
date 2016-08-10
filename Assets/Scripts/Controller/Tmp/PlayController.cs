using UnityEngine;
using System.Collections;

public class PlayController : MonoBehaviour 
{
    private static GameObject s_zoneBasePrefab = null;
    private static GameObject s_zoneEarthPrefab = null;
    private static GameObject s_zoneNormalPrefab = null;
    
    private static GameObject s_itemCloudPrefab = null;
    private static GameObject s_itemEnvelopePrefab = null;
    private static GameObject s_itemFuelPrefab = null;
    private static GameObject s_itemGiftPrefab = null;
    private static GameObject s_itemGold1Prefab = null;
    private static GameObject s_itemGold2Prefab = null;
    private static GameObject s_itemKitePrefab = null;
    private static GameObject s_itemPlanePrefab = null;
    private static GameObject s_itemRepairPrefab = null;
    private static GameObject s_itemSaucerPrefab = null;
    private static GameObject s_itemTicketPrefab = null;

    private static GameObject s_rocketPrefab = null;

    public static PlayController s_playController = null;
    public static RocketController s_rocketController = null;
    public static Transform s_rocketTrans = null;

    private EFlyState m_state;
    private float m_lastCheckTime;

    private int m_lastZoneX = 0;
    private int m_lastZoneY = 0;
    private ArrayList m_zoneList = null;

    void Start()
    {
        //GlobalRef.s_gr.PlayMusic(EBGMusic.BG_MUSIC_FIGHT);

        m_state = EFlyState.FLY_READY;
        m_lastCheckTime = Time.time;

        if(s_zoneBasePrefab == null) s_zoneBasePrefab = Resources.Load("Prefabs/ZoneBase") as GameObject;
        if(s_zoneEarthPrefab == null) s_zoneEarthPrefab = Resources.Load("Prefabs/ZoneEarth") as GameObject;
        if(s_zoneNormalPrefab == null) s_zoneNormalPrefab = Resources.Load("Prefabs/ZoneNormal") as GameObject;      
        
        int[] initPosList = new int[12]{-1,0,0,0,1,0,-1,1,0,1,1,1};
        
        m_zoneList = new ArrayList();
        for (int i = 0; i < initPosList.Length; i+=2)
        {
            GameObject skyZone = null;
            if(0 == initPosList[i+1]) 
            {
                if(0 == initPosList[i]) skyZone = Instantiate(s_zoneBasePrefab);
                else skyZone = Instantiate(s_zoneEarthPrefab);
            }
            else skyZone = Instantiate(s_zoneNormalPrefab);
            
            skyZone.transform.SetParent(this.transform);
            skyZone.transform.localPosition = new Vector3(initPosList[i]*640.0f, initPosList[i+1]*1136.0f, 0f);
            skyZone.transform.localScale = Vector3.one;
            skyZone.layer = LayerMask.NameToLayer("Flying");
            skyZone.transform.SetAsFirstSibling();
            skyZone.name = "SkyZone_"+initPosList[i]+"_"+initPosList[i+1];
            
            generateItem(skyZone.transform);
            
            m_zoneList.Add(skyZone.name);
        }

        if (s_rocketPrefab == null)
            s_rocketPrefab = Resources.Load("Prefabs/Rocket") as GameObject;

        GameObject newRocket = Instantiate(s_rocketPrefab);
        newRocket.transform.SetParent(this.transform);
        newRocket.transform.localPosition = new Vector3(0.0f, -380.0f, 0.0f);
        newRocket.transform.SetAsLastSibling();
        s_rocketTrans = newRocket.transform;

        s_playController = this;
        s_rocketController = newRocket.GetComponent<RocketController>();

        StartCoroutine(Timetick());
    }
    
    void generateItem(Transform root_)
    {
        GameObject newItem = null;
        
        EItemType randomValue = (EItemType) Random.Range((int)EItemType.ITEM_CLOUD, (int)EItemType.ITEM_MAX);
        if (randomValue == EItemType.ITEM_CLOUD)
        {
            if(null == s_itemCloudPrefab) s_itemCloudPrefab = Resources.Load("Prefabs/ItemCloud") as GameObject;
            newItem = Instantiate(s_itemCloudPrefab);
            newItem.name = "ItemCloud";
        } else if (randomValue == EItemType.ITEM_ENVELOPE)
        {
            if(null == s_itemEnvelopePrefab) s_itemEnvelopePrefab = Resources.Load("Prefabs/ItemEnvelope") as GameObject;
            newItem = Instantiate(s_itemEnvelopePrefab);
            newItem.name = "ItemEnvelope";
        } else if (randomValue == EItemType.ITEM_FUEL)
        {
            if(null == s_itemFuelPrefab) s_itemFuelPrefab = Resources.Load("Prefabs/ItemFuel") as GameObject;
            newItem = Instantiate(s_itemFuelPrefab);
            newItem.name = "ItemFuel";
        } else if (randomValue == EItemType.ITEM_GIFT)
        {
            if(null == s_itemGiftPrefab) s_itemGiftPrefab = Resources.Load("Prefabs/ItemGift") as GameObject;
            newItem = Instantiate(s_itemGiftPrefab);
            newItem.name = "ItemGift";
        } else if (randomValue == EItemType.ITEM_GOLD1)
        {
            if(null == s_itemGold1Prefab) s_itemGold1Prefab = Resources.Load("Prefabs/ItemGold1") as GameObject;
            newItem = Instantiate(s_itemGold1Prefab);
            newItem.name = "ItemGold1";
        } else if (randomValue == EItemType.ITEM_GOLD2)
        {
            if(null == s_itemGold2Prefab) s_itemGold2Prefab = Resources.Load("Prefabs/ItemGold2") as GameObject;
            newItem = Instantiate(s_itemGold2Prefab);
            newItem.name = "ItemGold2";
        } else if (randomValue == EItemType.ITEM_KITE)
        {
            if(null == s_itemKitePrefab) s_itemKitePrefab = Resources.Load("Prefabs/ItemKite") as GameObject;
            newItem = Instantiate(s_itemKitePrefab);
            newItem.name = "ItemKite";
        } else if (randomValue == EItemType.ITEM_PLANE)
        {
            if(null == s_itemPlanePrefab) s_itemPlanePrefab = Resources.Load("Prefabs/ItemPlane") as GameObject;
            newItem = Instantiate(s_itemPlanePrefab);
            newItem.name = "ItemPlane";
        } else if (randomValue == EItemType.ITEM_REPAIR)
        {
            if(null == s_itemRepairPrefab) s_itemRepairPrefab = Resources.Load("Prefabs/ItemRepair") as GameObject;
            newItem = Instantiate(s_itemRepairPrefab);
            newItem.name = "ItemRepair";
        } else if (randomValue == EItemType.ITEM_SAUCER)
        {
            if(null == s_itemSaucerPrefab) s_itemSaucerPrefab = Resources.Load("Prefabs/ItemSaucer") as GameObject;
            newItem = Instantiate(s_itemSaucerPrefab);
            newItem.name = "ItemSaucer";
        } else if (randomValue == EItemType.ITEM_TICKET)
        {
            if(null == s_itemTicketPrefab) s_itemTicketPrefab = Resources.Load("Prefabs/ItemTicket") as GameObject;
            newItem = Instantiate(s_itemTicketPrefab);
            newItem.name = "ItemTicket";
        }
        
        newItem.transform.SetParent(root_);
        newItem.transform.localPosition = new Vector3(Random.Range(-300.0f, 300.0f), Random.Range(-568.0f, 568.0f), 0.0f);
        newItem.transform.localScale = Vector3.one;
        newItem.layer = LayerMask.NameToLayer("Flying");
        newItem.transform.SetAsLastSibling();
    }

    public IEnumerator Timetick ()
    {
        yield return new WaitForSeconds(0.2f);

        Transform trans = this.transform.FindChild("TimetickAnim");
        if (trans)
            trans.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        m_state = EFlyState.FLY_FLYING;
       
        yield return new WaitForSeconds(2.0f);

        MyFollow follow = GlobalRef.s_gr.m_playCamera.AddComponent<MyFollow>();
        follow.m_target = s_rocketTrans;

        yield return new WaitForSeconds(10f);
    }

    void OnDestroy()
    {
        s_rocketTrans = null;
        s_playController = null;
        s_rocketController = null;
    }

    public EFlyState State
    {
        get { return m_state; }
        set { m_state = value; }
    }

    void Update ()
    {
        if (Time.time - m_lastCheckTime > 0.1f)
        {
            if(null == s_rocketTrans) 
            {
                m_lastCheckTime = Time.time;
                return;
            }

            int zoneX = (int)((s_rocketTrans.localPosition.x+320) / 640);
            int zoneY = (int)((s_rocketTrans.localPosition.y+568) / 1136);
            
            if(zoneX != m_lastZoneX || zoneY != m_lastZoneY)
            {
                //Debug.Log("lastx:"+m_lastZoneX+",lasty:"+m_lastZoneY);
                //Debug.Log("zonex:"+zoneX+",zoney:"+zoneY);
                
                ArrayList tmpList = new ArrayList();
                for(int i = 0; i < m_zoneList.Count; ++i)
                {
                    tmpList.Add(m_zoneList[i]);
                }
                m_zoneList.Clear();
                
                int[] posList = new int[18]
                {
                    zoneX-1,zoneY-1,zoneX,zoneY-1,zoneX+1,zoneY-1,
                    zoneX-1,zoneY+0,zoneX,zoneY+0,zoneX+1,zoneY+0,
                    zoneX-1,zoneY+1,zoneX,zoneY+1,zoneX+1,zoneY+1,
                };
                
                for(int i = 0; i < posList.Length; i+=2)
                {
                    if(posList[i+1] < 0) continue;
                    
                    string zoneName = "SkyZone_" + posList[i] + "_" + posList[i+1];
                    if(tmpList.Contains(zoneName))
                    {
                        tmpList.Remove(zoneName);
                    }
                    else
                    {
                        GameObject newZone = null;
                        if(0 == posList[i+1]) 
                        {
                            if(0 == posList[i]) newZone = Instantiate(s_zoneBasePrefab);
                            else newZone = Instantiate(s_zoneEarthPrefab);
                        }
                        else newZone = Instantiate(s_zoneNormalPrefab);
                        
                        newZone.transform.SetParent(this.transform);
                        newZone.transform.localPosition = new Vector3(posList[i]*640.0f, posList[i+1]*1136.0f, 0f);
                        newZone.transform.localScale = Vector3.one;
                        newZone.layer = LayerMask.NameToLayer("Flying");
                        newZone.transform.SetAsFirstSibling();
                        newZone.name = zoneName;
                        
                        generateItem(newZone.transform);
                    }
                    
                    m_zoneList.Add(zoneName);
                }
                
                for(int k = 0; k < tmpList.Count; ++k)
                {
                    Transform trans = this.transform.FindChild((string)tmpList[k]);
                    if(trans) Destroy(trans.gameObject);
                }
                
                m_lastZoneX = zoneX;
                m_lastZoneY = zoneY;
            }
            
            m_lastCheckTime = Time.time;
        }
    }
}
