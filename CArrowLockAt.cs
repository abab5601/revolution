public class CArrowLockAt : MonoBehaviour
{
    public Transform target;    //��?
    public Transform self;  //�ۤv
 
    public float direction; //�b?��?����V�A�Ϊ�?���סA�u��������
    public Vector3 u;   //�e��?�G�A�Τ_�P?�W�z���׬O���O?
 
    float devValue = 10f;   //�ë�??�Z��
    float showWidth;    //��devValue?��X?���ߨ�??���Z�á]?�M���^
    float showHeight;
 
    Quaternion originRot;   //�b?�쨤��
 
    // ��l��
    void Start()
    {
        originRot = transform.rotation;
        //showWidth = Screen.width / 2 - devValue;
        //showHeight = Screen.height / 2 - devValue;
    }
 
    void Update()
    {
        // �C?�����s?��@���A�D�n�O??�ϥΤ�K
        showWidth = Screen.width / 2 - devValue;
        showHeight = Screen.height / 2 - devValue;
 
        // ?��V�q�M����
        Vector3 forVec = self.forward;  //?�⥻���^���e�V�q
        Vector3 angVec = (target.position - self.position).normalized;  //�����^�M��?���^��?��?��V�q
 
        Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized; //?�B�ܭ��n�A?�W�z??�V�q?��X�@?�N���V���V�q�Z��g�쥻����xy����
        Vector3 originVec = self.up;
 
        direction = Vector3.Dot(originVec, targetVec);  //�A��y?����V��??�M�e?�A�N�D�X�F�b?�ݭn��?�����שM���ת���?
        u = Vector3.Cross(originVec, targetVec);
 
        direction = Mathf.Acos(direction) * Mathf.Rad2Deg;  //???����
 
        u = self.InverseTransformDirection(u);  //�e??�G???�����^��?
 
        // ?�O��?��
        transform.rotation = originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (u.z > 0 ? 1 : -1)));
 
        // ?��?�e���^�b�̹��W����m
        Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);
        
        //if(Vector3.Dot(forVec, angVec) < 0)
        // ���b�̹�?����?
        if(screenPos.x < devValue || screenPos.x > Screen.width - devValue || screenPos.y < devValue || screenPos.y > Screen.height - devValue || Vector3.Dot(forVec, angVec) < 0)
        {
            Vector3 result = Vector3.zero;
            if (direction == 0) //�S����0�M180����?�ȡA�j�a���Dtan90?�X?���\?�G
            {
                result.y = showHeight;
            }
            else if (direction == 180)
            {
                result.y = -showHeight;
            }
            else    //�D�S��
            {
                // ??����
                float direction_new = 90 - direction;
                float k = Mathf.Tan(Mathf.Deg2Rad * direction_new);
 
                // �x��
                result.x = showHeight / k;
                if ((result.x > (-showWidth)) && (result.x < showWidth))    // ���צb�W�U��?����?
                {
                    result.y = showHeight;
                    if (direction > 90)
                    {
                        result.y = -showHeight;
                        result.x = result.x * -1;
                    }
                }
                else    // ���צb���k��?����?
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
        else    // �b�̹�?����?
        {
            transform.position = screenPos;
        }
    }
}