﻿using System;
using LockStepMath;
namespace LockStepMath
{

    [Serializable]
    public struct LFloat : IEquatable<LFloat>, IComparable<LFloat>
    {
        public const int Precision = 1000;
        public const float PrecisionFactor = 0.001f;

        public int _val;

        public static readonly LFloat zero = new LFloat(0);
        public static readonly LFloat one = new LFloat(LFloat.Precision);

        /// <summary>
        /// 传入的是正常数放大1000 的数值
        /// </summary>
        /// <param name="rawVal"></param>
        public LFloat(int rawVal)
        {
            this._val = rawVal * Precision;
        }

        /// <summary>
        /// 传入的是正常数放大1000 的数值
        /// </summary>
        /// <param name="rawVal"></param>
        public LFloat(long rawVal)
        {
            this._val = (int) (rawVal * Precision);
        }

        public LFloat(LFloat rhs)
        {
            this._val = rhs._val;
        }

        #region override operator 

        public static bool operator <(LFloat a, LFloat b)
        {
            return a._val < b._val;
        }

        public static bool operator >(LFloat a, LFloat b)
        {
            return a._val > b._val;
        }

        public static bool operator <=(LFloat a, LFloat b)
        {
            return a._val <= b._val;
        }

        public static bool operator >=(LFloat a, LFloat b)
        {
            return a._val >= b._val;
        }

        public static bool operator ==(LFloat a, LFloat b)
        {
            return a._val == b._val;
        }

        public static bool operator !=(LFloat a, LFloat b)
        {
            return a._val != b._val;
        }

        public static LFloat operator +(LFloat a, LFloat b)
        {
            return new LFloat(a._val + b._val);
        }

        public static LFloat operator -(LFloat a, LFloat b)
        {
            return new LFloat(a._val - b._val);
        }

        public static LFloat operator *(LFloat a, LFloat b)
        {
            long val = (long) (a._val) * b._val;
            return new LFloat((int) (val / 1000));
        }

        public static LFloat operator /(LFloat a, LFloat b)
        {
            long val = (long) (a._val * 1000) / b._val;
            return new LFloat((int) (val));
        }


        public static LFloat operator -(LFloat a)
        {
            return new LFloat(-a._val);
        }

        #endregion

        #region override object func 

        public override bool Equals(object obj)
        {
            return obj is LFloat && ((LFloat) obj)._val == _val;
        }

        public bool Equals(LFloat other)
        {
            return _val == other._val;
        }

        public int CompareTo(LFloat other)
        {
            return _val.CompareTo(other._val);
        }

        public override int GetHashCode()
        {
            return _val;
        }

        public override string ToString()
        {
            return (_val * LFloat.PrecisionFactor).ToString();
        }

        #endregion

        #region override type convert 

        public static explicit operator LFloat(int value)
        {
            return new LFloat(value * Precision);
        }

        public static explicit operator int(LFloat value)
        {
            return value._val / Precision;
        }

        public static explicit operator LFloat(long value)
        {
            return new LFloat(value * Precision);
        }

        public static explicit operator long(LFloat value)
        {
            return value._val / Precision;
        }


        public static explicit operator LFloat(float value)
        {
            return new LFloat((long) (value * Precision));
        }

        public static explicit operator float(LFloat value)
        {
            return (float) value._val * 0.001f;
        }

        public static explicit operator LFloat(double value)
        {
            return new LFloat((long) (value * Precision));
        }

        public static explicit operator double(LFloat value)
        {
            return (double) value._val * 0.001;
        }

        #endregion


        public int ToInt
        {
            get { return _val / 1000; }
        }

        public long ToLong
        {
            get { return _val / 1000; }
        }

        public float ToFloat
        {
            get { return _val / 0.001f; }
        }

        public double ToDouble
        {
            get { return _val / 0.001; }
        }

        public LFloat Floor
        {
            get
            {
                int x = this._val;
                if (x > 0)
                {
                    x /= LFloat.Precision;
                }
                else
                {
                    if (x % LFloat.Precision == 0)
                    {
                        x /= LFloat.Precision;
                    }
                    else
                    {
                        x = x / LFloat.Precision - 1;
                    }
                }

                return new LFloat(x * LFloat.Precision);
            }
        }

        public LFloat Ceil
        {
            get
            {
                int x = this._val;
                if (x < 0)
                {
                    x /= LFloat.Precision;
                }
                else
                {
                    if (x % LFloat.Precision == 0)
                    {
                        x /= LFloat.Precision;
                    }
                    else
                    {
                        x = x / LFloat.Precision + 1;
                    }
                }

                return new LFloat(x * LFloat.Precision);
            }
        }
    }
}
