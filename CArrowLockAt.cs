public class CArrowLockAt : MonoBehaviour
{
    public Transform target;    //目?
    public Transform self;  //自己
 
    public float direction; //箭?旋?的方向，或者?角度，只有正的值
    public Vector3 u;   //叉乘?果，用于判?上述角度是正是?
 
    float devValue = 10f;   //离屏??距离
    float showWidth;    //由devValue?算出?中心到??的距离（?和高）
    float showHeight;
 
    Quaternion originRot;   //箭?原角度
 
    // 初始化
    void Start()
    {
        originRot = transform.rotation;
        //showWidth = Screen.width / 2 - devValue;
        //showHeight = Screen.height / 2 - devValue;
    }
 
    void Update()
    {
        // 每?都重新?算一次，主要是??使用方便
        showWidth = Screen.width / 2 - devValue;
        showHeight = Screen.height / 2 - devValue;
 
        // ?算向量和角度
        Vector3 forVec = self.forward;  //?算本物体的前向量
        Vector3 angVec = (target.position - self.position).normalized;  //本物体和目?物体之?的?位向量
 
        Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized; //?步很重要，?上述??向量?算出一?代表方向的向量后投射到本身的xy平面
        Vector3 originVec = self.up;
 
        direction = Vector3.Dot(originVec, targetVec);  //再跟y?正方向做??和叉?，就求出了箭?需要旋?的角度和角度的正?
        u = Vector3.Cross(originVec, targetVec);
 
        direction = Mathf.Acos(direction) * Mathf.Rad2Deg;  //???角度
 
        u = self.InverseTransformDirection(u);  //叉??果???本物体坐?
 
        // ?与旋?值
        transform.rotation = originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (u.z > 0 ? 1 : -1)));
 
        // ?算?前物体在屏幕上的位置
        Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);
        
        //if(Vector3.Dot(forVec, angVec) < 0)
        // 不在屏幕?的情?
        if(screenPos.x < devValue || screenPos.x > Screen.width - devValue || screenPos.y < devValue || screenPos.y > Screen.height - devValue || Vector3.Dot(forVec, angVec) < 0)
        {
            Vector3 result = Vector3.zero;
            if (direction == 0) //特殊角度0和180直接?值，大家知道tan90?出?什么?果
            {
                result.y = showHeight;
            }
            else if (direction == 180)
            {
                result.y = -showHeight;
            }
            else    //非特殊角
            {
                // ??角度
                float direction_new = 90 - direction;
                float k = Mathf.Tan(Mathf.Deg2Rad * direction_new);
 
                // 矩形
                result.x = showHeight / k;
                if ((result.x > (-showWidth)) && (result.x < showWidth))    // 角度在上下底?的情?
                {
                    result.y = showHeight;
                    if (direction > 90)
                    {
                        result.y = -showHeight;
                        result.x = result.x * -1;
                    }
                }
                else    // 角度在左右底?的情?
                {
                    result.y = showWidth * k;
                    if ((result.y > -showHeight) && result.y < showHeight)
                    {
                        result.x = result.y / k;
                    }
                }
                if (u.z > 0)
                    result.x = -result.x;
            }
            transform.localPosition = result;
        }
        else    // 在屏幕?的情?
        {
            transform.position = screenPos;
        }
    }
}