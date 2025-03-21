﻿using System.Collections.Frozen;

namespace NCalc.Helpers;

public static class MathFunctionHelper
{
    private static List<MathMethodInfo> GetMathMethodInfo(string method, int argCount, bool supportDecimal = false)
    {
        var methodInfo = new List<MathMethodInfo>();

        if (supportDecimal)
        {
            methodInfo.Add(new MathMethodInfo
            {
                MethodInfo = typeof(Math).GetMethod(method, Enumerable.Repeat(typeof(decimal), argCount).ToArray())!,
                ArgumentCount = argCount,
                DecimalSupport = true
            });
        }

        methodInfo.Add(new MathMethodInfo
        {
            MethodInfo = typeof(Math).GetMethod(method, Enumerable.Repeat(typeof(double), argCount).ToArray())!,
            ArgumentCount = argCount,
            DecimalSupport = false
        });

        return methodInfo;
    }

    public static readonly FrozenDictionary<string, List<MathMethodInfo>> Functions =
        new Dictionary<string, List<MathMethodInfo>>
        {
            { "ABS", GetMathMethodInfo(nameof(Math.Abs), 1, true) },
            { "ACOS", GetMathMethodInfo(nameof(Math.Acos), 1) },
            { "ASIN", GetMathMethodInfo(nameof(Math.Asin), 1) },
            { "ATAN", GetMathMethodInfo(nameof(Math.Atan), 1) },
            { "ATAN2", GetMathMethodInfo(nameof(Math.Atan2), 2) },
            { "CEILING", GetMathMethodInfo(nameof(Math.Ceiling), 1, true) },
            { "COS", GetMathMethodInfo(nameof(Math.Cos), 1) },
            { "COSH", GetMathMethodInfo(nameof(Math.Cosh), 1) },
            { "EXP", GetMathMethodInfo(nameof(Math.Exp), 1) },
            { "FLOOR", GetMathMethodInfo(nameof(Math.Floor), 1, true) },
            { "IEEEREMAINDER", GetMathMethodInfo(nameof(Math.IEEERemainder), 2) },
            { "LOG", GetMathMethodInfo(nameof(Math.Log), 2) },
            { "LOG10", GetMathMethodInfo(nameof(Math.Log10), 1) },
            { "SIGN", GetMathMethodInfo(nameof(Math.Sign), 1, true) },
            { "SIN", GetMathMethodInfo(nameof(Math.Sin), 1) },
            { "SINH", GetMathMethodInfo(nameof(Math.Sinh), 1) },
            { "SQRT", GetMathMethodInfo(nameof(Math.Sqrt), 1) },
            { "TAN", GetMathMethodInfo(nameof(Math.Tan), 1) },
            { "TANH", GetMathMethodInfo(nameof(Math.Tanh), 1) },
            { "TRUNCATE", GetMathMethodInfo(nameof(Math.Truncate), 1, true) },

            // Exceptional handling
            {
                "ROUND",
                [
                    new MathMethodInfo
                    {
                        MethodInfo = typeof(Math).GetMethod(nameof(Math.Round),
                            [typeof(double), typeof(int), typeof(MidpointRounding)])!,
                        ArgumentCount = 2,
                        DecimalSupport = false
                    }
                ]
            }
        }.ToFrozenDictionary();
}