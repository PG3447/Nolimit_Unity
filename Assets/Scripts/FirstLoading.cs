using UnityEngine;

public class FirstLoading : MonoBehaviour
{

    private GameObject pacholek;
    private GameObject pacholekhigh;
    private GameObject pacholeknormal;
    private GameObject pacholeklow;
    private GameObject pacholeklownoshadow;
    private GameObject RodzicScian;
    void Awake()
    {
        Mesh mesh = Resources.Load<GameObject>("Prefabs/PacholekNormal").GetComponent<MeshFilter>().sharedMesh;

        pacholek = new GameObject("FirstLoadPacholek");
        

        pacholekhigh = (GameObject)Instantiate(Resources.Load("Prefabs/PacholekHigh"));
        pacholeknormal = (GameObject)Instantiate(Resources.Load("Prefabs/PacholekNormal"));
        pacholeklow = (GameObject)Instantiate(Resources.Load("Prefabs/PacholekLowNoShadowPrefab"));
        pacholeklownoshadow = (GameObject)Instantiate(Resources.Load("Prefabs/PacholekLowLowNoShadow"));

        pacholek.SetActive(false);
        

        //Dzieci
        pacholekhigh.transform.parent = pacholek.transform;
        pacholeknormal.transform.parent = pacholek.transform;
        pacholeklow.transform.parent = pacholek.transform;
        pacholeklownoshadow.transform.parent = pacholek.transform;


        //Atrbuty
        pacholekhigh.GetComponent<MeshRenderer>().motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
        pacholekhigh.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        pacholekhigh.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        pacholekhigh.GetComponent<MeshRenderer>().receiveShadows = false;
        pacholekhigh.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        pacholeknormal.GetComponent<MeshRenderer>().motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
        pacholeknormal.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        pacholeknormal.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        pacholeknormal.GetComponent<MeshRenderer>().receiveShadows = false;
        pacholeknormal.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        pacholeklow.GetComponent<MeshRenderer>().motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
        pacholeklow.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        pacholeklow.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        pacholeklow.GetComponent<MeshRenderer>().receiveShadows = false;
        pacholeklow.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        pacholeklownoshadow.GetComponent<MeshRenderer>().motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
        pacholeklownoshadow.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        pacholeklownoshadow.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        pacholeklownoshadow.GetComponent<MeshRenderer>().receiveShadows = false;
        pacholeklownoshadow.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        pacholeklownoshadow.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        pacholek.AddComponent<LODGroup>();
        LOD[] lods = new LOD[4];
        Renderer[] renderers = new Renderer[1];
        renderers[0] = pacholekhigh.GetComponent<Renderer>();
        lods[0] = new LOD(0.65F, renderers);
        Renderer[] renderrs = new Renderer[1];
        renderrs[0] = pacholeknormal.GetComponent<Renderer>();
        lods[1] = new LOD(0.35F, renderrs);
        Renderer[] renderer = new Renderer[1];
        renderer[0] = pacholeklow.GetComponent<Renderer>();
        lods[2] = new LOD(0.15F, renderer);
        Renderer[] rendererere = new Renderer[1];
        rendererere[0] = pacholeklownoshadow.GetComponent<Renderer>();
        lods[3] = new LOD(0.05F, rendererere);

        pacholek.GetComponent<LODGroup>().SetLODs(lods);
        pacholek.GetComponent<LODGroup>().RecalculateBounds();
        pacholek.AddComponent<MeshCollider>();
        pacholek.GetComponent<MeshCollider>().sharedMesh = mesh;
        pacholek.GetComponent<MeshCollider>().convex = true;
        pacholek.AddComponent<Rigidbody>();
        pacholek.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
        pacholek.GetComponent<Rigidbody>().solverIterations = 1;
        pacholek.AddComponent<GoToSleepPacholek>();
        pacholek.isStatic = true;

        //Sciana Rigidbody £adowanie
        RodzicScian = new GameObject("FirstLoadSciana");
        RodzicScian.SetActive(false);
        RodzicScian.AddComponent<BoxCollider>().isTrigger = true;
        
    }

}
