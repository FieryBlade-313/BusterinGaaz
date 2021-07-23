using UnityEngine;

public class Parameters : MonoBehaviour
{

    Vector2 dir = Vector2.zero;
    [System.Serializable]
    public struct Params
    {
        [Range(0,1)]
        public float angle;
        [Range(0, 1)]
        public float areaCenter;
        [Range(0, 1)]
        public float areaOther;
        [Range(0, 1)]
        public float areaConcentric;

        public float angleScale;
        public float areaScale;

        public float maxLength;
        public float length;
        public float width;
        public float extraLength;
        public float maxIntersectionLength;
    };

    void setDirVector()
    {
        dir = new Vector2(Mathf.Cos(getAngle(true)),Mathf.Sin(getAngle(true)));
    }

    public void setAngle(float angle)
    {
        parameters.angle = angle;
        setDirVector();
    }

    public void setAreaOther(float area)
    {
        parameters.areaOther = area;
    }

    public void setAreaConcentric(float area)
    {
        parameters.areaConcentric = area;
    }

    public void setAreaCenter(float area)
    {
        parameters.areaCenter = area;
    }

    public Vector2 getDirVector()
    {
        return dir;
    }

    public float getAngle(bool radians = false)
    {
        return parameters.angle * parameters.angleScale * ( radians ? Mathf.Deg2Rad : 1 );
    }

    public float getLength()
    {
        return parameters.length;
    }

    public float getWidth()
    {
        return parameters.width;
    }

    public float getExtraLength()
    {
        return parameters.extraLength;
    }

    public float getAreaCenter()
    {
        return parameters.areaCenter * parameters.areaScale;
    }

    public float getAreaOther()
    {
        return parameters.areaOther * parameters.areaScale;
    }

    public float getAreaConcentric()
    {
        return parameters.areaConcentric * parameters.areaScale;
    }

    public Params parameters;

    private void Awake()
    {
        setDirVector();
    }
}
