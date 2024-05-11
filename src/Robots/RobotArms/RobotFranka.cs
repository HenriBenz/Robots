using Rhino.Geometry;
using static System.Math;
using static Robots.Util;

namespace Robots;

public class RobotFranka : RobotArm
{
    internal RobotFranka(string model, double payload, Plane basePlane, Mesh baseMesh, Joint[] joints)
        : base(model, Manufacturers.UR, payload, basePlane, baseMesh, joints) { }

    private protected override MechanismKinematics CreateSolver()
    {
        return new NumericalKinematics(this, true, 2);
    }

    public override double DegreeToRadian(double degree, int i) => degree * (PI / 180.0);
    public override double RadianToDegree(double radian, int i) => radian * (180.0 / PI);

    protected override double[] DefaultAlpha => [0, -HalfPI, HalfPI, HalfPI, -HalfPI, HalfPI, HalfPI];
    protected override double[] DefaultTheta => [0.0, 0, 0, 0, 0, 0, 0];
    protected override int[] DefaultSign => [1, 1, 1, 1, 1, 1, 1];
}
