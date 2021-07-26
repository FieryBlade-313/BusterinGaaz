using UnityEngine;

public class Parameters : MonoBehaviour
{

    Vector2 dir = Vector2.zero;
    [System.Serializable]
    public struct Params
    {
        [Range(0,1)]
        public double angle;
        [Range(0, 1)]
        public double areaCenter;
        [Range(0, 1)]
        public double areaOther;
        [Range(0, 1)]
        public double areaConcentric;

        public double angleScale;
        public double areaScale;

        public double maxLength;
        public double length;
        public double width;
        public double extraLength;
        public double maxIntersectionLength;
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
        return (float)(parameters.angle * parameters.angleScale * ( radians ? Mathf.Deg2Rad : 1 ));
    }

    public float getLength()
    {
        return (float)parameters.length;
    }

    public float getWidth()
    {
        return (float)parameters.width;
    }

    public float getExtraLength()
    {
        return (float)(parameters.extraLength);
    }

    public float getAreaCenter()
    {
        return (float)(parameters.areaCenter * parameters.areaScale);
    }

    public float getAreaOther()
    {
        return (float)(parameters.areaOther * parameters.areaScale);
    }

    public float getAreaConcentric()
    {
        return (float)(parameters.areaConcentric * parameters.areaScale);
    }

    public Params parameters;

    private void Awake()
    {
        setDirVector();
    }
}
