// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.math.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public partial class Color3
    {
        /// <summary>
        /// </summary>
        public double b;

        /// <summary>
        /// </summary>
        public double g;

        /// <summary>
        /// </summary>
        public double r;

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        public Color3(double r = 0, double g = 0, double b = 0)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Black()
        {
            return new Color3(0, 0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Blue()
        {
            return new Color3(0, 0, 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color3 FromArray(Array<double> array)
        {
            return new Color3(array[0], array[1], array[2]);
        }

        public static Color3 FromArray(double[] array)
        {
            if (array == null || array.Length < 3)
            {
                return null;
            }

            return new Color3(array[0], array[1], array[2]);
        }

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color3 FromInts(double r, double g, double b)
        {
            return new Color3(r / 255.0, g / 255.0, b / 255.0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Gray()
        {
            return new Color3(0.5, 0.5, 0.5);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Green()
        {
            return new Color3(0, 1, 0);
        }

        /// <summary>
        /// </summary>
        /// <param name="start">
        /// </param>
        /// <param name="end">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color3 Lerp(Color3 start, Color3 end, double amount)
        {
            var r = start.r + ((end.r - start.r) * amount);
            var g = start.g + ((end.g - start.g) * amount);
            var b = start.b + ((end.b - start.b) * amount);
            return new Color3(r, g, b);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Magenta()
        {
            return new Color3(1, 0, 1);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Purple()
        {
            return new Color3(0.5, 0, 0.5);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Red()
        {
            return new Color3(1, 0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 White()
        {
            return new Color3(1, 1, 1);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Color3 Yellow()
        {
            return new Color3(1, 1, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "{R: " + this.r + " G:" + this.g + " B:" + this.b + "}";
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color3 add(Color3 otherColor)
        {
            return new Color3(this.r + otherColor.r, this.g + otherColor.g, this.b + otherColor.b);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void addToRef(Color3 otherColor, Color3 result)
        {
            result.r = this.r + otherColor.r;
            result.g = this.g + otherColor.g;
            result.b = this.b + otherColor.b;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            var result = new Array<double>();
            this.toArray(result, 0);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Color3 clone()
        {
            return new Color3(this.r, this.g, this.b);
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        public virtual void copyFrom(Color3 source)
        {
            this.r = source.r;
            this.g = source.g;
            this.b = source.b;
        }

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        public virtual void copyFromFloats(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equals(Color3 otherColor)
        {
            return otherColor != null && this.r == otherColor.r && this.g == otherColor.g && this.b == otherColor.b;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color3 multiply(Color3 otherColor)
        {
            return new Color3(this.r * otherColor.r, this.g * otherColor.g, this.b * otherColor.b);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void multiplyToRef(Color3 otherColor, Color3 result)
        {
            result.r = this.r * otherColor.r;
            result.g = this.g * otherColor.g;
            result.b = this.b * otherColor.b;
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color3 scale(double scale)
        {
            return new Color3(this.r * scale, this.g * scale, this.b * scale);
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void scaleToRef(double scale, Color3 result)
        {
            result.r = this.r * scale;
            result.g = this.g * scale;
            result.b = this.b * scale;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color3 subtract(Color3 otherColor)
        {
            return new Color3(this.r - otherColor.r, this.g - otherColor.g, this.b - otherColor.b);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherColor">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void subtractToRef(Color3 otherColor, Color3 result)
        {
            result.r = this.r - otherColor.r;
            result.g = this.g - otherColor.g;
            result.b = this.b - otherColor.b;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="index">
        /// </param>
        public virtual void toArray(Array<double> array, int index = 0)
        {
            array[index] = this.r;
            array[index + 1] = this.g;
            array[index + 2] = this.b;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Color4
    {
        /// <summary>
        /// </summary>
        public double a;

        /// <summary>
        /// </summary>
        public double b;

        /// <summary>
        /// </summary>
        public double g;

        /// <summary>
        /// </summary>
        public double r;

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <param name="a">
        /// </param>
        public Color4(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color4 FromArray(Array<double> array, int offset = 0)
        {
            return new Color4(array[offset], array[offset + 1], array[offset + 2], array[offset + 3]);
        }

        public static Color4 FromArray(double[] array, int offset = 0)
        {
            if (array == null || array.Length < 4)
            {
                return null;
            }

            return new Color4(array[offset], array[offset + 1], array[offset + 2], array[offset + 3]);
        }

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <param name="a">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color4 FromInts(double r, double g, double b, double a)
        {
            return new Color4(r / 255.0, g / 255.0, b / 255.0, a / 255.0);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color4 Lerp(Color4 left, Color4 right, double amount)
        {
            var result = new Color4(0, 0, 0, 0);
            LerpToRef(left, right, amount, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void LerpToRef(Color4 left, Color4 right, double amount, Color4 result)
        {
            result.r = left.r + (right.r - left.r) * amount;
            result.g = left.g + (right.g - left.g) * amount;
            result.b = left.b + (right.b - left.b) * amount;
            result.a = left.a + (right.a - left.a) * amount;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "{R: " + this.r + " G:" + this.g + " B:" + this.b + " A:" + this.a + "}";
        }

        /// <summary>
        /// </summary>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color4 add(Color4 right)
        {
            return new Color4(this.r + right.r, this.g + right.g, this.b + right.b, this.a + right.a);
        }

        /// <summary>
        /// </summary>
        /// <param name="right">
        /// </param>
        public virtual void addInPlace(Color4 right)
        {
            this.r += right.r;
            this.g += right.g;
            this.b += right.b;
            this.a += right.a;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            var result = new Array<double>();
            this.toArray(result, 0);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Color4 clone()
        {
            return new Color4(this.r, this.g, this.b, this.a);
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color4 scale(double scale)
        {
            return new Color4(this.r * scale, this.g * scale, this.b * scale, this.a * scale);
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void scaleToRef(double scale, Color4 result)
        {
            result.r = this.r * scale;
            result.g = this.g * scale;
            result.b = this.b * scale;
            result.a = this.a * scale;
        }

        /// <summary>
        /// </summary>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color4 subtract(Color4 right)
        {
            return new Color4(this.r - right.r, this.g - right.g, this.b - right.b, this.a - right.a);
        }

        /// <summary>
        /// </summary>
        /// <param name="right">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void subtractToRef(Color4 right, Color4 result)
        {
            result.r = this.r - right.r;
            result.g = this.g - right.g;
            result.b = this.b - right.b;
            result.a = this.a - right.a;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="index">
        /// </param>
        public virtual void toArray(Array<double> array, int index = 0)
        {
            array[index] = this.r;
            array[index + 1] = this.g;
            array[index + 2] = this.b;
            array[index + 3] = this.a;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Vector2
    {
        /// <summary>
        /// </summary>
        public double x;

        /// <summary>
        /// </summary>
        public double y;

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <param name="value3">
        /// </param>
        /// <param name="value4">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, double amount)
        {
            var squared = amount * amount;
            var cubed = amount * squared;
            var x = 0.5
                    * ((((2.0 * value2.x) + ((-value1.x + value3.x) * amount))
                        + (((((2.0 * value1.x) - (5.0 * value2.x)) + (4.0 * value3.x)) - value4.x) * squared))
                       + ((((-value1.x + (3.0 * value2.x)) - (3.0 * value3.x)) + value4.x) * cubed));
            var y = 0.5
                    * ((((2.0 * value2.y) + ((-value1.y + value3.y) * amount))
                        + (((((2.0 * value1.y) - (5.0 * value2.y)) + (4.0 * value3.y)) - value4.y) * squared))
                       + ((((-value1.y + (3.0 * value2.y)) - (3.0 * value3.y)) + value4.y) * cubed));
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <param name="min">
        /// </param>
        /// <param name="Max">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 Max)
        {
            var x = value.x;
            x = (x > Max.x) ? Max.x : x;
            x = (x < min.x) ? min.x : x;
            var y = value.y;
            y = (y > Max.y) ? Max.y : y;
            y = (y < min.y) ? min.y : y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <returns>
        /// </returns>
        public static double Distance(Vector2 value1, Vector2 value2)
        {
            return Math.Sqrt(DistanceSquared(value1, value2));
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <returns>
        /// </returns>
        public static double DistanceSquared(Vector2 value1, Vector2 value2)
        {
            var x = value1.x - value2.x;
            var y = value1.y - value2.y;
            return (x * x) + (y * y);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static double Dot(Vector2 left, Vector2 right)
        {
            return left.x * right.x + left.y * right.y;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 FromArray(Array<double> array, int offset = 0)
        {
            if (array == null || array.Length < 2)
            {
                return null;
            }

            return new Vector2(array[offset], array[offset + 1]);
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="tangent1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <param name="tangent2">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, double amount)
        {
            var squared = amount * amount;
            var cubed = amount * squared;
            var part1 = ((2.0 * cubed) - (3.0 * squared)) + 1.0;
            var part2 = (-2.0 * cubed) + (3.0 * squared);
            var part3 = (cubed - (2.0 * squared)) + amount;
            var part4 = cubed - squared;
            var x = (((value1.x * part1) + (value2.x * part2)) + (tangent1.x * part3)) + (tangent2.x * part4);
            var y = (((value1.y * part1) + (value2.y * part2)) + (tangent1.y * part3)) + (tangent2.y * part4);
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="start">
        /// </param>
        /// <param name="end">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Lerp(Vector2 start, Vector2 end, double amount)
        {
            var x = start.x + ((end.x - start.x) * amount);
            var y = start.y + ((end.y - start.y) * amount);
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Maximize(Vector2 left, Vector2 right)
        {
            var x = (left.x > right.x) ? left.x : right.x;
            var y = (left.y > right.y) ? left.y : right.y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Minimize(Vector2 left, Vector2 right)
        {
            var x = (left.x < right.x) ? left.x : right.x;
            var y = (left.y < right.y) ? left.y : right.y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Normalize(Vector2 vector)
        {
            var newVector = vector.clone();
            newVector.normalize();
            return newVector;
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 Transform(Vector2 vector, Matrix transformation)
        {
            var x = (vector.x * transformation.m[0]) + (vector.y * transformation.m[4]);
            var y = (vector.x * transformation.m[1]) + (vector.y * transformation.m[5]);
            return new Vector2(x, y);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double Length()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "{X: " + this.x + " Y:" + this.y + "}";
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector2 add(Vector2 otherVector)
        {
            return new Vector2(this.x + otherVector.x, this.y + otherVector.y);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            var result = new Array<double>();
            this.toArray(result, 0);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector2 clone()
        {
            return new Vector2(this.x, this.y);
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        public virtual void copyFrom(Vector2 source)
        {
            this.x = source.x;
            this.y = source.y;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equals(Vector2 otherVector)
        {
            return otherVector != null && this.x == otherVector.x && this.y == otherVector.y;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double lengthSquared()
        {
            return this.x * this.x + this.y * this.y;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector2 negate()
        {
            return new Vector2(-this.x, -this.y);
        }

        /// <summary>
        /// </summary>
        public virtual void normalize()
        {
            var len = this.Length();
            if (len == 0)
            {
                return;
            }

            var num = 1.0 / len;
            this.x *= num;
            this.y *= num;
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector2 scale(double scale)
        {
            return new Vector2(this.x * scale, this.y * scale);
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        public virtual void scaleInPlace(double scale)
        {
            this.x *= scale;
            this.y *= scale;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector2 subtract(Vector2 otherVector)
        {
            return new Vector2(this.x - otherVector.x, this.y - otherVector.y);
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="index">
        /// </param>
        public virtual void toArray(Array<double> array, int index = 0)
        {
            array[index] = this.x;
            array[index + 1] = this.y;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Vector3
    {
        /// <summary>
        /// </summary>
        public double x;

        /// <summary>
        /// </summary>
        public double y;

        /// <summary>
        /// </summary>
        public double z;

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <param name="value3">
        /// </param>
        /// <param name="value4">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, double amount)
        {
            var squared = amount * amount;
            var cubed = amount * squared;
            var x = 0.5
                    * ((((2.0 * value2.x) + ((-value1.x + value3.x) * amount))
                        + (((((2.0 * value1.x) - (5.0 * value2.x)) + (4.0 * value3.x)) - value4.x) * squared))
                       + ((((-value1.x + (3.0 * value2.x)) - (3.0 * value3.x)) + value4.x) * cubed));
            var y = 0.5
                    * ((((2.0 * value2.y) + ((-value1.y + value3.y) * amount))
                        + (((((2.0 * value1.y) - (5.0 * value2.y)) + (4.0 * value3.y)) - value4.y) * squared))
                       + ((((-value1.y + (3.0 * value2.y)) - (3.0 * value3.y)) + value4.y) * cubed));
            var z = 0.5
                    * ((((2.0 * value2.z) + ((-value1.z + value3.z) * amount))
                        + (((((2.0 * value1.z) - (5.0 * value2.z)) + (4.0 * value3.z)) - value4.z) * squared))
                       + ((((-value1.z + (3.0 * value2.z)) - (3.0 * value3.z)) + value4.z) * cubed));
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Center(Vector3 value1, Vector3 value2)
        {
            var center = value1.add(value2);
            center.scaleInPlace(0.5);
            return center;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <param name="min">
        /// </param>
        /// <param name="Max">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 Max)
        {
            var x = value.x;
            x = (x > Max.x) ? Max.x : x;
            x = (x < min.x) ? min.x : x;
            var y = value.y;
            y = (y > Max.y) ? Max.y : y;
            y = (y < min.y) ? min.y : y;
            var z = value.z;
            z = (z > Max.z) ? Max.z : z;
            z = (z < min.z) ? min.z : z;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            var result = Zero();
            CrossToRef(left, right, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void CrossToRef(Vector3 left, Vector3 right, Vector3 result)
        {
            result.x = left.y * right.z - left.z * right.y;
            result.y = left.z * right.x - left.x * right.z;
            result.z = left.x * right.y - left.y * right.x;
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <returns>
        /// </returns>
        public static double Distance(Vector3 value1, Vector3 value2)
        {
            return Math.Sqrt(DistanceSquared(value1, value2));
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <returns>
        /// </returns>
        public static double DistanceSquared(Vector3 value1, Vector3 value2)
        {
            var x = value1.x - value2.x;
            var y = value1.y - value2.y;
            var z = value1.z - value2.z;
            return (x * x) + (y * y) + (z * z);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static double Dot(Vector3 left, Vector3 right)
        {
            return left.x * right.x + left.y * right.y + left.z * right.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 FromArray(Array<double> array, int offset = 0)
        {
            return new Vector3(array[offset], array[offset + 1], array[offset + 2]);
        }

        public static Vector3 FromArray(double[] array, int offset = 0)
        {
            if (array == null || array.Length < 3)
            {
                return null;
            }

            return new Vector3(array[offset], array[offset + 1], array[offset + 2]);
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void FromArrayToRef(Array<double> array, int offset, Vector3 result)
        {
            result.x = array[offset];
            result.y = array[offset + 1];
            result.z = array[offset + 2];
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void FromFloatArrayToRef(double[] array, int offset, Vector3 result)
        {
            result.x = array[offset];
            result.y = array[offset + 1];
            result.z = array[offset + 2];
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void FromFloatsToRef(double x, double y, double z, Vector3 result)
        {
            result.x = x;
            result.y = y;
            result.z = z;
        }

        /// <summary>
        /// </summary>
        /// <param name="value1">
        /// </param>
        /// <param name="tangent1">
        /// </param>
        /// <param name="value2">
        /// </param>
        /// <param name="tangent2">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, double amount)
        {
            var squared = amount * amount;
            var cubed = amount * squared;
            var part1 = ((2.0 * cubed) - (3.0 * squared)) + 1.0;
            var part2 = (-2.0 * cubed) + (3.0 * squared);
            var part3 = (cubed - (2.0 * squared)) + amount;
            var part4 = cubed - squared;
            var x = (((value1.x * part1) + (value2.x * part2)) + (tangent1.x * part3)) + (tangent2.x * part4);
            var y = (((value1.y * part1) + (value2.y * part2)) + (tangent1.y * part3)) + (tangent2.y * part4);
            var z = (((value1.z * part1) + (value2.z * part2)) + (tangent1.z * part3)) + (tangent2.z * part4);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="start">
        /// </param>
        /// <param name="end">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Lerp(Vector3 start, Vector3 end, double amount)
        {
            var x = start.x + ((end.x - start.x) * amount);
            var y = start.y + ((end.y - start.y) * amount);
            var z = start.z + ((end.z - start.z) * amount);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Maximize(Vector3 left, Vector3 right)
        {
            var Max = left.clone();
            Max.MaximizeInPlace(right);
            return Max;
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Minimize(Vector3 left, Vector3 right)
        {
            var min = left.clone();
            min.MinimizeInPlace(right);
            return min;
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Normalize(Vector3 vector)
        {
            var result = Zero();
            NormalizeToRef(vector, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void NormalizeToRef(Vector3 vector, Vector3 result)
        {
            result.copyFrom(vector);
            result.normalize();
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="world">
        /// </param>
        /// <param name="transform">
        /// </param>
        /// <param name="viewport">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Project(Vector3 vector, Matrix world, Matrix transform, Viewport viewport)
        {
            var cw = viewport.width;
            var ch = viewport.height;
            var cx = viewport.x;
            var cy = viewport.y;
            var viewportMatrix = Matrix.FromValues(cw / 2.0, 0, 0, 0, 0, -ch / 2.0, 0, 0, 0, 0, 1, 0, cx + cw / 2.0, ch / 2.0 + cy, 0, 1);
            var finalMatrix = world.multiply(transform).multiply(viewportMatrix);
            return TransformCoordinates(vector, finalMatrix);
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 TransformCoordinates(Vector3 vector, Matrix transformation)
        {
            var result = Zero();
            TransformCoordinatesToRef(vector, transformation, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void TransformCoordinatesFromFloatsToRef(double x, double y, double z, Matrix transformation, Vector3 result)
        {
            var rx = (x * transformation.m[0]) + (y * transformation.m[4]) + (z * transformation.m[8]) + transformation.m[12];
            var ry = (x * transformation.m[1]) + (y * transformation.m[5]) + (z * transformation.m[9]) + transformation.m[13];
            var rz = (x * transformation.m[2]) + (y * transformation.m[6]) + (z * transformation.m[10]) + transformation.m[14];
            var rw = (x * transformation.m[3]) + (y * transformation.m[7]) + (z * transformation.m[11]) + transformation.m[15];
            result.x = rx / rw;
            result.y = ry / rw;
            result.z = rz / rw;
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void TransformCoordinatesToRef(Vector3 vector, Matrix transformation, Vector3 result)
        {
            var x = (vector.x * transformation.m[0]) + (vector.y * transformation.m[4]) + (vector.z * transformation.m[8]) + transformation.m[12];
            var y = (vector.x * transformation.m[1]) + (vector.y * transformation.m[5]) + (vector.z * transformation.m[9]) + transformation.m[13];
            var z = (vector.x * transformation.m[2]) + (vector.y * transformation.m[6]) + (vector.z * transformation.m[10]) + transformation.m[14];
            var w = (vector.x * transformation.m[3]) + (vector.y * transformation.m[7]) + (vector.z * transformation.m[11]) + transformation.m[15];
            result.x = x / w;
            result.y = y / w;
            result.z = z / w;
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 TransformNormal(Vector3 vector, Matrix transformation)
        {
            var result = Zero();
            TransformNormalToRef(vector, transformation, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void TransformNormalFromFloatsToRef(double x, double y, double z, Matrix transformation, Vector3 result)
        {
            result.x = (x * transformation.m[0]) + (y * transformation.m[4]) + (z * transformation.m[8]);
            result.y = (x * transformation.m[1]) + (y * transformation.m[5]) + (z * transformation.m[9]);
            result.z = (x * transformation.m[2]) + (y * transformation.m[6]) + (z * transformation.m[10]);
        }

        /// <summary>
        /// </summary>
        /// <param name="vector">
        /// </param>
        /// <param name="transformation">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void TransformNormalToRef(Vector3 vector, Matrix transformation, Vector3 result)
        {
            result.x = (vector.x * transformation.m[0]) + (vector.y * transformation.m[4]) + (vector.z * transformation.m[8]);
            result.y = (vector.x * transformation.m[1]) + (vector.y * transformation.m[5]) + (vector.z * transformation.m[9]);
            result.z = (vector.x * transformation.m[2]) + (vector.y * transformation.m[6]) + (vector.z * transformation.m[10]);
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <param name="viewportWidth">
        /// </param>
        /// <param name="viewportHeight">
        /// </param>
        /// <param name="world">
        /// </param>
        /// <param name="view">
        /// </param>
        /// <param name="projection">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Unproject(Vector3 source, double viewportWidth, double viewportHeight, Matrix world, Matrix view, Matrix projection)
        {
            var matrix = world.multiply(view).multiply(projection);
            matrix.invert();
            source.x = source.x / viewportWidth * 2 - 1;
            source.y = -(source.y / viewportHeight * 2 - 1);
            var vector = TransformCoordinates(source, matrix);
            var num = source.x * matrix.m[3] + source.y * matrix.m[7] + source.z * matrix.m[11] + matrix.m[15];
            if (Tools.WithinEpsilon(num, 1.0))
            {
                vector = vector.scale(1.0 / num);
            }

            return vector;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Vector3 Up()
        {
            return new Vector3(0, 1.0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double Length()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        public virtual void MaximizeInPlace(Vector3 other)
        {
            if (other.x > this.x)
            {
                this.x = other.x;
            }

            if (other.y > this.y)
            {
                this.y = other.y;
            }

            if (other.z > this.z)
            {
                this.z = other.z;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        public virtual void MinimizeInPlace(Vector3 other)
        {
            if (other.x < this.x)
            {
                this.x = other.x;
            }

            if (other.y < this.y)
            {
                this.y = other.y;
            }

            if (other.z < this.z)
            {
                this.z = other.z;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "{X: " + this.x + " Y:" + this.y + " Z:" + this.z + "}";
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 add(Vector3 otherVector)
        {
            return new Vector3(this.x + otherVector.x, this.y + otherVector.y, this.z + otherVector.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        public virtual void addInPlace(Vector3 otherVector)
        {
            this.x += otherVector.x;
            this.y += otherVector.y;
            this.z += otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void addToRef(Vector3 otherVector, Vector3 result)
        {
            result.x = this.x + otherVector.x;
            result.y = this.y + otherVector.y;
            result.z = this.z + otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            var result = new Array<double>();
            this.toArray(result, 0);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 clone()
        {
            return new Vector3(this.x, this.y, this.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        public virtual void copyFrom(Vector3 source)
        {
            this.x = source.x;
            this.y = source.y;
            this.z = source.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        public virtual void copyFromFloats(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 divide(Vector3 otherVector)
        {
            return new Vector3(this.x / otherVector.x, this.y / otherVector.y, this.z / otherVector.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void divideToRef(Vector3 otherVector, Vector3 result)
        {
            result.x = this.x / otherVector.x;
            result.y = this.y / otherVector.y;
            result.z = this.z / otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equals(Vector3 otherVector)
        {
            return otherVector != null && this.x == otherVector.x && this.y == otherVector.y && this.z == otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equalsToFloats(double x, double y, double z)
        {
            return this.x == x && this.y == y && this.z == z;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double lengthSquared()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 multiply(Vector3 otherVector)
        {
            return new Vector3(this.x * otherVector.x, this.y * otherVector.y, this.z * otherVector.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 multiplyByFloats(double x, double y, double z)
        {
            return new Vector3(this.x * x, this.y * y, this.z * z);
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        public virtual void multiplyInPlace(Vector3 otherVector)
        {
            this.x *= otherVector.x;
            this.y *= otherVector.y;
            this.z *= otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void multiplyToRef(Vector3 otherVector, Vector3 result)
        {
            result.x = this.x * otherVector.x;
            result.y = this.y * otherVector.y;
            result.z = this.z * otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 negate()
        {
            return new Vector3(-this.x, -this.y, -this.z);
        }

        /// <summary>
        /// </summary>
        public virtual void normalize()
        {
            var len = this.Length();
            if (len == 0)
            {
                return;
            }

            var num = 1.0 / len;
            this.x *= num;
            this.y *= num;
            this.z *= num;
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 scale(double scale)
        {
            return new Vector3(this.x * scale, this.y * scale, this.z * scale);
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        public virtual void scaleInPlace(double scale)
        {
            this.x *= scale;
            this.y *= scale;
            this.z *= scale;
        }

        /// <summary>
        /// </summary>
        /// <param name="scale">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void scaleToRef(double scale, Vector3 result)
        {
            result.x = this.x * scale;
            result.y = this.y * scale;
            result.z = this.z * scale;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 subtract(Vector3 otherVector)
        {
            return new Vector3(this.x - otherVector.x, this.y - otherVector.y, this.z - otherVector.z);
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 subtractFromFloats(double x, double y, double z)
        {
            return new Vector3(this.x - x, this.y - y, this.z - z);
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void subtractFromFloatsToRef(double x, double y, double z, Vector3 result)
        {
            result.x = this.x - x;
            result.y = this.y - y;
            result.z = this.z - z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        public virtual void subtractInPlace(Vector3 otherVector)
        {
            this.x -= otherVector.x;
            this.y -= otherVector.y;
            this.z -= otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherVector">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void subtractToRef(Vector3 otherVector, Vector3 result)
        {
            result.x = this.x - otherVector.x;
            result.y = this.y - otherVector.y;
            result.z = this.z - otherVector.z;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="index">
        /// </param>
        public virtual void toArray(Array<double> array, int index = 0)
        {
            array[index] = this.x;
            array[index + 1] = this.y;
            array[index + 2] = this.z;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Quaternion
    {
        /// <summary>
        /// </summary>
        public double w;

        /// <summary>
        /// </summary>
        public double x;

        /// <summary>
        /// </summary>
        public double y;

        /// <summary>
        /// </summary>
        public double z;

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="w">
        /// </param>
        public Quaternion(double x = 0, double y = 0, double z = 0, double w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <returns>
        /// </returns>
        public static Quaternion FromArray(Array<double> array, int offset = 0)
        {
            return new Quaternion(array[offset], array[offset + 1], array[offset + 2], array[offset + 3]);
        }

        public static Quaternion FromArray(double[] array, int offset = 0)
        {
            if (array == null || array.Length < 4)
            {
                return null;
            }

            return new Quaternion(array[offset], array[offset + 1], array[offset + 2], array[offset + 3]);
        }

        /// <summary>
        /// </summary>
        /// <param name="axis">
        /// </param>
        /// <param name="angle">
        /// </param>
        /// <returns>
        /// </returns>
        public static Quaternion RotationAxis(Vector3 axis, double angle)
        {
            var result = new Quaternion();
            var Sin = Math.Sin(angle / 2);
            result.w = Math.Cos(angle / 2);
            result.x = axis.x * Sin;
            result.y = axis.y * Sin;
            result.z = axis.z * Sin;
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="yaw">
        /// </param>
        /// <param name="pitch">
        /// </param>
        /// <param name="roll">
        /// </param>
        /// <returns>
        /// </returns>
        public static Quaternion RotationYawPitchRoll(double yaw, double pitch, double roll)
        {
            var result = new Quaternion();
            RotationYawPitchRollToRef(yaw, pitch, roll, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="yaw">
        /// </param>
        /// <param name="pitch">
        /// </param>
        /// <param name="roll">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void RotationYawPitchRollToRef(double yaw, double pitch, double roll, Quaternion result)
        {
            var halfRoll = roll * 0.5;
            var halfPitch = pitch * 0.5;
            var halfYaw = yaw * 0.5;
            var sinRoll = Math.Sin(halfRoll);
            var cosRoll = Math.Cos(halfRoll);
            var sinPitch = Math.Sin(halfPitch);
            var cosPitch = Math.Cos(halfPitch);
            var sinYaw = Math.Sin(halfYaw);
            var cosYaw = Math.Cos(halfYaw);
            result.x = (cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll);
            result.y = (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll);
            result.z = (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll);
            result.w = (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="amount">
        /// </param>
        /// <returns>
        /// </returns>
        public static Quaternion Slerp(Quaternion left, Quaternion right, double amount)
        {
            double num2;
            double num3;
            var num = amount;
            var num4 = (((left.x * right.x) + (left.y * right.y)) + (left.z * right.z)) + (left.w * right.w);
            var flag = false;
            if (num4 < 0)
            {
                flag = true;
                num4 = -num4;
            }

            if (num4 > 0.999999)
            {
                num3 = 1 - num;
                num2 = flag ? -num : num;
            }
            else
            {
                var num5 = Math.Acos(num4);
                var num6 = 1.0 / Math.Sin(num5);
                num3 = Math.Sin((1.0 - num) * num5) * num6;
                num2 = flag ? ((-Math.Sin(num * num5)) * num6) : ((Math.Sin(num * num5)) * num6);
            }

            return new Quaternion(
                (num3 * left.x) + (num2 * right.x), (num3 * left.y) + (num2 * right.y), (num3 * left.z) + (num2 * right.z), (num3 * left.w) + (num2 * right.w));
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double Length()
        {
            return Math.Sqrt((this.x * this.x) + (this.y * this.y) + (this.z * this.z) + (this.w * this.w));
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "{X: " + this.x + " Y:" + this.y + " Z:" + this.z + " W:" + this.w + "}";
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Quaternion add(Quaternion other)
        {
            return new Quaternion(this.x + other.x, this.y + other.y, this.z + other.z, this.w + other.w);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            return new Array<double>(this.x, this.y, this.z, this.w);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Quaternion clone()
        {
            return new Quaternion(this.x, this.y, this.z, this.w);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        public virtual void copyFrom(Quaternion other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = other.w;
        }

        /// <summary>
        /// </summary>
        /// <param name="otherQuaternion">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equals(Quaternion otherQuaternion)
        {
            return otherQuaternion != null && this.x == otherQuaternion.x && this.y == otherQuaternion.y && this.z == otherQuaternion.z
                   && this.w == otherQuaternion.w;
        }

        /// <summary>
        /// </summary>
        /// <param name="q1">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Quaternion multiply(Quaternion q1)
        {
            var result = new Quaternion(0, 0, 0, 1.0);
            this.multiplyToRef(q1, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="q1">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void multiplyToRef(Quaternion q1, Quaternion result)
        {
            result.x = this.x * q1.w + this.y * q1.z - this.z * q1.y + this.w * q1.x;
            result.y = -this.x * q1.z + this.y * q1.w + this.z * q1.x + this.w * q1.y;
            result.z = this.x * q1.y - this.y * q1.x + this.z * q1.w + this.w * q1.z;
            result.w = -this.x * q1.x - this.y * q1.y - this.z * q1.z + this.w * q1.w;
        }

        /// <summary>
        /// </summary>
        public virtual void normalize()
        {
            var Length = 1.0 / this.Length();
            this.x *= Length;
            this.y *= Length;
            this.z *= Length;
            this.w *= Length;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Quaternion scale(double value)
        {
            return new Quaternion(this.x * value, this.y * value, this.z * value, this.w * value);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Quaternion subtract(Quaternion other)
        {
            return new Quaternion(this.x - other.x, this.y - other.y, this.z - other.z, this.w - other.w);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 toEulerAngles()
        {
            var qx = this.x;
            var qy = this.y;
            var qz = this.z;
            var qw = this.w;
            var sqx = qx * qx;
            var sqy = qy * qy;
            var sqz = qz * qz;
            var yaw = Math.Atan2(2.0 * (qy * qw - qx * qz), 1.0 - 2.0 * (sqy + sqz));
            var pitch = Math.Asin(2.0 * (qx * qy + qz * qw));
            var roll = Math.Atan2(2.0 * (qx * qw - qy * qz), 1.0 - 2.0 * (sqx + sqz));
            var gimbaLockTest = qx * qy + qz * qw;
            if (gimbaLockTest > 0.499)
            {
                yaw = 2.0 * Math.Atan2(qx, qw);
                roll = 0;
            }
            else if (gimbaLockTest < -0.499)
            {
                yaw = -2.0 * Math.Atan2(qx, qw);
                roll = 0;
            }

            return new Vector3(pitch, yaw, roll);
        }

        /// <summary>
        /// </summary>
        /// <param name="result">
        /// </param>
        public virtual void toRotationMatrix(Matrix result)
        {
            var xx = this.x * this.x;
            var yy = this.y * this.y;
            var zz = this.z * this.z;
            var xy = this.x * this.y;
            var zw = this.z * this.w;
            var zx = this.z * this.x;
            var yw = this.y * this.w;
            var yz = this.y * this.z;
            var xw = this.x * this.w;
            result.m[0] = 1.0 - (2.0 * (yy + zz));
            result.m[1] = 2.0 * (xy + zw);
            result.m[2] = 2.0 * (zx - yw);
            result.m[3] = 0;
            result.m[4] = 2.0 * (xy - zw);
            result.m[5] = 1.0 - (2.0 * (zz + xx));
            result.m[6] = 2.0 * (yz + xw);
            result.m[7] = 0;
            result.m[8] = 2.0 * (zx + yw);
            result.m[9] = 2.0 * (yz - xw);
            result.m[10] = 1.0 - (2.0 * (yy + xx));
            result.m[11] = 0;
            result.m[12] = 0;
            result.m[13] = 0;
            result.m[14] = 0;
            result.m[15] = 1.0;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Matrix
    {
        /// <summary>
        /// </summary>
        public double[] m = new double[16];

        /// <summary>
        /// </summary>
        private static readonly Quaternion _tempQuaternion = new Quaternion();

        /// <summary>
        /// </summary>
        private static readonly Vector3 _xAxis = Vector3.Zero();

        /// <summary>
        /// </summary>
        private static readonly Vector3 _yAxis = Vector3.Zero();

        /// <summary>
        /// </summary>
        private static readonly Vector3 _zAxis = Vector3.Zero();

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix FromArray(Array<double> array, int offset = 0)
        {
            var result = new Matrix();
            FromArrayToRef(array, offset, result);
            return result;
        }

        public static Matrix FromArray(double[] array, int offset = 0)
        {
            if (array == null || array.Length < 16)
            {
                return null;
            }

            var result = new Matrix();
            FromArrayToRef(array, offset, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void FromArrayToRef(Array<double> array, int offset, Matrix result)
        {
            for (var index = 0; index < 16; index++)
            {
                result.m[index] = array[index + offset];
            }
        }

        public static void FromArrayToRef(double[] array, int offset, Matrix result)
        {
            for (var index = 0; index < 16; index++)
            {
                result.m[index] = array[index + offset];
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="initialM11">
        /// </param>
        /// <param name="initialM12">
        /// </param>
        /// <param name="initialM13">
        /// </param>
        /// <param name="initialM14">
        /// </param>
        /// <param name="initialM21">
        /// </param>
        /// <param name="initialM22">
        /// </param>
        /// <param name="initialM23">
        /// </param>
        /// <param name="initialM24">
        /// </param>
        /// <param name="initialM31">
        /// </param>
        /// <param name="initialM32">
        /// </param>
        /// <param name="initialM33">
        /// </param>
        /// <param name="initialM34">
        /// </param>
        /// <param name="initialM41">
        /// </param>
        /// <param name="initialM42">
        /// </param>
        /// <param name="initialM43">
        /// </param>
        /// <param name="initialM44">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix FromValues(
            double initialM11, 
            double initialM12, 
            double initialM13, 
            double initialM14, 
            double initialM21, 
            double initialM22, 
            double initialM23, 
            double initialM24, 
            double initialM31, 
            double initialM32, 
            double initialM33, 
            double initialM34, 
            double initialM41, 
            double initialM42, 
            double initialM43, 
            double initialM44)
        {
            var result = new Matrix();
            result.m[0] = initialM11;
            result.m[1] = initialM12;
            result.m[2] = initialM13;
            result.m[3] = initialM14;
            result.m[4] = initialM21;
            result.m[5] = initialM22;
            result.m[6] = initialM23;
            result.m[7] = initialM24;
            result.m[8] = initialM31;
            result.m[9] = initialM32;
            result.m[10] = initialM33;
            result.m[11] = initialM34;
            result.m[12] = initialM41;
            result.m[13] = initialM42;
            result.m[14] = initialM43;
            result.m[15] = initialM44;
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="initialM11">
        /// </param>
        /// <param name="initialM12">
        /// </param>
        /// <param name="initialM13">
        /// </param>
        /// <param name="initialM14">
        /// </param>
        /// <param name="initialM21">
        /// </param>
        /// <param name="initialM22">
        /// </param>
        /// <param name="initialM23">
        /// </param>
        /// <param name="initialM24">
        /// </param>
        /// <param name="initialM31">
        /// </param>
        /// <param name="initialM32">
        /// </param>
        /// <param name="initialM33">
        /// </param>
        /// <param name="initialM34">
        /// </param>
        /// <param name="initialM41">
        /// </param>
        /// <param name="initialM42">
        /// </param>
        /// <param name="initialM43">
        /// </param>
        /// <param name="initialM44">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void FromValuesToRef(
            double initialM11, 
            double initialM12, 
            double initialM13, 
            double initialM14, 
            double initialM21, 
            double initialM22, 
            double initialM23, 
            double initialM24, 
            double initialM31, 
            double initialM32, 
            double initialM33, 
            double initialM34, 
            double initialM41, 
            double initialM42, 
            double initialM43, 
            double initialM44, 
            Matrix result)
        {
            result.m[0] = initialM11;
            result.m[1] = initialM12;
            result.m[2] = initialM13;
            result.m[3] = initialM14;
            result.m[4] = initialM21;
            result.m[5] = initialM22;
            result.m[6] = initialM23;
            result.m[7] = initialM24;
            result.m[8] = initialM31;
            result.m[9] = initialM32;
            result.m[10] = initialM33;
            result.m[11] = initialM34;
            result.m[12] = initialM41;
            result.m[13] = initialM42;
            result.m[14] = initialM43;
            result.m[15] = initialM44;
        }

        /// <summary>
        /// </summary>
        /// <param name="viewport">
        /// </param>
        /// <param name="world">
        /// </param>
        /// <param name="view">
        /// </param>
        /// <param name="projection">
        /// </param>
        /// <param name="zmin">
        /// </param>
        /// <param name="zmax">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix GetFinalMatrix(Viewport viewport, Matrix world, Matrix view, Matrix projection, double zmin, double zmax)
        {
            var cw = viewport.width;
            var ch = viewport.height;
            var cx = viewport.x;
            var cy = viewport.y;
            var viewportMatrix = FromValues(cw / 2.0, 0, 0, 0, 0, -ch / 2.0, 0, 0, 0, 0, zmax - zmin, 0, cx + cw / 2.0, ch / 2.0 + cy, zmin, 1);
            return world.multiply(view).multiply(projection).multiply(viewportMatrix);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Matrix Identity()
        {
            return FromValues(1.0, 0, 0, 0, 0, 1.0, 0, 0, 0, 0, 1.0, 0, 0, 0, 0, 1.0);
        }

        /// <summary>
        /// </summary>
        /// <param name="result">
        /// </param>
        public static void IdentityToRef(Matrix result)
        {
            FromValuesToRef(1.0, 0, 0, 0, 0, 1.0, 0, 0, 0, 0, 1.0, 0, 0, 0, 0, 1.0, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="eye">
        /// </param>
        /// <param name="target">
        /// </param>
        /// <param name="up">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
        {
            var result = Zero();
            LookAtLHToRef(eye, target, up, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="eye">
        /// </param>
        /// <param name="target">
        /// </param>
        /// <param name="up">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void LookAtLHToRef(Vector3 eye, Vector3 target, Vector3 up, Matrix result)
        {
            target.subtractToRef(eye, _zAxis);
            _zAxis.normalize();
            Vector3.CrossToRef(up, _zAxis, _xAxis);
            _xAxis.normalize();
            Vector3.CrossToRef(_zAxis, _xAxis, _yAxis);
            _yAxis.normalize();
            var ex = -Vector3.Dot(_xAxis, eye);
            var ey = -Vector3.Dot(_yAxis, eye);
            var ez = -Vector3.Dot(_zAxis, eye);
            FromValuesToRef(_xAxis.x, _yAxis.x, _zAxis.x, 0, _xAxis.y, _yAxis.y, _zAxis.y, 0, _xAxis.z, _yAxis.z, _zAxis.z, 0, ex, ey, ez, 1, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix OrthoLH(double width, double height, double znear, double zfar)
        {
            var hw = 2.0 / width;
            var hh = 2.0 / height;
            var id = 1.0 / (zfar - znear);
            var nid = znear / (znear - zfar);
            return FromValues(hw, 0, 0, 0, 0, hh, 0, 0, 0, 0, id, 0, 0, 0, nid, 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="bottom">
        /// </param>
        /// <param name="top">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix OrthoOffCenterLH(double left, double right, double bottom, double top, double znear, double zfar)
        {
            var matrix = Zero();
            OrthoOffCenterLHToRef(left, right, bottom, top, znear, zfar, matrix);
            return matrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <param name="bottom">
        /// </param>
        /// <param name="top">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void OrthoOffCenterLHToRef(double left, double right, double bottom, double top, double znear, double zfar, Matrix result)
        {
            result.m[0] = 2.0 / (right - left);
            result.m[1] = result.m[2] = result.m[3] = 0;
            result.m[5] = 2.0 / (top - bottom);
            result.m[4] = result.m[6] = result.m[7] = 0;
            result.m[10] = -1.0 / (znear - zfar);
            result.m[8] = result.m[9] = result.m[11] = 0;
            result.m[12] = (left + right) / (left - right);
            result.m[13] = (top + bottom) / (bottom - top);
            result.m[14] = znear / (znear - zfar);
            result.m[15] = 1.0;
        }

        /// <summary>
        /// </summary>
        /// <param name="fov">
        /// </param>
        /// <param name="aspect">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix PerspectiveFovLH(double fov, double aspect, double znear, double zfar)
        {
            var matrix = Zero();
            PerspectiveFovLHToRef(fov, aspect, znear, zfar, matrix);
            return matrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="fov">
        /// </param>
        /// <param name="aspect">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void PerspectiveFovLHToRef(double fov, double aspect, double znear, double zfar, Matrix result)
        {
            var Tan = 1.0 / Math.Tan(fov * 0.5);
            result.m[0] = Tan / aspect;
            result.m[1] = result.m[2] = result.m[3] = 0.0;
            result.m[5] = Tan;
            result.m[4] = result.m[6] = result.m[7] = 0.0;
            result.m[8] = result.m[9] = 0.0;
            result.m[10] = -zfar / (znear - zfar);
            result.m[11] = 1.0;
            result.m[12] = result.m[13] = result.m[15] = 0.0;
            result.m[14] = (znear * zfar) / (znear - zfar);
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="znear">
        /// </param>
        /// <param name="zfar">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix PerspectiveLH(double width, double height, double znear, double zfar)
        {
            var matrix = Zero();
            matrix.m[0] = (2.0 * znear) / width;
            matrix.m[1] = matrix.m[2] = matrix.m[3] = 0.0;
            matrix.m[5] = (2.0 * znear) / height;
            matrix.m[4] = matrix.m[6] = matrix.m[7] = 0.0;
            matrix.m[10] = -zfar / (znear - zfar);
            matrix.m[8] = matrix.m[9] = 0.0;
            matrix.m[11] = 1.0;
            matrix.m[12] = matrix.m[13] = matrix.m[15] = 0.0;
            matrix.m[14] = (znear * zfar) / (znear - zfar);
            return matrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="plane">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix Reflection(Plane plane)
        {
            var matrix = new Matrix();
            ReflectionToRef(plane, matrix);
            return matrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="plane">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void ReflectionToRef(Plane plane, Matrix result)
        {
            plane.normalize();
            var x = plane.normal.x;
            var y = plane.normal.y;
            var z = plane.normal.z;
            var temp = -2 * x;
            var temp2 = -2 * y;
            var temp3 = -2 * z;
            result.m[0] = (temp * x) + 1;
            result.m[1] = temp2 * x;
            result.m[2] = temp3 * x;
            result.m[3] = 0.0;
            result.m[4] = temp * y;
            result.m[5] = (temp2 * y) + 1;
            result.m[6] = temp3 * y;
            result.m[7] = 0.0;
            result.m[8] = temp * z;
            result.m[9] = temp2 * z;
            result.m[10] = (temp3 * z) + 1;
            result.m[11] = 0.0;
            result.m[12] = temp * plane.d;
            result.m[13] = temp2 * plane.d;
            result.m[14] = temp3 * plane.d;
            result.m[15] = 1.0;
        }

        /// <summary>
        /// </summary>
        /// <param name="axis">
        /// </param>
        /// <param name="angle">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix RotationAxis(Vector3 axis, double angle)
        {
            var s = Math.Sin(-angle);
            var c = Math.Cos(-angle);
            var c1 = 1 - c;
            axis.normalize();
            var result = Zero();
            result.m[0] = (axis.x * axis.x) * c1 + c;
            result.m[1] = (axis.x * axis.y) * c1 - (axis.z * s);
            result.m[2] = (axis.x * axis.z) * c1 + (axis.y * s);
            result.m[3] = 0.0;
            result.m[4] = (axis.y * axis.x) * c1 + (axis.z * s);
            result.m[5] = (axis.y * axis.y) * c1 + c;
            result.m[6] = (axis.y * axis.z) * c1 - (axis.x * s);
            result.m[7] = 0.0;
            result.m[8] = (axis.z * axis.x) * c1 - (axis.y * s);
            result.m[9] = (axis.z * axis.y) * c1 + (axis.x * s);
            result.m[10] = (axis.z * axis.z) * c1 + c;
            result.m[11] = 0.0;
            result.m[15] = 1.0;
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix RotationX(double angle)
        {
            var result = new Matrix();
            RotationXToRef(angle, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void RotationXToRef(double angle, Matrix result)
        {
            var s = Math.Sin(angle);
            var c = Math.Cos(angle);
            result.m[0] = 1.0;
            result.m[15] = 1.0;
            result.m[5] = c;
            result.m[10] = c;
            result.m[9] = -s;
            result.m[6] = s;
            result.m[1] = 0;
            result.m[2] = 0;
            result.m[3] = 0;
            result.m[4] = 0;
            result.m[7] = 0;
            result.m[8] = 0;
            result.m[11] = 0;
            result.m[12] = 0;
            result.m[13] = 0;
            result.m[14] = 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix RotationY(double angle)
        {
            var result = new Matrix();
            RotationYToRef(angle, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void RotationYToRef(double angle, Matrix result)
        {
            var s = Math.Sin(angle);
            var c = Math.Cos(angle);
            result.m[5] = 1.0;
            result.m[15] = 1.0;
            result.m[0] = c;
            result.m[2] = -s;
            result.m[8] = s;
            result.m[10] = c;
            result.m[1] = 0;
            result.m[3] = 0;
            result.m[4] = 0;
            result.m[6] = 0;
            result.m[7] = 0;
            result.m[9] = 0;
            result.m[11] = 0;
            result.m[12] = 0;
            result.m[13] = 0;
            result.m[14] = 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="yaw">
        /// </param>
        /// <param name="pitch">
        /// </param>
        /// <param name="roll">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix RotationYawPitchRoll(double yaw, double pitch, double roll)
        {
            var result = new Matrix();
            RotationYawPitchRollToRef(yaw, pitch, roll, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="yaw">
        /// </param>
        /// <param name="pitch">
        /// </param>
        /// <param name="roll">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void RotationYawPitchRollToRef(double yaw, double pitch, double roll, Matrix result)
        {
            Quaternion.RotationYawPitchRollToRef(yaw, pitch, roll, _tempQuaternion);
            _tempQuaternion.toRotationMatrix(result);
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix RotationZ(double angle)
        {
            var result = new Matrix();
            RotationZToRef(angle, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="angle">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void RotationZToRef(double angle, Matrix result)
        {
            var s = Math.Sin(angle);
            var c = Math.Cos(angle);
            result.m[10] = 1.0;
            result.m[15] = 1.0;
            result.m[0] = c;
            result.m[1] = s;
            result.m[4] = -s;
            result.m[5] = c;
            result.m[2] = 0;
            result.m[3] = 0;
            result.m[6] = 0;
            result.m[7] = 0;
            result.m[8] = 0;
            result.m[9] = 0;
            result.m[11] = 0;
            result.m[12] = 0;
            result.m[13] = 0;
            result.m[14] = 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix Scaling(double x, double y, double z)
        {
            var result = Zero();
            ScalingToRef(x, y, z, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void ScalingToRef(double x, double y, double z, Matrix result)
        {
            result.m[0] = x;
            result.m[1] = 0;
            result.m[2] = 0;
            result.m[3] = 0;
            result.m[4] = 0;
            result.m[5] = y;
            result.m[6] = 0;
            result.m[7] = 0;
            result.m[8] = 0;
            result.m[9] = 0;
            result.m[10] = z;
            result.m[11] = 0;
            result.m[12] = 0;
            result.m[13] = 0;
            result.m[14] = 0;
            result.m[15] = 1.0;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix Translation(double x, double y, double z)
        {
            var result = Identity();
            TranslationToRef(x, y, z, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="result">
        /// </param>
        public static void TranslationToRef(double x, double y, double z, Matrix result)
        {
            FromValuesToRef(1.0, 0, 0, 0, 0, 1.0, 0, 0, 0, 0, 1.0, 0, x, y, z, 1.0, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="matrix">
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix Transpose(Matrix matrix)
        {
            var result = new Matrix();
            result.m[0] = matrix.m[0];
            result.m[1] = matrix.m[4];
            result.m[2] = matrix.m[8];
            result.m[3] = matrix.m[12];
            result.m[4] = matrix.m[1];
            result.m[5] = matrix.m[5];
            result.m[6] = matrix.m[9];
            result.m[7] = matrix.m[13];
            result.m[8] = matrix.m[2];
            result.m[9] = matrix.m[6];
            result.m[10] = matrix.m[10];
            result.m[11] = matrix.m[14];
            result.m[12] = matrix.m[3];
            result.m[13] = matrix.m[7];
            result.m[14] = matrix.m[11];
            result.m[15] = matrix.m[15];
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static Matrix Zero()
        {
            return FromValues(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double[] asArray()
        {
            return this.toArray();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix clone()
        {
            return FromValues(
                this.m[0], 
                this.m[1], 
                this.m[2], 
                this.m[3], 
                this.m[4], 
                this.m[5], 
                this.m[6], 
                this.m[7], 
                this.m[8], 
                this.m[9], 
                this.m[10], 
                this.m[11], 
                this.m[12], 
                this.m[13], 
                this.m[14], 
                this.m[15]);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        public virtual void copyFrom(Matrix other)
        {
            for (var index = 0; index < 16; index++)
            {
                this.m[index] = other.m[index];
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="offset">
        /// </param>
        public virtual void copyToArray(double[] array, int offset = 0)
        {
            for (var index = 0; index < 16; index++)
            {
                array[offset + index] = this.m[index];
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double determinant()
        {
            var temp1 = (this.m[10] * this.m[15]) - (this.m[11] * this.m[14]);
            var temp2 = (this.m[9] * this.m[15]) - (this.m[11] * this.m[13]);
            var temp3 = (this.m[9] * this.m[14]) - (this.m[10] * this.m[13]);
            var temp4 = (this.m[8] * this.m[15]) - (this.m[11] * this.m[12]);
            var temp5 = (this.m[8] * this.m[14]) - (this.m[10] * this.m[12]);
            var temp6 = (this.m[8] * this.m[13]) - (this.m[9] * this.m[12]);
            return (((this.m[0] * (((this.m[5] * temp1) - (this.m[6] * temp2)) + (this.m[7] * temp3)))
                      - (this.m[1] * (((this.m[4] * temp1) - (this.m[6] * temp4)) + (this.m[7] * temp5))))
                     + (this.m[2] * (((this.m[4] * temp2) - (this.m[5] * temp4)) + (this.m[7] * temp6))))
                    - (this.m[3] * (((this.m[4] * temp3) - (this.m[5] * temp5)) + (this.m[6] * temp6)));
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool equals(Matrix value)
        {
            return value != null
                   && (this.m[0] == value.m[0] && this.m[1] == value.m[1] && this.m[2] == value.m[2] && this.m[3] == value.m[3] && this.m[4] == value.m[4]
                       && this.m[5] == value.m[5] && this.m[6] == value.m[6] && this.m[7] == value.m[7] && this.m[8] == value.m[8] && this.m[9] == value.m[9]
                       && this.m[10] == value.m[10] && this.m[11] == value.m[11] && this.m[12] == value.m[12] && this.m[13] == value.m[13]
                       && this.m[14] == value.m[14] && this.m[15] == value.m[15]);
        }

        /// <summary>
        /// </summary>
        public virtual void invert()
        {
            this.invertToRef(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        public virtual void invertToRef(Matrix other)
        {
            var l1 = this.m[0];
            var l2 = this.m[1];
            var l3 = this.m[2];
            var l4 = this.m[3];
            var l5 = this.m[4];
            var l6 = this.m[5];
            var l7 = this.m[6];
            var l8 = this.m[7];
            var l9 = this.m[8];
            var l10 = this.m[9];
            var l11 = this.m[10];
            var l12 = this.m[11];
            var l13 = this.m[12];
            var l14 = this.m[13];
            var l15 = this.m[14];
            var l16 = this.m[15];
            var l17 = (l11 * l16) - (l12 * l15);
            var l18 = (l10 * l16) - (l12 * l14);
            var l19 = (l10 * l15) - (l11 * l14);
            var l20 = (l9 * l16) - (l12 * l13);
            var l21 = (l9 * l15) - (l11 * l13);
            var l22 = (l9 * l14) - (l10 * l13);
            var l23 = ((l6 * l17) - (l7 * l18)) + (l8 * l19);
            var l24 = -(((l5 * l17) - (l7 * l20)) + (l8 * l21));
            var l25 = ((l5 * l18) - (l6 * l20)) + (l8 * l22);
            var l26 = -(((l5 * l19) - (l6 * l21)) + (l7 * l22));
            var l27 = 1.0 / ((((l1 * l23) + (l2 * l24)) + (l3 * l25)) + (l4 * l26));
            var l28 = (l7 * l16) - (l8 * l15);
            var l29 = (l6 * l16) - (l8 * l14);
            var l30 = (l6 * l15) - (l7 * l14);
            var l31 = (l5 * l16) - (l8 * l13);
            var l32 = (l5 * l15) - (l7 * l13);
            var l33 = (l5 * l14) - (l6 * l13);
            var l34 = (l7 * l12) - (l8 * l11);
            var l35 = (l6 * l12) - (l8 * l10);
            var l36 = (l6 * l11) - (l7 * l10);
            var l37 = (l5 * l12) - (l8 * l9);
            var l38 = (l5 * l11) - (l7 * l9);
            var l39 = (l5 * l10) - (l6 * l9);
            other.m[0] = l23 * l27;
            other.m[4] = l24 * l27;
            other.m[8] = l25 * l27;
            other.m[12] = l26 * l27;
            other.m[1] = -(((l2 * l17) - (l3 * l18)) + (l4 * l19)) * l27;
            other.m[5] = (((l1 * l17) - (l3 * l20)) + (l4 * l21)) * l27;
            other.m[9] = -(((l1 * l18) - (l2 * l20)) + (l4 * l22)) * l27;
            other.m[13] = (((l1 * l19) - (l2 * l21)) + (l3 * l22)) * l27;
            other.m[2] = (((l2 * l28) - (l3 * l29)) + (l4 * l30)) * l27;
            other.m[6] = -(((l1 * l28) - (l3 * l31)) + (l4 * l32)) * l27;
            other.m[10] = (((l1 * l29) - (l2 * l31)) + (l4 * l33)) * l27;
            other.m[14] = -(((l1 * l30) - (l2 * l32)) + (l3 * l33)) * l27;
            other.m[3] = -(((l2 * l34) - (l3 * l35)) + (l4 * l36)) * l27;
            other.m[7] = (((l1 * l34) - (l3 * l37)) + (l4 * l38)) * l27;
            other.m[11] = -(((l1 * l35) - (l2 * l37)) + (l4 * l39)) * l27;
            other.m[15] = (((l1 * l36) - (l2 * l38)) + (l3 * l39)) * l27;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isIdentity()
        {
            if (this.m[0] != 1.0 || this.m[5] != 1.0 || this.m[10] != 1.0 || this.m[15] != 1.0)
            {
                return false;
            }

            if (this.m[1] != 0.0 || this.m[2] != 0.0 || this.m[3] != 0.0 || this.m[4] != 0.0 || this.m[6] != 0.0 || this.m[7] != 0.0 || this.m[8] != 0.0
                || this.m[9] != 0.0 || this.m[11] != 0.0 || this.m[12] != 0.0 || this.m[13] != 0.0 || this.m[14] != 0.0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Matrix multiply(Matrix other)
        {
            var result = new Matrix();
            this.multiplyToRef(other, result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <param name="result">
        /// </param>
        /// <param name="offset">
        /// </param>
        public virtual void multiplyToArray(Matrix other, double[] result, int offset)
        {
            var tm0 = this.m[0];
            var tm1 = this.m[1];
            var tm2 = this.m[2];
            var tm3 = this.m[3];
            var tm4 = this.m[4];
            var tm5 = this.m[5];
            var tm6 = this.m[6];
            var tm7 = this.m[7];
            var tm8 = this.m[8];
            var tm9 = this.m[9];
            var tm10 = this.m[10];
            var tm11 = this.m[11];
            var tm12 = this.m[12];
            var tm13 = this.m[13];
            var tm14 = this.m[14];
            var tm15 = this.m[15];
            var om0 = other.m[0];
            var om1 = other.m[1];
            var om2 = other.m[2];
            var om3 = other.m[3];
            var om4 = other.m[4];
            var om5 = other.m[5];
            var om6 = other.m[6];
            var om7 = other.m[7];
            var om8 = other.m[8];
            var om9 = other.m[9];
            var om10 = other.m[10];
            var om11 = other.m[11];
            var om12 = other.m[12];
            var om13 = other.m[13];
            var om14 = other.m[14];
            var om15 = other.m[15];
            result[offset] = tm0 * om0 + tm1 * om4 + tm2 * om8 + tm3 * om12;
            result[offset + 1] = tm0 * om1 + tm1 * om5 + tm2 * om9 + tm3 * om13;
            result[offset + 2] = tm0 * om2 + tm1 * om6 + tm2 * om10 + tm3 * om14;
            result[offset + 3] = tm0 * om3 + tm1 * om7 + tm2 * om11 + tm3 * om15;
            result[offset + 4] = tm4 * om0 + tm5 * om4 + tm6 * om8 + tm7 * om12;
            result[offset + 5] = tm4 * om1 + tm5 * om5 + tm6 * om9 + tm7 * om13;
            result[offset + 6] = tm4 * om2 + tm5 * om6 + tm6 * om10 + tm7 * om14;
            result[offset + 7] = tm4 * om3 + tm5 * om7 + tm6 * om11 + tm7 * om15;
            result[offset + 8] = tm8 * om0 + tm9 * om4 + tm10 * om8 + tm11 * om12;
            result[offset + 9] = tm8 * om1 + tm9 * om5 + tm10 * om9 + tm11 * om13;
            result[offset + 10] = tm8 * om2 + tm9 * om6 + tm10 * om10 + tm11 * om14;
            result[offset + 11] = tm8 * om3 + tm9 * om7 + tm10 * om11 + tm11 * om15;
            result[offset + 12] = tm12 * om0 + tm13 * om4 + tm14 * om8 + tm15 * om12;
            result[offset + 13] = tm12 * om1 + tm13 * om5 + tm14 * om9 + tm15 * om13;
            result[offset + 14] = tm12 * om2 + tm13 * om6 + tm14 * om10 + tm15 * om14;
            result[offset + 15] = tm12 * om3 + tm13 * om7 + tm14 * om11 + tm15 * om15;
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <param name="result">
        /// </param>
        public virtual void multiplyToRef(Matrix other, Matrix result)
        {
            this.multiplyToArray(other, result.m, 0);
        }

        /// <summary>
        /// </summary>
        /// <param name="vector3">
        /// </param>
        public virtual void setTranslation(Vector3 vector3)
        {
            this.m[12] = vector3.x;
            this.m[13] = vector3.y;
            this.m[14] = vector3.z;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double[] toArray()
        {
            return this.m;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Plane
    {
        /// <summary>
        /// </summary>
        public double d;

        /// <summary>
        /// </summary>
        public Vector3 normal;

        /// <summary>
        /// </summary>
        /// <param name="a">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <param name="c">
        /// </param>
        /// <param name="d">
        /// </param>
        public Plane(double a, double b, double c, double d)
        {
            this.normal = new Vector3(a, b, c);
            this.d = d;
        }

        /// <summary>
        /// </summary>
        /// <param name="origin">
        /// </param>
        /// <param name="normal">
        /// </param>
        /// <param name="point">
        /// </param>
        /// <returns>
        /// </returns>
        public static double SignedDistanceToPlaneFromPositionAndNormal(Vector3 origin, Vector3 normal, Vector3 point)
        {
            var d = -(normal.x * origin.x + normal.y * origin.y + normal.z * origin.z);
            return Vector3.Dot(point, normal) + d;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> asArray()
        {
            return new Array<double>(this.normal.x, this.normal.y, this.normal.z, this.d);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Plane clone()
        {
            return new Plane(this.normal.x, this.normal.y, this.normal.z, this.d);
        }

        /// <summary>
        /// </summary>
        /// <param name="point1">
        /// </param>
        /// <param name="point2">
        /// </param>
        /// <param name="point3">
        /// </param>
        public virtual void copyFromPoints(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            var x1 = point2.x - point1.x;
            var y1 = point2.y - point1.y;
            var z1 = point2.z - point1.z;
            var x2 = point3.x - point1.x;
            var y2 = point3.y - point1.y;
            var z2 = point3.z - point1.z;
            var yz = (y1 * z2) - (z1 * y2);
            var xz = (z1 * x2) - (x1 * z2);
            var xy = (x1 * y2) - (y1 * x2);
            var pyth = Math.Sqrt((yz * yz) + (xz * xz) + (xy * xy));
            double invPyth;
            if (pyth != 0)
            {
                invPyth = 1.0 / pyth;
            }
            else
            {
                invPyth = 0;
            }

            this.normal.x = yz * invPyth;
            this.normal.y = xz * invPyth;
            this.normal.z = xy * invPyth;
            this.d = -((this.normal.x * point1.x) + (this.normal.y * point1.y) + (this.normal.z * point1.z));
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual double dotCoordinate(Vector3 point)
        {
            return (((this.normal.x * point.x) + (this.normal.y * point.y)) + (this.normal.z * point.z)) + this.d;
        }

        /// <summary>
        /// </summary>
        /// <param name="direction">
        /// </param>
        /// <param name="epsilon">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isFrontFacingTo(Vector3 direction, double epsilon)
        {
            var dot = Vector3.Dot(this.normal, direction);
            return dot <= epsilon;
        }

        /// <summary>
        /// </summary>
        public virtual void normalize()
        {
            var norm = Math.Sqrt((this.normal.x * this.normal.x) + (this.normal.y * this.normal.y) + (this.normal.z * this.normal.z));
            var magnitude = 0.0;
            if (norm != 0.0)
            {
                magnitude = 1.0 / norm;
            }

            this.normal.x *= magnitude;
            this.normal.y *= magnitude;
            this.normal.z *= magnitude;
            this.d *= magnitude;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual double signedDistanceTo(Vector3 point)
        {
            return Vector3.Dot(point, this.normal) + this.d;
        }

        /// <summary>
        /// </summary>
        /// <param name="transformation">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Plane transform(Matrix transformation)
        {
            var transposedMatrix = Matrix.Transpose(transformation);
            var x = this.normal.x;
            var y = this.normal.y;
            var z = this.normal.z;
            var d = this.d;
            var normalX = (((x * transposedMatrix.m[0]) + (y * transposedMatrix.m[1])) + (z * transposedMatrix.m[2])) + (d * transposedMatrix.m[3]);
            var normalY = (((x * transposedMatrix.m[4]) + (y * transposedMatrix.m[5])) + (z * transposedMatrix.m[6])) + (d * transposedMatrix.m[7]);
            var normalZ = (((x * transposedMatrix.m[8]) + (y * transposedMatrix.m[9])) + (z * transposedMatrix.m[10])) + (d * transposedMatrix.m[11]);
            var finalD = (((x * transposedMatrix.m[12]) + (y * transposedMatrix.m[13])) + (z * transposedMatrix.m[14])) + (d * transposedMatrix.m[15]);
            return new Plane(normalX, normalY, normalZ, finalD);
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <returns>
        /// </returns>
        public static Plane FromArray(Array<double> array)
        {
            return new Plane(array[0], array[1], array[2], array[3]);
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <returns>
        /// </returns>
        public static Plane FromArray(double[] array)
        {
            if (array == null || array.Length < 4)
            {
                return null;
            }

            return new Plane(array[0], array[1], array[2], array[3]);
        }

        /// <summary>
        /// </summary>
        /// <param name="point1">
        /// </param>
        /// <param name="point2">
        /// </param>
        /// <param name="point3">
        /// </param>
        /// <returns>
        /// </returns>
        private static Plane FromPoints(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            var result = new Plane(0, 0, 0, 0);
            result.copyFromPoints(point1, point2, point3);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="origin">
        /// </param>
        /// <param name="normal">
        /// </param>
        /// <returns>
        /// </returns>
        private static Plane FromPositionAndNormal(Vector3 origin, Vector3 normal)
        {
            var result = new Plane(0, 0, 0, 0);
            normal.normalize();
            result.normal = normal;
            result.d = -(normal.x * origin.x + normal.y * origin.y + normal.z * origin.z);
            return result;
        }
    }

    /// <summary>
    /// </summary>
    public partial class Viewport
    {
        /// <summary>
        /// </summary>
        public double height;

        /// <summary>
        /// </summary>
        public double width;

        /// <summary>
        /// </summary>
        public double x;

        /// <summary>
        /// </summary>
        public double y;

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        public Viewport(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// </summary>
        /// <param name="engine">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Viewport toGlobal(Engine engine)
        {
            var width = engine.getRenderWidth();
            var height = engine.getRenderHeight();
            return new Viewport(this.x * width, this.y * height, this.width * width, this.height * height);
        }
    }

    /// <summary>
    /// </summary>
    public partial class Frustum
    {
        /// <summary>
        /// </summary>
        /// <param name="transform">
        /// </param>
        /// <returns>
        /// </returns>
        public static Array<Plane> GetPlanes(Matrix transform)
        {
            var frustumPlanes = new Array<Plane>();
            for (var index = 0; index < 6; index++)
            {
                frustumPlanes.Add(new Plane(0, 0, 0, 0));
            }

            GetPlanesToRef(transform, frustumPlanes);
            return frustumPlanes;
        }

        /// <summary>
        /// </summary>
        /// <param name="transform">
        /// </param>
        /// <param name="frustumPlanes">
        /// </param>
        public static void GetPlanesToRef(Matrix transform, Array<Plane> frustumPlanes)
        {
            frustumPlanes[0].normal.x = transform.m[3] + transform.m[2];
            frustumPlanes[0].normal.y = transform.m[7] + transform.m[6];
            frustumPlanes[0].normal.z = transform.m[10] + transform.m[10];
            frustumPlanes[0].d = transform.m[15] + transform.m[14];
            frustumPlanes[0].normalize();
            frustumPlanes[1].normal.x = transform.m[3] - transform.m[2];
            frustumPlanes[1].normal.y = transform.m[7] - transform.m[6];
            frustumPlanes[1].normal.z = transform.m[11] - transform.m[10];
            frustumPlanes[1].d = transform.m[15] - transform.m[14];
            frustumPlanes[1].normalize();
            frustumPlanes[2].normal.x = transform.m[3] + transform.m[0];
            frustumPlanes[2].normal.y = transform.m[7] + transform.m[4];
            frustumPlanes[2].normal.z = transform.m[11] + transform.m[8];
            frustumPlanes[2].d = transform.m[15] + transform.m[12];
            frustumPlanes[2].normalize();
            frustumPlanes[3].normal.x = transform.m[3] - transform.m[0];
            frustumPlanes[3].normal.y = transform.m[7] - transform.m[4];
            frustumPlanes[3].normal.z = transform.m[11] - transform.m[8];
            frustumPlanes[3].d = transform.m[15] - transform.m[12];
            frustumPlanes[3].normalize();
            frustumPlanes[4].normal.x = transform.m[3] - transform.m[1];
            frustumPlanes[4].normal.y = transform.m[7] - transform.m[5];
            frustumPlanes[4].normal.z = transform.m[11] - transform.m[9];
            frustumPlanes[4].d = transform.m[15] - transform.m[13];
            frustumPlanes[4].normalize();
            frustumPlanes[5].normal.x = transform.m[3] + transform.m[1];
            frustumPlanes[5].normal.y = transform.m[7] + transform.m[5];
            frustumPlanes[5].normal.z = transform.m[11] + transform.m[9];
            frustumPlanes[5].d = transform.m[15] + transform.m[13];
            frustumPlanes[5].normalize();
        }
    }

    /// <summary>
    /// </summary>
    public partial class Ray
    {
        /// <summary>
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// </summary>
        public Vector3 origin;

        /// <summary>
        /// </summary>
        private Vector3 _edge1;

        /// <summary>
        /// </summary>
        private Vector3 _edge2;

        /// <summary>
        /// </summary>
        private Vector3 _pvec;

        /// <summary>
        /// </summary>
        private Vector3 _qvec;

        /// <summary>
        /// </summary>
        private Vector3 _tvec;

        /// <summary>
        /// </summary>
        /// <param name="origin">
        /// </param>
        /// <param name="direction">
        /// </param>
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="viewportWidth">
        /// </param>
        /// <param name="viewportHeight">
        /// </param>
        /// <param name="world">
        /// </param>
        /// <param name="view">
        /// </param>
        /// <param name="projection">
        /// </param>
        /// <returns>
        /// </returns>
        public static Ray CreateNew(double x, double y, double viewportWidth, double viewportHeight, Matrix world, Matrix view, Matrix projection)
        {
            var start = Vector3.Unproject(new Vector3(x, y, 0), viewportWidth, viewportHeight, world, view, projection);
            var end = Vector3.Unproject(new Vector3(x, y, 1), viewportWidth, viewportHeight, world, view, projection);
            var direction = end.subtract(start);
            direction.normalize();
            return new Ray(start, direction);
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <param name="matrix">
        /// </param>
        /// <returns>
        /// </returns>
        public static Ray Transform(Ray ray, Matrix matrix)
        {
            var newOrigin = Vector3.TransformCoordinates(ray.origin, matrix);
            var newDirection = Vector3.TransformNormal(ray.direction, matrix);
            return new Ray(newOrigin, newDirection);
        }

        /// <summary>
        /// </summary>
        /// <param name="box">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsBox(BoundingBox box)
        {
            return this.intersectsBoxMinMax(box.minimum, box.maximum);
        }

        /// <summary>
        /// </summary>
        /// <param name="minimum">
        /// </param>
        /// <param name="maximum">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsBoxMinMax(Vector3 minimum, Vector3 maximum)
        {
            var d = 0.0;
            var maxValue = double.MaxValue;
            if (Math.Abs(this.direction.x) < 0.0000001)
            {
                if (this.origin.x < minimum.x || this.origin.x > maximum.x)
                {
                    return false;
                }
            }
            else
            {
                var inv = 1.0 / this.direction.x;
                var min = (minimum.x - this.origin.x) * inv;
                var max = (maximum.x - this.origin.x) * inv;
                if (min > max)
                {
                    var temp = min;
                    min = max;
                    max = temp;
                }

                d = Math.Max(min, d);
                maxValue = Math.Min(max, maxValue);
                if (d > maxValue)
                {
                    return false;
                }
            }

            if (Math.Abs(this.direction.y) < 0.0000001)
            {
                if (this.origin.y < minimum.y || this.origin.y > maximum.y)
                {
                    return false;
                }
            }
            else
            {
                var inv = 1.0 / this.direction.y;
                var min = (minimum.y - this.origin.y) * inv;
                var max = (maximum.y - this.origin.y) * inv;
                if (min > max)
                {
                    var temp = min;
                    min = max;
                    max = temp;
                }

                d = Math.Max(min, d);
                maxValue = Math.Min(max, maxValue);
                if (d > maxValue)
                {
                    return false;
                }
            }

            if (Math.Abs(this.direction.z) < 0.0000001)
            {
                if (this.origin.z < minimum.z || this.origin.z > maximum.z)
                {
                    return false;
                }
            }
            else
            {
                var inv = 1.0 / this.direction.z;
                var min = (minimum.z - this.origin.z) * inv;
                var max = (maximum.z - this.origin.z) * inv;
                if (min > max)
                {
                    var temp = min;
                    min = max;
                    max = temp;
                }

                d = Math.Max(min, d);
                maxValue = Math.Min(max, maxValue);
                if (d > maxValue)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="sphere">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsSphere(BoundingSphere sphere)
        {
            var x = sphere.center.x - this.origin.x;
            var y = sphere.center.y - this.origin.y;
            var z = sphere.center.z - this.origin.z;
            var pyth = (x * x) + (y * y) + (z * z);
            var rr = sphere.radius * sphere.radius;
            if (pyth <= rr)
            {
                return true;
            }

            var dot = (x * this.direction.x) + (y * this.direction.y) + (z * this.direction.z);
            if (dot < 0.0)
            {
                return false;
            }

            var temp = pyth - (dot * dot);
            return temp <= rr;
        }

        /// <summary>
        /// </summary>
        /// <param name="vertex0">
        /// </param>
        /// <param name="vertex1">
        /// </param>
        /// <param name="vertex2">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual IntersectionInfo intersectsTriangle(Vector3 vertex0, Vector3 vertex1, Vector3 vertex2)
        {
            if (this._edge1 == null)
            {
                this._edge1 = Vector3.Zero();
                this._edge2 = Vector3.Zero();
                this._pvec = Vector3.Zero();
                this._tvec = Vector3.Zero();
                this._qvec = Vector3.Zero();
            }

            vertex1.subtractToRef(vertex0, this._edge1);
            vertex2.subtractToRef(vertex0, this._edge2);
            Vector3.CrossToRef(this.direction, this._edge2, this._pvec);
            var det = Vector3.Dot(this._edge1, this._pvec);
            if (det == 0)
            {
                return null;
            }

            var invdet = 1 / det;
            this.origin.subtractToRef(vertex0, this._tvec);
            var bu = Vector3.Dot(this._tvec, this._pvec) * invdet;
            if (bu < 0 || bu > 1.0)
            {
                return null;
            }

            Vector3.CrossToRef(this._tvec, this._edge1, this._qvec);
            var bv = Vector3.Dot(this.direction, this._qvec) * invdet;
            if (bv < 0 || bu + bv > 1.0)
            {
                return null;
            }

            return new IntersectionInfo(bu, bv, Vector3.Dot(this._edge2, this._qvec) * invdet);
        }
    }

    /// <summary>
    /// </summary>
    public enum Space
    {
        /// <summary>
        /// </summary>
        LOCAL, 

        /// <summary>
        /// </summary>
        WORLD
    }

    /// <summary>
    /// </summary>
    public partial class Axis
    {
        /// <summary>
        /// </summary>
        public static Vector3 X = new Vector3(1, 0, 0);

        /// <summary>
        /// </summary>
        public static Vector3 Y = new Vector3(0, 1, 0);

        /// <summary>
        /// </summary>
        public static Vector3 Z = new Vector3(0, 0, 1);
    }
}