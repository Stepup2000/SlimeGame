using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}

	public Vec2(GXPEngine.Core.Vector2 vec)
	{
		x = vec.x;
		y = vec.y;
	}

	public float Length()
	{
		return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
	}

	public void NormalizeThis()
	{
		float _length = Length();
		if (_length != 0)
		{
			x = x / _length;
			y = y / _length;
		}
	}

	public Vec2 NewNormalized()
	{
		return new Vec2(x / Length(), y / Length());
	}

	public float Dot(Vec2 other)
	{
		return this.x * other.x + this.y * other.y;
	}

	public Vec2 UnitNormal()
	{
		return new Vec2(-y, x).NewNormalized();
	}

	public void Reflect(Vec2 normal, float COR = 1)
	{
		Vec2 parallel = this.Dot(normal) * normal;
		this -= (1 + COR) * parallel;
	}

	public void SetXY(float newX, float newY)
	{
		x = newX;
		y = newY;
	}

	public static Vec2 GetUnitVectorDeg(float degrees)
	{
		return new Vec2(Mathf.Cos(Deg2Rad(degrees)), Mathf.Sin(Deg2Rad(degrees)));
	}

	public static Vec2 GetUnitVectorRad(float radians)
	{
		return new Vec2(Mathf.Cos(radians), Mathf.Sin(radians));
	}

	public static Vec2 RandomUnitVector()
	{
		float rand_angle = Utils.Random(0.0f, 2f * (float)Math.PI);
		return new Vec2(Mathf.Cos(rand_angle), Mathf.Sin(rand_angle));
	}

	public void SetAngleDegrees(float degrees)
	{
		this = GetUnitVectorDeg(degrees) * this.Length();
	}

	public void SetAngleRadians(float radians)
	{
		this = GetUnitVectorRad(radians) * this.Length();
	}

	public float GetAngleDegrees()
	{
		return Rad2Deg(Mathf.Atan2(y, x));
	}

	public float GetAngleRadians()
	{
		return Mathf.Atan2(y, x);
	}

	public void RotateDegrees(float degrees)
	{
		RotateRadians(Deg2Rad(degrees));
	}

	public void RotateRadians(float radians)
	{
		Vec2 new_x = new Vec2(this.x * Mathf.Cos(radians), this.x * Mathf.Sin(radians));
		Vec2 new_y = new Vec2(this.y * -Mathf.Sin(radians), this.y * Mathf.Cos(radians));

		this = new_x + new_y;
	}

	public void RotateAroundDegrees(Vec2 _around, float degrees)
	{
		this -= _around;
		RotateDegrees(degrees);
		this += _around;
	}

	public void RotateAroundRadians(Vec2 _around, float radians)
	{
		this -= _around;
		RotateRadians(radians);
		this += _around;
	}

	#region OPERATORS + CONVERSIONS
	// -------------------------------
	// operators+conversions
	public static float Deg2Rad(float degrees)
	{
		return degrees * Mathf.PI / 180f;
	}

	public static float Rad2Deg(float radians)
	{
		return radians * 180f / Mathf.PI;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 left, float scalar)
	{
		return new Vec2(left.x * scalar, left.y * scalar);
	}

	public static Vec2 operator *(float scalar, Vec2 right)
	{
		return new Vec2(scalar * right.x, scalar * right.y);
	}

	public static Vec2 operator /(Vec2 left, float scalar)
	{
		return new Vec2(left.x / scalar, left.y / scalar);
	}

	/*public static Vec2 operator /(float scalar, Vec2 right)
	{
		return new Vec2(scalar / right.x, scalar / right.y);
	}*/

	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}
	#endregion
}
