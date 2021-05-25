using System;
using System.Numerics;

namespace BigRational
{
    /// <summary>
    /// This class is meant to precisely represent rational fractions and perform
    /// math/comparison operations.
    /// </summary>
    public class BigRational
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public BigRational(BigInteger num, BigInteger denom)
        {
            //todo: reduce both by the greatest common denominator
            // (hint: look for Euclid's algorithm)
            if (denom < 0)
            {
                num *= -1;
                denom *= -1;
            }

            BigInteger gcd = this.gcdByEuclidsAlgorithm(num, denom);

            Numerator = num / gcd;
            Denominator = denom / gcd;
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        public BigInteger gcdByEuclidsAlgorithm(BigInteger n1, BigInteger n2)
        {
            if (n2 == 0)
            {
                return n1;
            }
            return gcdByEuclidsAlgorithm(n2, n1 % n2);
        }

        public static BigRational operator * (BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        //TODO: add remaining arithmetic operators (-, /, +, %)
        public static BigRational operator - (BigRational left, BigRational right)
        {
            if(left.Denominator == right.Denominator)
            {
                return new BigRational(left.Numerator - right.Numerator,
                                    left.Denominator);
            }

            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        public static BigRational operator +(BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        public static BigRational operator / (BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        public static BigRational operator % (BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        /// <summary>
        /// Compares if left is less than the right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is less than the right.
        /// </returns>
        public static bool operator < ( BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Compares if left is greater than the right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is greater than the right.
        /// </returns>
        public static bool operator > (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Compares if left is greater than or equal to the right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is greater than or equal to the right.
        /// </returns>
        public static bool operator >= (BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator >= right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Compares if left is less than or equal tothe right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is less than or equal to the right.
        /// </returns>
        public static bool operator <=(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator <= right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Compares if left is equal to the right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is equal to the right.
        /// </returns>
        public static bool operator ==(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator == right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Compares if left is not equal to the right.
        /// </summary>
        /// <returns>
        /// A boolean representing if the left is not equal to the right.
        /// </returns>
        public static bool operator !=(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator != right.Numerator * left.Denominator;
        }

    }
}
